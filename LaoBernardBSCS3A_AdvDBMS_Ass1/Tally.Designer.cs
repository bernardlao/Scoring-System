namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    partial class frmTally
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbJudges = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.optByJudge = new System.Windows.Forms.RadioButton();
            this.optOverall = new System.Windows.Forms.RadioButton();
            this.lstScores = new System.Windows.Forms.ListView();
            this.chkViewTop = new System.Windows.Forms.CheckBox();
            this.cmbContestantCount = new System.Windows.Forms.ComboBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.mnsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Score Tally";
            // 
            // mnsHeader
            // 
            this.mnsHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mnsHeader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.mnsHeader.Location = new System.Drawing.Point(0, 0);
            this.mnsHeader.Name = "mnsHeader";
            this.mnsHeader.Size = new System.Drawing.Size(1030, 26);
            this.mnsHeader.TabIndex = 12;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Judge";
            // 
            // cmbJudges
            // 
            this.cmbJudges.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJudges.Enabled = false;
            this.cmbJudges.FormattingEnabled = true;
            this.cmbJudges.Location = new System.Drawing.Point(76, 37);
            this.cmbJudges.Name = "cmbJudges";
            this.cmbJudges.Size = new System.Drawing.Size(241, 28);
            this.cmbJudges.TabIndex = 15;
            // 
            // btnFilter
            // 
            this.btnFilter.Enabled = false;
            this.btnFilter.Location = new System.Drawing.Point(338, 36);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 28);
            this.btnFilter.TabIndex = 16;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // optByJudge
            // 
            this.optByJudge.AutoSize = true;
            this.optByJudge.Location = new System.Drawing.Point(441, 38);
            this.optByJudge.Name = "optByJudge";
            this.optByJudge.Size = new System.Drawing.Size(86, 24);
            this.optByJudge.TabIndex = 17;
            this.optByJudge.Text = "By Judge";
            this.optByJudge.UseVisualStyleBackColor = true;
            this.optByJudge.CheckedChanged += new System.EventHandler(this.optOverall_CheckedChanged);
            // 
            // optOverall
            // 
            this.optOverall.AutoSize = true;
            this.optOverall.Checked = true;
            this.optOverall.Location = new System.Drawing.Point(533, 38);
            this.optOverall.Name = "optOverall";
            this.optOverall.Size = new System.Drawing.Size(74, 24);
            this.optOverall.TabIndex = 18;
            this.optOverall.TabStop = true;
            this.optOverall.Text = "Overall";
            this.optOverall.UseVisualStyleBackColor = true;
            this.optOverall.CheckedChanged += new System.EventHandler(this.optOverall_CheckedChanged);
            // 
            // lstScores
            // 
            this.lstScores.FullRowSelect = true;
            this.lstScores.GridLines = true;
            this.lstScores.Location = new System.Drawing.Point(15, 90);
            this.lstScores.Name = "lstScores";
            this.lstScores.Size = new System.Drawing.Size(1000, 450);
            this.lstScores.TabIndex = 19;
            this.lstScores.UseCompatibleStateImageBehavior = false;
            this.lstScores.View = System.Windows.Forms.View.Details;
            // 
            // chkViewTop
            // 
            this.chkViewTop.AutoSize = true;
            this.chkViewTop.Location = new System.Drawing.Point(631, 39);
            this.chkViewTop.Name = "chkViewTop";
            this.chkViewTop.Size = new System.Drawing.Size(90, 24);
            this.chkViewTop.TabIndex = 20;
            this.chkViewTop.Text = "View Top";
            this.chkViewTop.UseVisualStyleBackColor = true;
            this.chkViewTop.CheckedChanged += new System.EventHandler(this.chkViewTop_CheckedChanged);
            // 
            // cmbContestantCount
            // 
            this.cmbContestantCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContestantCount.Enabled = false;
            this.cmbContestantCount.FormattingEnabled = true;
            this.cmbContestantCount.Location = new System.Drawing.Point(727, 37);
            this.cmbContestantCount.Name = "cmbContestantCount";
            this.cmbContestantCount.Size = new System.Drawing.Size(50, 28);
            this.cmbContestantCount.TabIndex = 21;
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(792, 36);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 28);
            this.btnCheck.TabIndex = 22;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(902, 36);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 29);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "Print Result";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmTally
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 555);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.cmbContestantCount);
            this.Controls.Add(this.chkViewTop);
            this.Controls.Add(this.lstScores);
            this.Controls.Add(this.optOverall);
            this.Controls.Add(this.optByJudge);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbJudges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnsHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTally";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tally";
            this.Load += new System.EventHandler(this.Tally_Load);
            this.mnsHeader.ResumeLayout(false);
            this.mnsHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnsHeader;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJudges;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.RadioButton optByJudge;
        private System.Windows.Forms.RadioButton optOverall;
        private System.Windows.Forms.ListView lstScores;
        private System.Windows.Forms.CheckBox chkViewTop;
        private System.Windows.Forms.ComboBox cmbContestantCount;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnPrint;
    }
}