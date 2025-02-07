using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UserRoleTransferTool.Helpers
{
    public class GetRoles
    {
        public List<Entity> RetrieveRoles(IOrganizationService service, string entityLogicalName, BackgroundWorker worker = null)
        {
            var roles = new List<Entity>();

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Retrieve roles " + entityLogicalName);
            }

            string fetchXml = @"<fetch>
                                  <entity name='role'>
                                    <attribute name='roleid' />
                                    <attribute name='name' />
                                    <attribute name='businessunitid' />
                                  </entity>
                                </fetch>";

            EntityCollection rolesCollection = service.RetrieveMultiple(new FetchExpression(fetchXml));
            List<Entity> uniqueRoles = rolesCollection.Entities
                                        .GroupBy(role => role.GetAttributeValue<string>("name"))
                                        .Select(g => g.First())
                                        .ToList();

            return uniqueRoles;
        }

        public List<Entity> RetrieveRolesByUser(IOrganizationService service, string entityLogicalName, Guid userid, BackgroundWorker worker = null)
        {
            var rolesByUser = new List<Entity>();

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Retrieve roles by user" + entityLogicalName);
            }

            // Crear una consulta para obtener los roles del usuario especificado
            var query = new QueryExpression("systemuserroles")
            {
                ColumnSet = new ColumnSet("roleid"),
                Criteria = new FilterExpression
                {
                    Conditions =
            {
                new ConditionExpression("systemuserid", ConditionOperator.Equal, userid)
            }
                },
                LinkEntities =
        {
            new LinkEntity("systemuserroles", "role", "roleid", "roleid", JoinOperator.Inner)
            {
                Columns = new ColumnSet("roleid", "name"),
                EntityAlias = "role"
            }
        }
            };

            var rolesList = service.RetrieveMultiple(query);
            rolesByUser.AddRange(rolesList.Entities);
            return rolesByUser;
        }

        public List<Entity> RetrieveRolesByTeam(IOrganizationService service, string entityLogicalName, Guid teamId, BackgroundWorker worker = null)
        {
            var rolesByTeam = new List<Entity>();

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Retrieve roles by team " + entityLogicalName);
            }

            // Crear una consulta para obtener los roles del equipo especificado
            var query = new QueryExpression("teamroles")
            {
                ColumnSet = new ColumnSet("roleid"),
                Criteria = new FilterExpression
                {
                    Conditions =
            {
                new ConditionExpression("teamid", ConditionOperator.Equal, teamId)
            }
                },
                LinkEntities =
        {
            new LinkEntity("teamroles", "role", "roleid", "roleid", JoinOperator.Inner)
            {
                Columns = new ColumnSet("roleid", "name"),
                EntityAlias = "role"
            }
        }
            };

            var rolesList = service.RetrieveMultiple(query);
            rolesByTeam.AddRange(rolesList.Entities);
            return rolesByTeam;
        }

    }
}
