namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    partial class frmApplyScore
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
            this.picDP = new System.Windows.Forms.PictureBox();
            this.lblContestantName = new System.Windows.Forms.Label();
            this.lblContestantNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.pnlScorer = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mnsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Score Manager";
            // 
            // mnsHeader
            // 
            this.mnsHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mnsHeader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.mnsHeader.Location = new System.Drawing.Point(0, 0);
            this.mnsHeader.Name = "mnsHeader";
            this.mnsHeader.Size = new System.Drawing.Size(734, 26);
            this.mnsHeader.TabIndex = 10;
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
            // picDP
            // 
            this.picDP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picDP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDP.ImageLocation = "";
            this.picDP.InitialImage = null;
            this.picDP.Location = new System.Drawing.Point(35, 112);
            this.picDP.Name = "picDP";
            this.picDP.Size = new System.Drawing.Size(301, 283);
            this.picDP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDP.TabIndex = 27;
            this.picDP.TabStop = false;
            // 
            // lblContestantName
            // 
            this.lblContestantName.AutoSize = true;
            this.lblContestantName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContestantName.Location = new System.Drawing.Point(31, 38);
            this.lblContestantName.Name = "lblContestantName";
            this.lblContestantName.Size = new System.Drawing.Size(88, 20);
            this.lblContestantName.TabIndex = 28;
            this.lblContestantName.Text = "Name Here";
            // 
            // lblContestantNo
            // 
            this.lblContestantNo.AutoSize = true;
            this.lblContestantNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContestantNo.Location = new System.Drawing.Point(31, 72);
            this.lblContestantNo.Name = "lblContestantNo";
            this.lblContestantNo.Size = new System.Drawing.Size(115, 20);
            this.lblContestantNo.TabIndex = 29;
            this.lblContestantNo.Text = "Contestant No : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Details:";
            // 
            // lblRemarks
            // 
            this.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemarks.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(31, 434);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(305, 108);
            this.lblRemarks.TabIndex = 31;
            this.lblRemarks.Text = "Details";
            // 
            // pnlScorer
            // 
            this.pnlScorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScorer.AutoScroll = true;
            this.pnlScorer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScorer.Location = new System.Drawing.Point(354, 112);
            this.pnlScorer.Name = "pnlScorer";
            this.pnlScorer.Size = new System.Drawing.Size(358, 382);
            this.pnlScorer.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(430, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 25);
            this.label3.TabIndex = 33;
            this.label3.Text = "Enter your score here";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(354, 506);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(358, 36);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Submit Your Score";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Criteria Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(677, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Avg";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(561, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Your Score";
            // 
            // frmApplyScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlScorer);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblContestantNo);
            this.Controls.Add(this.lblContestantName);
            this.Controls.Add(this.picDP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnsHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmApplyScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApplyScore";
            this.Load += new System.EventHandler(this.frmApplyScore_Load);
            this.mnsHeader.ResumeLayout(false);
            this.mnsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnsHeader;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.PictureBox picDP;
        private System.Windows.Forms.Label lblContestantName;
        private System.Windows.Forms.Label lblContestantNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Panel pnlScorer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}