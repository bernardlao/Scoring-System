namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnsHeader = new System.Windows.Forms.MenuStrip();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditJudge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContestant = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContestantAddEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContestantDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageCriteria = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartScoring = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowTally = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFinalizeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSubmitAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tmPrivelegeSetter = new System.Windows.Forms.Timer(this.components);
            this.mnsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsHeader
            // 
            this.mnsHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mnsHeader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout,
            this.menuManageUser,
            this.menuContestant,
            this.menuManageCriteria,
            this.menuStartScoring,
            this.menuShowTally,
            this.menuFinalizeSettings,
            this.menuSubmitAll});
            this.mnsHeader.Location = new System.Drawing.Point(0, 0);
            this.mnsHeader.Name = "mnsHeader";
            this.mnsHeader.Size = new System.Drawing.Size(1066, 26);
            this.mnsHeader.TabIndex = 4;
            this.mnsHeader.Text = "menuStrip1";
            // 
            // menuLogout
            // 
            this.menuLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuLogout.ForeColor = System.Drawing.SystemColors.Control;
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(62, 22);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuManageUser
            // 
            this.menuManageUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddUser,
            this.menuEditJudge,
            this.menuChangePass});
            this.menuManageUser.ForeColor = System.Drawing.SystemColors.Control;
            this.menuManageUser.Name = "menuManageUser";
            this.menuManageUser.Size = new System.Drawing.Size(108, 22);
            this.menuManageUser.Text = "Manage Users";
            // 
            // menuAddUser
            // 
            this.menuAddUser.Name = "menuAddUser";
            this.menuAddUser.Size = new System.Drawing.Size(186, 22);
            this.menuAddUser.Text = "Add User Account";
            this.menuAddUser.Click += new System.EventHandler(this.menuAddUser_Click);
            // 
            // menuEditJudge
            // 
            this.menuEditJudge.Name = "menuEditJudge";
            this.menuEditJudge.Size = new System.Drawing.Size(186, 22);
            this.menuEditJudge.Text = "Edit Judge";
            this.menuEditJudge.Click += new System.EventHandler(this.menuEditJudge_Click);
            // 
            // menuChangePass
            // 
            this.menuChangePass.Name = "menuChangePass";
            this.menuChangePass.Size = new System.Drawing.Size(186, 22);
            this.menuChangePass.Text = "Change Password";
            this.menuChangePass.Click += new System.EventHandler(this.menuChangePass_Click);
            // 
            // menuContestant
            // 
            this.menuContestant.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuContestantAddEdit,
            this.menuContestantDelete});
            this.menuContestant.ForeColor = System.Drawing.SystemColors.Control;
            this.menuContestant.Name = "menuContestant";
            this.menuContestant.Size = new System.Drawing.Size(147, 22);
            this.menuContestant.Text = "Manage Contestants";
            // 
            // menuContestantAddEdit
            // 
            this.menuContestantAddEdit.Name = "menuContestantAddEdit";
            this.menuContestantAddEdit.Size = new System.Drawing.Size(202, 22);
            this.menuContestantAddEdit.Text = "Add/Edit Contestant";
            this.menuContestantAddEdit.Click += new System.EventHandler(this.menuContestantAddEdit_Click);
            // 
            // menuContestantDelete
            // 
            this.menuContestantDelete.Name = "menuContestantDelete";
            this.menuContestantDelete.Size = new System.Drawing.Size(202, 22);
            this.menuContestantDelete.Text = "Delete Contestant";
            this.menuContestantDelete.Click += new System.EventHandler(this.menuContestantDelete_Click);
            // 
            // menuManageCriteria
            // 
            this.menuManageCriteria.ForeColor = System.Drawing.SystemColors.Control;
            this.menuManageCriteria.Name = "menuManageCriteria";
            this.menuManageCriteria.Size = new System.Drawing.Size(119, 22);
            this.menuManageCriteria.Text = "Manage Criteria";
            this.menuManageCriteria.Click += new System.EventHandler(this.menuManageCriteria_Click);
            // 
            // menuStartScoring
            // 
            this.menuStartScoring.ForeColor = System.Drawing.SystemColors.Control;
            this.menuStartScoring.Name = "menuStartScoring";
            this.menuStartScoring.Size = new System.Drawing.Size(97, 22);
            this.menuStartScoring.Text = "Start Scoring";
            this.menuStartScoring.Click += new System.EventHandler(this.menuStartScoring_Click);
            // 
            // menuShowTally
            // 
            this.menuShowTally.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuShowTally.ForeColor = System.Drawing.SystemColors.Control;
            this.menuShowTally.Name = "menuShowTally";
            this.menuShowTally.Size = new System.Drawing.Size(85, 22);
            this.menuShowTally.Text = "Show Tally";
            this.menuShowTally.Click += new System.EventHandler(this.menuShowTally_Click);
            // 
            // menuFinalizeSettings
            // 
            this.menuFinalizeSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuFinalizeSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.menuFinalizeSettings.Name = "menuFinalizeSettings";
            this.menuFinalizeSettings.Size = new System.Drawing.Size(120, 22);
            this.menuFinalizeSettings.Text = "Finalize Settings";
            this.menuFinalizeSettings.Click += new System.EventHandler(this.menuFinalizeSettings_Click);
            // 
            // menuSubmitAll
            // 
            this.menuSubmitAll.ForeColor = System.Drawing.SystemColors.Control;
            this.menuSubmitAll.Name = "menuSubmitAll";
            this.menuSubmitAll.Size = new System.Drawing.Size(127, 22);
            this.menuSubmitAll.Text = "Submit All Scores";
            this.menuSubmitAll.Click += new System.EventHandler(this.menuSubmitAll_Click);
            // 
            // tmPrivelegeSetter
            // 
            this.tmPrivelegeSetter.Enabled = true;
            this.tmPrivelegeSetter.Tick += new System.EventHandler(this.tmPrivelegeSetter_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 589);
            this.Controls.Add(this.mnsHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Parent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnsHeader.ResumeLayout(false);
            this.mnsHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip mnsHeader;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuManageUser;
        private System.Windows.Forms.ToolStripMenuItem menuAddUser;
        private System.Windows.Forms.ToolStripMenuItem menuEditJudge;
        private System.Windows.Forms.Timer tmPrivelegeSetter;
        private System.Windows.Forms.ToolStripMenuItem menuChangePass;
        private System.Windows.Forms.ToolStripMenuItem menuContestant;
        private System.Windows.Forms.ToolStripMenuItem menuContestantAddEdit;
        private System.Windows.Forms.ToolStripMenuItem menuContestantDelete;
        private System.Windows.Forms.ToolStripMenuItem menuManageCriteria;
        private System.Windows.Forms.ToolStripMenuItem menuStartScoring;
        private System.Windows.Forms.ToolStripMenuItem menuShowTally;
        private System.Windows.Forms.ToolStripMenuItem menuFinalizeSettings;
        private System.Windows.Forms.ToolStripMenuItem menuSubmitAll;
    }
}



