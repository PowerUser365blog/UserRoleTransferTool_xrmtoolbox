namespace UserRoleTransferTool
{
    partial class UserRoleTransferToolControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRoleTransferToolControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbLoadUsers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbTransfer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbForceSyncUser = new System.Windows.Forms.ToolStripButton();
            this.gbSourceUser = new System.Windows.Forms.GroupBox();
            this.lbSearch1 = new System.Windows.Forms.Label();
            this.txtUserTeamFilter = new System.Windows.Forms.TextBox();
            this.lvSourceUser = new System.Windows.Forms.ListView();
            this.displayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbRoles = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoleFilter = new System.Windows.Forms.TextBox();
            this.lvRolesSource = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbDestinationUser = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserTeamFilter2 = new System.Windows.Forms.TextBox();
            this.lvDestinationUser = new System.Windows.Forms.ListView();
            this.displayName2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logicalName2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordType2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripMenu.SuspendLayout();
            this.gbSourceUser.SuspendLayout();
            this.gbRoles.SuspendLayout();
            this.gbDestinationUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadUsers,
            this.toolStripSeparator1,
            this.tsbAdd,
            this.tsbTransfer,
            this.toolStripSeparator2,
            this.tsbForceSyncUser});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1894, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbLoadUsers
            // 
            this.tsbLoadUsers.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadUsers.Image")));
            this.tsbLoadUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadUsers.Name = "tsbLoadUsers";
            this.tsbLoadUsers.Size = new System.Drawing.Size(109, 28);
            this.tsbLoadUsers.Text = "Load Users";
            this.tsbLoadUsers.Click += new System.EventHandler(this.tsbLoadUsers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::UserRoleTransferTool.Properties.Resources.add_insert_new_plus_button_icon_142943__2_;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(101, 28);
            this.tsbAdd.Text = "Add roles";
            this.tsbAdd.ToolTipText = "Adds the source user\'s roles to the roles that the target user already has";
            this.tsbAdd.Enabled = false;
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbTransfer
            // 
            this.tsbTransfer.Image = ((System.Drawing.Image)(resources.GetObject("tsbTransfer.Image")));
            this.tsbTransfer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransfer.Name = "tsbTransfer";
            this.tsbTransfer.Size = new System.Drawing.Size(125, 28);
            this.tsbTransfer.Text = "Transfer roles";
            this.tsbTransfer.ToolTipText = "Equalize the roles of the source and destination user";
            this.tsbTransfer.Click += new System.EventHandler(this.tsbTransfer_Click);
            this.tsbTransfer.Enabled = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbForceSyncUser
            // 
            this.tsbForceSyncUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbForceSyncUser.Image")));
            this.tsbForceSyncUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForceSyncUser.Name = "tsbForceSyncUser";
            this.tsbForceSyncUser.Size = new System.Drawing.Size(157, 28);
            this.tsbForceSyncUser.Text = "Sync Entra ID User";
            this.tsbForceSyncUser.Click += new System.EventHandler(this.tsbForceSyncUser_Click);
            // 
            // gbSourceUser
            // 
            this.gbSourceUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSourceUser.Controls.Add(this.lbSearch1);
            this.gbSourceUser.Controls.Add(this.txtUserTeamFilter);
            this.gbSourceUser.Controls.Add(this.lvSourceUser);
            this.gbSourceUser.Location = new System.Drawing.Point(20, 45);
            this.gbSourceUser.Name = "gbSourceUser";
            this.gbSourceUser.Size = new System.Drawing.Size(614, 543);
            this.gbSourceUser.TabIndex = 5;
            this.gbSourceUser.TabStop = false;
            this.gbSourceUser.Text = "Source User or Team";
            // 
            // lbSearch1
            // 
            this.lbSearch1.AutoSize = true;
            this.lbSearch1.Location = new System.Drawing.Point(26, 40);
            this.lbSearch1.Name = "lbSearch1";
            this.lbSearch1.Size = new System.Drawing.Size(50, 16);
            this.lbSearch1.TabIndex = 6;
            this.lbSearch1.Text = "Search";
            // 
            // txtUserTeamFilter
            // 
            this.txtUserTeamFilter.Location = new System.Drawing.Point(107, 37);
            this.txtUserTeamFilter.Name = "txtUserTeamFilter";
            this.txtUserTeamFilter.Size = new System.Drawing.Size(431, 22);
            this.txtUserTeamFilter.TabIndex = 6;
            this.txtUserTeamFilter.TextChanged += new System.EventHandler(this.txtUserTeamFilter_TextChanged);
            // 
            // lvSourceUser
            // 
            this.lvSourceUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSourceUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.displayName,
            this.logicalName,
            this.recordType});
            this.lvSourceUser.FullRowSelect = true;
            this.lvSourceUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSourceUser.HideSelection = false;
            this.lvSourceUser.Location = new System.Drawing.Point(29, 83);
            this.lvSourceUser.MultiSelect = false;
            this.lvSourceUser.Name = "lvSourceUser";
            this.lvSourceUser.Size = new System.Drawing.Size(559, 432);
            this.lvSourceUser.TabIndex = 6;
            this.lvSourceUser.UseCompatibleStateImageBehavior = false;
            this.lvSourceUser.View = System.Windows.Forms.View.Details;
            this.lvSourceUser.SelectedIndexChanged += new System.EventHandler(this.lvSourceUser_SelectedIndexChanged);
            // 
            // displayName
            // 
            this.displayName.Text = "Display Name";
            this.displayName.Width = 170;
            // 
            // logicalName
            // 
            this.logicalName.Text = "Logical Name";
            this.logicalName.Width = 170;
            // 
            // recordType
            // 
            this.recordType.Text = "Type";
            this.recordType.Width = 70;
            // 
            // gbRoles
            // 
            this.gbRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbRoles.Controls.Add(this.label1);
            this.gbRoles.Controls.Add(this.txtRoleFilter);
            this.gbRoles.Controls.Add(this.lvRolesSource);
            this.gbRoles.Location = new System.Drawing.Point(644, 45);
            this.gbRoles.Name = "gbRoles";
            this.gbRoles.Size = new System.Drawing.Size(603, 543);
            this.gbRoles.TabIndex = 6;
            this.gbRoles.TabStop = false;
            this.gbRoles.Text = "Roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search";
            // 
            // txtRoleFilter
            // 
            this.txtRoleFilter.Location = new System.Drawing.Point(122, 40);
            this.txtRoleFilter.Name = "txtRoleFilter";
            this.txtRoleFilter.Size = new System.Drawing.Size(394, 22);
            this.txtRoleFilter.TabIndex = 7;
            this.txtRoleFilter.TextChanged += new System.EventHandler(this.txtRoleFilter_TextChanged);
            // 
            // lvRolesSource
            // 
            this.lvRolesSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvRolesSource.CheckBoxes = true;
            this.lvRolesSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name});
            this.lvRolesSource.FullRowSelect = true;
            this.lvRolesSource.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRolesSource.HideSelection = false;
            this.lvRolesSource.Location = new System.Drawing.Point(29, 83);
            this.lvRolesSource.MultiSelect = false;
            this.lvRolesSource.Name = "lvRolesSource";
            this.lvRolesSource.Size = new System.Drawing.Size(551, 432);
            this.lvRolesSource.TabIndex = 7;
            this.lvRolesSource.UseCompatibleStateImageBehavior = false;
            this.lvRolesSource.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Role Name";
            this.name.Width = 450;
            // 
            // gbDestinationUser
            // 
            this.gbDestinationUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDestinationUser.Controls.Add(this.label2);
            this.gbDestinationUser.Controls.Add(this.txtUserTeamFilter2);
            this.gbDestinationUser.Controls.Add(this.lvDestinationUser);
            this.gbDestinationUser.Location = new System.Drawing.Point(1274, 46);
            this.gbDestinationUser.Name = "gbDestinationUser";
            this.gbDestinationUser.Size = new System.Drawing.Size(603, 542);
            this.gbDestinationUser.TabIndex = 7;
            this.gbDestinationUser.TabStop = false;
            this.gbDestinationUser.Text = "Destination User or Team";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search";
            // 
            // txtUserTeamFilter2
            // 
            this.txtUserTeamFilter2.Location = new System.Drawing.Point(144, 35);
            this.txtUserTeamFilter2.Name = "txtUserTeamFilter2";
            this.txtUserTeamFilter2.Size = new System.Drawing.Size(414, 22);
            this.txtUserTeamFilter2.TabIndex = 8;
            this.txtUserTeamFilter2.TextChanged += new System.EventHandler(this.txtUserTeamFilter2_TextChanged);
            // 
            // lvDestinationUser
            // 
            this.lvDestinationUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvDestinationUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.displayName2,
            this.logicalName2,
            this.recordType2});
            this.lvDestinationUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvDestinationUser.FullRowSelect = true;
            this.lvDestinationUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDestinationUser.HideSelection = false;
            this.lvDestinationUser.Location = new System.Drawing.Point(29, 82);
            this.lvDestinationUser.MultiSelect = false;
            this.lvDestinationUser.Name = "lvDestinationUser";
            this.lvDestinationUser.Size = new System.Drawing.Size(549, 432);
            this.lvDestinationUser.TabIndex = 0;
            this.lvDestinationUser.UseCompatibleStateImageBehavior = false;
            this.lvDestinationUser.View = System.Windows.Forms.View.Details;
            // 
            // displayName2
            // 
            this.displayName2.Text = "Display Name";
            this.displayName2.Width = 160;
            // 
            // logicalName2
            // 
            this.logicalName2.Text = "Logical Name";
            this.logicalName2.Width = 170;
            // 
            // recordType2
            // 
            this.recordType2.Text = "Type";
            this.recordType2.Width = 70;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.gbDestinationUser);
            this.Controls.Add(this.gbRoles);
            this.Controls.Add(this.gbSourceUser);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1894, 602);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gbSourceUser.ResumeLayout(false);
            this.gbSourceUser.PerformLayout();
            this.gbRoles.ResumeLayout(false);
            this.gbRoles.PerformLayout();
            this.gbDestinationUser.ResumeLayout(false);
            this.gbDestinationUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.GroupBox gbSourceUser;
        private System.Windows.Forms.Label lbSearch1;
        private System.Windows.Forms.TextBox txtUserTeamFilter;
        private System.Windows.Forms.ListView lvSourceUser;
        private System.Windows.Forms.GroupBox gbRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoleFilter;
        private System.Windows.Forms.ListView lvRolesSource;
        private System.Windows.Forms.GroupBox gbDestinationUser;
        private System.Windows.Forms.ToolStripButton tsbLoadUsers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbTransfer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbForceSyncUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserTeamFilter2;
        private System.Windows.Forms.ListView lvDestinationUser;
        private System.Windows.Forms.ColumnHeader displayName;
        private System.Windows.Forms.ColumnHeader logicalName;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader recordType;
        private System.Windows.Forms.ColumnHeader displayName2;
        private System.Windows.Forms.ColumnHeader logicalName2;
        private System.Windows.Forms.ColumnHeader recordType2;
        private System.Windows.Forms.ToolStripButton tsbAdd;
    }
}
