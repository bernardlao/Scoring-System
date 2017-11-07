using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClassCollection;

namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    public partial class frmApplyScore : Form
    {
        struct Scoring
        {
            public string judgeID;
            public string contestantID;
            public string criteriaID;
            public double percentage;
            public double rawScore;
            public double averageScore;
            public bool isUpdated;

            public Label lblcriteriaName;
            public TextBox txtJudgeRawScore;
            public Label lblJudgeAverageScore;
        }

        InteractionAddOns ia = new InteractionAddOns();
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        List<Scoring> scores = new List<Scoring>();
        private bool isOnUpdate = false;
        public string cid;
        public string jid;
        int locx = 15;
        int locy = 30;
        const int padx = 15;
        const int pady = 15;

        public frmApplyScore()
        {
            InitializeComponent();
        }

        private void frmApplyScore_Load(object sender, EventArgs e)
        {
            mnsHeader.MouseDown += new MouseEventHandler(frm_MouseDown);
            mnsHeader.MouseMove += new MouseEventHandler(frm_MouseMove);
            mnsHeader.MouseUp += new MouseEventHandler(frm_MouseUp);
            LoadForm();
        }
        private void frm_MouseDown(object sender, MouseEventArgs e)
        {
            ia.FormDrag(ref sender, ref e, MousePosition, this.Location);
        }
        private void frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (ia.isMoving)
            {
                this.Location = ia.FormMove(ref sender, ref e, MousePosition);
            }
        }
        private void frm_MouseUp(object sender, MouseEventArgs e)
        {
            ia.FormDrop(ref sender, ref e);
        }
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadForm()
        {
            DataTable det = db.SelectTable("SELECT * FROM tblcontestant WHERE contestantid=" + cid);
            if (det.Rows.Count != 0)
            {
                DataRow r = det.Rows[0];
                lblContestantName.Text = r["fullname"].ToString();
                picDP.Image = hm.GetCopyImage(r["photopath"].ToString());
                lblContestantNo.Text += r["contestantno"].ToString();
                lblRemarks.Text = r["remarks"].ToString();
            }
            jid = db.GetID("SELECT judgeid FROM tbluser WHERE userid =" + frmLogin.userid, "judgeid").ToString();
            DataTable dt = db.SelectTable("SELECT * FROM tblscoring s INNER JOIN tblcriteria c ON"+
                " s.criteriaid = c.criteriaid WHERE contestantid = " + cid + " AND judgeid= " + jid);
            if (dt.Rows.Count != 0)
                SetDetails(dt);
            else
            {
                SetDetails();
                frmScoring.isScored = true;
            }
        }
        private void SetDetails(DataTable dt) 
        {
            isOnUpdate = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dt.Rows[i];

                Scoring score = new Scoring();
                score.judgeID = jid;
                score.contestantID = cid;
                score.criteriaID = r["criteriaid"].ToString();
                score.percentage = Convert.ToDouble(r["percentage"].ToString()) / 100;
                score.rawScore = Convert.ToDouble(r["score"].ToString());
                score.averageScore = Convert.ToDouble(r["criteriaaverage"].ToString());
                score.isUpdated = false;

                Label lblCritName = CreateLabel(locx, locy, new Size(190, 27), r["criterianame"].ToString());
                locx += padx + 190;

                TextBox txtScore = CreateTextBox(locx, locy, new Size(40, 27), i.ToString());
                txtScore.TextAlign = HorizontalAlignment.Right;
                txtScore.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                txtScore.TextChanged += new EventHandler(txt_TextChanged);
                locx += padx + 40;

                Label lblaverage = CreateLabel(locx, locy, new Size(70, 27), score.averageScore.ToString());
                lblaverage.TextAlign = ContentAlignment.TopRight;

                score.lblcriteriaName = lblCritName;
                score.txtJudgeRawScore = txtScore;
                score.lblJudgeAverageScore = lblaverage;
                pnlScorer.Controls.Add(score.lblcriteriaName);
                pnlScorer.Controls.Add(score.txtJudgeRawScore);
                pnlScorer.Controls.Add(score.lblJudgeAverageScore);

                locx = padx;
                locy += pady + 27;

                scores.Add(score);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dt.Rows[i];
                Scoring s = scores[i];
                s.txtJudgeRawScore.Text = r["score"].ToString();
                s.isUpdated = false;
                scores[i] = s;
            }
        }
        private void SetDetails() 
        {
            isOnUpdate = false;
            DataTable dt = db.SelectTable("SELECT * FROM tblcriteria");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dt.Rows[i];
                Scoring score = new Scoring();
                score.judgeID = jid;
                score.contestantID = cid;
                score.criteriaID = r["criteriaid"].ToString();
                score.percentage = Convert.ToDouble(r["percentage"].ToString()) / 100;
                score.rawScore = 0;
                score.averageScore = 0;
                score.isUpdated = false;

                Label lblCritName = CreateLabel(locx, locy, new Size(190, 27), r["criterianame"].ToString());
                locx += padx + 190;

                TextBox txtScore = CreateTextBox(locx, locy, new Size(40, 27),i.ToString());
                txtScore.TextAlign = HorizontalAlignment.Right;
                txtScore.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                txtScore.TextChanged += new EventHandler(txt_TextChanged);
                locx += padx + 40;

                Label lblaverage = CreateLabel(locx, locy, new Size(70, 27), score.averageScore.ToString());
                lblaverage.TextAlign = ContentAlignment.TopRight;

                score.lblcriteriaName = lblCritName;
                score.txtJudgeRawScore = txtScore;
                score.lblJudgeAverageScore = lblaverage;
                pnlScorer.Controls.Add(score.lblcriteriaName);
                pnlScorer.Controls.Add(score.txtJudgeRawScore);
                pnlScorer.Controls.Add(score.lblJudgeAverageScore);

                locx = padx;
                locy += pady + 27;

                scores.Add(score);
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.LimitTo(ref sender, ref e, 100.00);
            hm.DecimalHandle(ref sender, ref e);
        }
       
        private void txt_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            int x = Convert.ToInt32(t.Name);
            Scoring s = scores[x];
            if (!t.Text.Equals("") && !t.Text.Equals("."))
            {
                s.lblJudgeAverageScore.Text = (s.percentage * Convert.ToDouble(t.Text)).ToString();
                s.rawScore = Convert.ToDouble(t.Text);
                s.averageScore = Convert.ToDouble(s.lblJudgeAverageScore.Text);
            }
            else
            {
                s.lblJudgeAverageScore.Text = "0";
                s.rawScore = 0;
                s.averageScore = 0;
            }
            s.isUpdated = true;
            scores[x] = s;
        }
        public Label CreateLabel(int x, int y, Size s, string text)
        {
            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.Size = s;
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 11.25F);
            return lbl;
        }
        public TextBox CreateTextBox(int x, int y, Size s,string name)
        {
            TextBox txt = new TextBox();
            txt.Location = new Point(x, y);
            txt.Size = s;
            txt.Font = new Font("Segoe UI", 11.25F);
            txt.Name = name;
            return txt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Proceed with this scores?",
                "Save Scores", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (isOnUpdate)
                    UpdateScore();
                else
                    InsertScore();
                frmScoring.isScored = true;
                this.Close();
            }
        }
        private void UpdateScore() 
        {
            List<string> queries = new List<string>();
            for (int i = 0; i < scores.Count; i++)
            {
                Scoring s = scores[i];
                
                if (s.isUpdated)
                {
                    string temp = "UPDATE tblscoring SET score=" +
                        s.rawScore + ", criteriaaverage=" + 
                        s.averageScore + " WHERE contestantid =" +
                        s.contestantID + " AND criteriaid=" +
                        s.criteriaID + " AND judgeid=" + 
                        s.judgeID;
                    queries.Add(temp);
                }
            }
            db.InsertMultiple(queries);
        }
        private void InsertScore() 
        {
            List<string> queries = new List<string>();
            for (int i = 0; i < scores.Count; i++)
            {
                Scoring s = scores[i];
                string temp = "INSERT INTO tblscoring (judgeid, criteriaid, contestantid, score, criteriaaverage)" +
                    " VALUES(" + s.judgeID + "," + s.criteriaID + "," + s.contestantID + "," + s.rawScore + "," +
                    s.averageScore + ")";
                queries.Add(temp);
            }
            db.InsertMultiple(queries);
        }
    }
}
