namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    partial class frmDeleteContestant
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
            this.label1 = new System.Windows.Forms.Label();
            this.mnsHeader = new System.Windows.Forms.MenuStrip();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lstContestants = new System.Windows.Forms.ListView();
            this.clid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.mnsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Contestant Deletion";
            // 
            // mnsHeader
            // 
            this.mnsHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mnsHeader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.mnsHeader.Location = new System.Drawing.Point(0, 0);
            this.mnsHeader.Name = "mnsHeader";
            this.mnsHeader.Size = new System.Drawing.Size(556, 26);
            this.mnsHeader.TabIndex = 4;
            this.mnsHeader.Text = "menuStrip1";
            // 
            // menuExit
            // 
            this.menuExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuExit.ForeColor = System.Drawing.SystemColors.Control;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(28, 22);
            this.menuExit.Text = "X";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // lstContestants
            // 
            this.lstContestants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clid,
            this.clNo,
            this.clName,
            this.clRemarks});
            this.lstContestants.FullRowSelect = true;
            this.lstContestants.GridLines = true;
            this.lstContestants.Location = new System.Drawing.Point(26, 52);
            this.lstContestants.Name = "lstContestants";
            this.lstContestants.Size = new System.Drawing.Size(503, 375);
            this.lstContestants.TabIndex = 6;
            this.lstContestants.UseCompatibleStateImageBehavior = false;
            this.lstContestants.View = System.Windows.Forms.View.Details;
            this.lstContestants.Click += new System.EventHandler(this.lstContestants_Click);
            // 
            // clid
            // 
            this.clid.Width = 0;
            // 
            // clNo
            // 
            this.clNo.Text = "C#";
            this.clNo.Width = 40;
            // 
            // clName
            // 
            this.clName.Text = "Fullname";
            this.clName.Width = 200;
            // 
            // clRemarks
            // 
            this.clRemarks.Text = "Remarks";
            this.clRemarks.Width = 230;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(223, 433);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 36);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmDeleteContestant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 481);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstContestants);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnsHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDeleteContestant";
            this.Text = "DeleteContestant";
            this.Load += new System.EventHandler(this.DeleteContestant_Load);
            this.mnsHeader.ResumeLayout(false);
            this.mnsHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnsHeader;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ListView lstContestants;
        private System.Windows.Forms.ColumnHeader clid;
        private System.Windows.Forms.ColumnHeader clNo;
        private System.Windows.Forms.ColumnHeader clName;
        private System.Windows.Forms.ColumnHeader clRemarks;
        private System.Windows.Forms.Button btnDelete;
    }
}