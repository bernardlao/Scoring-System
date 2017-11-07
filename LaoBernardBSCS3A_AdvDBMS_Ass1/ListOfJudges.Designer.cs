namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    partial class frmListOfJudges
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
            this.lstJudges = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clfullname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clremarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProceed = new System.Windows.Forms.Button();
            this.mnsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose a Judge";
            // 
            // mnsHeader
            // 
            this.mnsHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mnsHeader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.mnsHeader.Location = new System.Drawing.Point(0, 0);
            this.mnsHeader.Name = "mnsHeader";
            this.mnsHeader.Size = new System.Drawing.Size(470, 26);
            this.mnsHeader.TabIndex = 6;
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
            // lstJudges
            // 
            this.lstJudges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.clfullname,
            this.clremarks});
            this.lstJudges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstJudges.FullRowSelect = true;
            this.lstJudges.GridLines = true;
            this.lstJudges.Location = new System.Drawing.Point(28, 53);
            this.lstJudges.Name = "lstJudges";
            this.lstJudges.Size = new System.Drawing.Size(411, 386);
            this.lstJudges.TabIndex = 8;
            this.lstJudges.UseCompatibleStateImageBehavior = false;
            this.lstJudges.View = System.Windows.Forms.View.Details;
            this.lstJudges.Click += new System.EventHandler(this.lstJudges_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // clfullname
            // 
            this.clfullname.Text = "Fullname";
            this.clfullname.Width = 180;
            // 
            // clremarks
            // 
            this.clremarks.Text = "Remarks";
            this.clremarks.Width = 210;
            // 
            // btnProceed
            // 
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.Location = new System.Drawing.Point(165, 450);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(131, 36);
            this.btnProceed.TabIndex = 22;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // frmListOfJudges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 498);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.lstJudges);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnsHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListOfJudges";
            this.Text = "ListOfJudges";
            this.Load += new System.EventHandler(this.ListOfJudges_Load);
            this.mnsHeader.ResumeLayout(false);
            this.mnsHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnsHeader;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ListView lstJudges;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader clfullname;
        private System.Windows.Forms.ColumnHeader clremarks;
        private System.Windows.Forms.Button btnProceed;
    }
}