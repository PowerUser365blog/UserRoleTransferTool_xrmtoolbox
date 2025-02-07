using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Web.Services.Description;
using System.Windows.Forms;
using UserRoleTransferTool.Helpers;
using XrmToolBox.Extensibility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserRoleTransferTool
{
    public partial class UserRoleTransferToolControl : PluginControlBase
    {
        private Settings mySettings;
        private ListViewItem[] listViewSourceUsersTeams;
        private ListViewItem[] listViewDestinationUsersTeams;
        private ListViewItem[] listViewRoles;

        public UserRoleTransferToolControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
            ExecuteMethod(GetUsers);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            //ExecuteMethod(GetAccounts);
        }

        private void GetUsers()
        {
            txtRoleFilter.Text = "";
            txtUserTeamFilter.Text = "";
            txtUserTeamFilter2.Text = "";

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities...",
                Work = (worker, args) =>
                {
                    var users = new GetSystemUsers().RetrieveUsers(Service, worker);
                    var teams = new GetSystemUsers().RetrieveTeams(Service, worker);

                    users.AddRange(teams);

                    var roles = new GetRoles().RetrieveRoles(Service, "role", worker);
                    var result = new
                    {
                        users,
                        roles
                    };
                    args.Result = result;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var result = args.Result as dynamic;
                        lvSourceUser.Items.Clear();
                        lvDestinationUser.Items.Clear();

                        var systemUsers = ((List<Entity>)result.users).ToArray();
                        var listUser = systemUsers.Select(user =>
                        {
                            var fullname = user.GetAttributeValue<string>("fullname") ?? user.GetAttributeValue<string>("name") ?? "";
                            var email = user.GetAttributeValue<string>("internalemailaddress") ?? user.GetAttributeValue<string>("emailaddress") ?? "";
                            var type = user.GetAttributeValue<string>("type");

                            var systemUser = new ListViewItem { Text = fullname, Tag = user.Id };
                            systemUser.SubItems.Add(email);
                            systemUser.SubItems.Add(type);

                            return systemUser;
                        }).ToList();

                        listViewSourceUsersTeams = listUser.ToArray();
                        var clonedListUser = listUser.Select(item => (ListViewItem)item.Clone()).ToList();
                        listViewDestinationUsersTeams = clonedListUser.ToArray();

                        listUser = listUser.OrderBy(item => item.Text).ToList();
                        clonedListUser = clonedListUser.OrderBy(item => item.Text).ToList();

                        lvSourceUser.Items.AddRange(listUser.ToArray());

                        lvDestinationUser.Items.AddRange(clonedListUser.ToArray());

                        //Roles
                        lvRolesSource.Items.Clear();
                        var roles = ((List<Entity>)result.roles).ToArray();
                        var listRole = roles.Select(role =>
                        {
                            var name = role.GetAttributeValue<string>("name");
                            var fullrole = new ListViewItem { Text = name, Tag = role.Id, Checked = false };
                            return fullrole;
                        }).ToList();

                        listRole = listRole.OrderBy(item => item.Text).ToList();

                        listViewRoles = listRole.ToArray();
                        lvRolesSource.Items.AddRange(listRole.ToArray());
                    }
                }
            });
        }

        private void GetRolesByUserTeam(Guid tag, bool user)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading roles...",
                Work = (worker, args) =>
                {
                    List<Entity> roles = new List<Entity>();

                    if (user)
                    {
                        roles = new GetRoles().RetrieveRolesByUser(Service, "role", tag, worker);
                    }
                    else
                    {
                        roles = new GetRoles().RetrieveRolesByTeam(Service, "role", tag, worker);
                    }

                    var result = new
                    {
                        roles
                    };
                    args.Result = result;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        UncheckAllRoles();
                        var result = args.Result as dynamic;

                        Entity[] rolesByUser = ((List<Entity>)result.roles).ToArray();
                        var listRoleByUser = new List<ListViewItem>();

                        foreach (var role in rolesByUser)
                        {
                            string guid = role.GetAttributeValue<Guid>("roleid").ToString();
                            var name = role.GetAttributeValue<AliasedValue>("role.name").Value.ToString();
                            foreach (ListViewItem item in lvRolesSource.Items)
                            {
                                if (item.Tag.ToString().ToLower() == guid.ToLower())
                                {
                                    item.Checked = true;
                                }

                            }
                        }
                    }
                }
            });
        }

        private void UncheckAllRoles()
        {
            foreach (ListViewItem item in lvRolesSource.Items)
            {
                item.Checked = false;
            }
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void tsbLoadUsers_Click(object sender, EventArgs e)
        {
            ExecuteMethod(GetUsers);
        }

        private bool sameUserTeam()
        {
            if ((lvSourceUser.SelectedItems.Count != 0) && (lvDestinationUser.SelectedItems.Count != 0))
            {
                var sourceUser = lvSourceUser.SelectedItems[0].Tag;
                var destinationUser = lvDestinationUser.SelectedItems[0].Tag;
                if (sourceUser == destinationUser)
                {
                    MessageBox.Show("The source user/team and the destination user/team are the same. They must be different.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            return false;

        }

        private void lvSourceUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvSourceUser.SelectedItems.Count > 0)
            {
                var selectedItem = lvSourceUser.SelectedItems[0];
                var type = selectedItem.SubItems[2].Text;
                var userId = (Guid)selectedItem.Tag;
                tsbAdd.Enabled = true;
                tsbTransfer.Enabled = true;
                if (type.ToLower() == "user")
                {
                    ExecuteMethod(() => GetRolesByUserTeam(userId, true));
                }
                else
                {
                    ExecuteMethod(() => GetRolesByUserTeam(userId, false));
                }
            }
            else
            {
                tsbAdd.Enabled = false;
                tsbTransfer.Enabled = false;
            }

        }

        private void txtRoleFilter_TextChanged(object sender, EventArgs e)
        {
            // Limpiar el ListView
            lvRolesSource.Items.Clear();

            // Filtrar los elementos que contienen el texto del TextBox
            var filteredItems = listViewRoles
                .Where(item => item.Text.IndexOf(txtRoleFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(item => item.Text)
                .ToArray();

            // Agregar los elementos filtrados al ListView
            lvRolesSource.Items.AddRange(filteredItems);
        }
        private void txtUserTeamFilter_TextChanged(object sender, EventArgs e)
        {
            // Limpiar el ListView
            lvSourceUser.Items.Clear();

            // Filtrar los elementos que contienen el texto del TextBox
            var filteredItems = listViewSourceUsersTeams
                .Where(item => item.Text.IndexOf(txtUserTeamFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(item => item.Text)
                .ToArray();

            // Agregar los elementos filtrados al ListView
            lvSourceUser.Items.AddRange(filteredItems);
        }

        private void txtUserTeamFilter2_TextChanged(object sender, EventArgs e)
        {
            // Limpiar el ListView
            lvDestinationUser.Items.Clear();

            // Filtrar los elementos que contienen el texto del TextBox
            var filteredItems = listViewDestinationUsersTeams
                .Where(item => item.Text.IndexOf(txtUserTeamFilter2.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(item => item.Text)
                .ToArray();

            // Agregar los elementos filtrados al ListView
            lvDestinationUser.Items.AddRange(filteredItems);
        }

        private void lvDestinationUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilita el botón únicamente si se ha seleccionado al menos un elemento
            tsbAdd.Enabled = lvDestinationUser.SelectedItems.Count > 0;
        }



        private void tsbTransfer_Click(object sender, EventArgs e)
        {
            var userid = (Guid)lvDestinationUser.SelectedItems[0].Tag;
            var type = lvDestinationUser.SelectedItems[0].SubItems[2].Text;

            List<Guid> selected = lvRolesSource.Items
                .Cast<ListViewItem>()
                .Where(item => item.Checked && item.Tag is Guid)
                .Select(item => (Guid)item.Tag)
                .ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("You must select at least one role to add to the user/team", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!sameUserTeam())
            {

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Transfering roles...",
                    Work = (worker, args) =>
                    {
                        List<Entity> roles = new List<Entity>();
                        if (type.ToLower() == "user")
                        {
                            roles = new GetRoles().RetrieveRolesByUser(Service, "role", userid, worker);
                        }
                        else
                        {
                            roles = new GetRoles().RetrieveRolesByTeam(Service, "role", userid, worker);
                        }
                        var result = new
                        {
                            roles
                        };
                        args.Result = result;
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var result = args.Result as dynamic;
                            List<Entity> rolesByUser = ((List<Entity>)result.roles).ToList();

                            List<Guid> roleIds = rolesByUser
                                .Select(role => new Guid(role.Attributes["roleid"].ToString()))
                                .ToList();

                            List<Guid> newRoleIds = selected.Except(roleIds).ToList();


                            addRoles(newRoleIds, userid, type.ToLower() == "user");



                            List<Guid> rolesToRemove = roleIds.Except(selected).ToList();

                            removeRoles(rolesToRemove, userid, type.ToLower() == "user");

                        }
                    }
                });


            }

            MessageBox.Show("Roles transfered successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userid = (Guid)lvDestinationUser.SelectedItems[0].Tag;
            var type = lvDestinationUser.SelectedItems[0].SubItems[2].Text;

            List<Guid> selected = lvRolesSource.Items
                .Cast<ListViewItem>()
                .Where(item => item.Checked && item.Tag is Guid)
                .Select(item => (Guid)item.Tag)
                .ToList();

            if (selected.Count == 0)
            {
                MessageBox.Show("You must select at least one role to add to the user/team", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!sameUserTeam())
            {

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Adding roles...",
                    Work = (worker, args) =>
                    {
                        List<Entity> roles = new List<Entity>();
                        if (type.ToLower() == "user")
                        {
                            roles = new GetRoles().RetrieveRolesByUser(Service, "role", userid, worker);
                        }
                        else
                        {
                            roles = new GetRoles().RetrieveRolesByTeam(Service, "role", userid, worker);
                        }

                        var result = new
                        {
                            roles
                        };
                        args.Result = result;
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var result = args.Result as dynamic;
                            List<Entity> rolesByUser = ((List<Entity>)result.roles).ToList();

                            List<Guid> roleIds = rolesByUser
                                .Select(role => new Guid(role.Attributes["roleid"].ToString()))
                                .ToList();

                            List<Guid> newRoleIds = selected.Except(roleIds).ToList();

                            addRoles(newRoleIds, userid, type.ToLower() == "user");

                        }
                    }
                });

            }

            MessageBox.Show("Roles added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addRoles(List<Guid> roles, Guid userTeamId, bool isuser)
        {
            foreach (Guid id in roles)
            {
                AssociateRequest associateRequest;

                if (isuser)
                {
                    associateRequest = new AssociateRequest
                    {
                        Target = new EntityReference("systemuser", userTeamId),
                        RelatedEntities = new EntityReferenceCollection
                        {
                            new EntityReference("role", id)
                        },
                        Relationship = new Relationship("systemuserroles_association")
                    };

                }
                else
                {
                    associateRequest = new AssociateRequest
                    {
                        Target = new EntityReference("team", userTeamId),
                        RelatedEntities = new EntityReferenceCollection
                        {
                            new EntityReference("role", id)
                        },
                        Relationship = new Relationship("teamroles_association")
                    };
                }

                // Ejecutar la solicitud
                Service.Execute(associateRequest);
            }

        }

        private void removeRoles(List<Guid> roles, Guid userId, bool isuser)
        {
            foreach (Guid id in roles)
            {
                DisassociateRequest disassociateRequest;

                if (isuser)
                {
                    disassociateRequest = new DisassociateRequest
                    {
                        Target = new EntityReference("systemuser", userId),
                        RelatedEntities = new EntityReferenceCollection
                        {
                            new EntityReference("role", id)
                        },
                        Relationship = new Relationship("systemuserroles_association")
                    };
                }
                else
                {
                    disassociateRequest = new DisassociateRequest
                    {
                        Target = new EntityReference("team", userId),
                        RelatedEntities = new EntityReferenceCollection
                    {
                        new EntityReference("role", id)
                    },
                        Relationship = new Relationship("teamroles_association")
                    };
                }

                // Ejecutar la solicitud
                Service.Execute(disassociateRequest);
            }


        }

        private void tsbForceSyncUser_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            string entraID = string.Empty;
            if (form.ShowDialog() == DialogResult.OK)
            {
                entraID = form.EntraID;
                ExecuteForceSync(entraID);
            }
        }
        private void ExecuteForceSync(string entraID)
        {
            var callerObject = ((CrmServiceClient)Service).CallerAADObjectId;
            ((CrmServiceClient)Service).CallerAADObjectId = new Guid(entraID);
            WhoAmIRequest request = new WhoAmIRequest();
            Service.Execute(request);
            ((CrmServiceClient)Service).CallerAADObjectId = callerObject;
            ExecuteMethod(GetUsers);
        }
    }
}