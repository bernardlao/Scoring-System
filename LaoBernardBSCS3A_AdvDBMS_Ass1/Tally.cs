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
using MyExcelClass;

namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    public partial class frmTally : Form
    {
        MyExcel excel = new MyExcel();
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        List<Scoring> scores = new List<Scoring>();
        List<Criteria> criterias = new List<Criteria>();
        List<Contestant> contestants = new List<Contestant>();
        List<Judge> judges = new List<Judge>();

        public frmTally()
        {
            InitializeComponent();
        }

        private void Tally_Load(object sender, EventArgs e)
        {
            db.BindDataToComboBox("SELECT * FROM tbljudge;", cmbJudges, "judgeid", "fullname");
            PopulateClasses();
            frmMain.isAnyFormOpen = true;
            SetUpList();
            lstScores.Size = new Size(this.Size.Width - 30,this.Size.Height - 105);
            PopulateList();
            SetTop();
        }
        private void SetTop()
        {
            int x = contestants.Count;
            for (int i = 1; i <= x; i++)
            {
                cmbContestantCount.Items.Add(i.ToString());
            }
            cmbContestantCount.SelectedItem = cmbContestantCount.Items[0];
        }
        private void optOverall_CheckedChanged(object sender, EventArgs e)
        {
            if (optByJudge.Checked)
            {
                cmbJudges.Enabled = true;
                btnFilter.Enabled = true;
            }
            else
            {
                cmbJudges.Enabled = false;
                btnFilter.Enabled = false;
                PopulateList();
            }
            if (chkViewTop.Checked)
            {
                SetTopContestant(Convert.ToInt32(cmbContestantCount.SelectedItem.ToString()));
            }
        }
        
        private void menuExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                frmMain.isAnyFormOpen = false;
                this.Close();
            }
        }
        private void PopulateClasses()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblcriteria");
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    Criteria c = new Criteria(Convert.ToInt64(r["criteriaid"].ToString()),
                        r["criterianame"].ToString(),Convert.ToDouble(r["percentage"].ToString()));
                    criterias.Add(c);
                }
            }
            dt = db.SelectTable("SELECT * FROM tbljudge");
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    Judge j = new Judge(Convert.ToInt64(r["judgeid"].ToString()),
                        r["fullname"].ToString(),r["remarks"].ToString());
                    judges.Add(j);
                }
            }
            dt = db.SelectTable("SELECT * FROM tblcontestant");
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    Contestant c = new Contestant(Convert.ToInt64(r["contestantid"].ToString()),
                        r["fullname"].ToString(), @r["photopath"].ToString(), Convert.ToInt64(r["contestantno"].ToString()),
                        r["remarks"].ToString());
                    contestants.Add(c);
                }
            }
            dt = db.SelectTable("SELECT * FROM tblscoring");
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    Scoring s = new Scoring(Convert.ToInt64(r["scoringid"].ToString()), Convert.ToInt64(r["judgeid"].ToString()),
                        Convert.ToInt64(r["criteriaid"].ToString()), Convert.ToInt64(r["contestantid"].ToString()),
                        Convert.ToDouble(r["score"].ToString()), Convert.ToDouble(r["criteriaaverage"].ToString()));
                    scores.Add(s);
                }
            }
        }
        private void SetUpList()
        {
            int size = lstScores.Size.Width - 350;
            lstScores.Columns.Add("C#", 50);
            lstScores.Columns.Add("Contestant Name", 200);
            foreach(Criteria c in criterias)
            {
                lstScores.Columns.Add(c.CriteriaName + "(" + c.Percentage + "%)",(size/criterias.Count < 180?180:size/criterias.Count));
            }
            lstScores.Columns.Add("Total Score", 100);
        }
        private void PopulateList()
        {
            lstScores.Items.Clear();
            foreach (Contestant con in contestants)
            {
                double total = 0;
                ListViewItem itm = new ListViewItem(con.ContestantNo.ToString());
                itm.SubItems.Add(con.Fullname);
                foreach (Criteria c in criterias)
                {
                    total += Math.Round(GetScore(con.ContestantID, c.CriteriaID)/judges.Count,2);
                    itm.SubItems.Add(Math.Round(GetScore(con.ContestantID, c.CriteriaID) / judges.Count, 2).ToString());
                }
                itm.SubItems.Add(total.ToString());
                lstScores.Items.Add(itm);
            }
            lstScores.Sorting = SortOrder.Ascending;
            
        }
        private void PopulateList(long judgeID)
        {
            lstScores.Items.Clear();
            foreach (Contestant con in contestants)
            {
                double total = 0;
                ListViewItem itm = new ListViewItem(con.ContestantNo.ToString());
                itm.SubItems.Add(con.Fullname);
                foreach (Criteria c in criterias)
                {
                    total += Math.Round(GetScoreByJudge(con.ContestantID,c.CriteriaID,judgeID),2);
                    itm.SubItems.Add(Math.Round(GetScoreByJudge(con.ContestantID, c.CriteriaID, judgeID), 2).ToString());
                }
                itm.SubItems.Add(total.ToString());
                lstScores.Items.Add(itm);
            }
            lstScores.Sorting = SortOrder.Ascending;
        }
        private double GetScore(long contestantID, long criteriaID)
        {
            try
            {
                return scores.Where(s => s.ContestantID == contestantID &&
                    s.CriteriaID == criteriaID).Sum(s => s.CriteriaAverage);
            }
            catch
            {
                return 0;
            }
        }
        private double GetScoreByJudge(long contestantID, long criteriaID, long judgeID)
        {
            try
            {
                return scores.Where(s => s.ContestantID == contestantID &&
                    s.CriteriaID == criteriaID &&
                    s.JudgeID == judgeID).Select(s => s.CriteriaAverage).Single();
            }
            catch
            {
                return 0;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbJudges.SelectedValue.ToString());
            PopulateList(Convert.ToInt64(cmbJudges.SelectedValue.ToString()));
            if (chkViewTop.Checked)
            {
                SetTopContestant(Convert.ToInt32(cmbContestantCount.SelectedItem.ToString()));
            }
        }
        private void SetTopContestant(int top)
        {
            lstScores.Sorting = SortOrder.None;
            List<string> conNo = new List<string>();
            List<ListViewItem> itms = new List<ListViewItem>();
            Dictionary<string, double> dics = new Dictionary<string, double>();
            int colorCount = 0;
            foreach (ListViewItem itm in lstScores.Items)
            {
                dics.Add(itm.Text, Convert.ToDouble(itm.SubItems[itm.SubItems.Count - 1].Text));
                itms.Add(itm);
            }
            string[] cnos = dics.OrderByDescending(s => s.Value).Select(s => s.Key).ToArray();
            foreach (ListViewItem itm in lstScores.Items)
                itm.BackColor = SystemColors.Control;
            lstScores.Items.Clear();
            foreach (string s in cnos)
            {
                for (int i = 0; i < itms.Count; i++)
                {
                    if (itms[i].Text.Equals(s))
                    {
                        lstScores.Items.Add(itms[i]);
                    }
                }
            }
            int x = 0;
            for (int i = 0; i < lstScores.Items.Count; i++)
            {
                if ((i - 1) > -1)
                {
                    string oldText = lstScores.Items[i - 1].SubItems[lstScores.Items[i - 1].SubItems.Count - 1].Text;
                    string newText = lstScores.Items[i].SubItems[lstScores.Items[i].SubItems.Count - 1].Text;
                    if (!oldText.Equals(newText))
                    {
                        if ((i + 1) < lstScores.Items.Count)
                        {
                            oldText = newText;
                            newText = lstScores.Items[i + 1].SubItems[lstScores.Items[i + 1].SubItems.Count - 1].Text;
                            if (!oldText.Equals(newText))
                                x++;
                        }
                    }
                    lstScores.Items[i].BackColor = Color.Yellow;
                    
                }
                else
                {
                    lstScores.Items[i].BackColor = Color.Yellow;
                    x++;
                }
                if (x == top)
                    break;
            }
        }

        private void chkViewTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewTop.Checked)
            {
                btnCheck.Enabled = true;
                cmbContestantCount.Enabled = true;
                SetTopContestant(Convert.ToInt32(cmbContestantCount.SelectedItem.ToString()));
            }
            else
            {
                btnCheck.Enabled = false;
                cmbContestantCount.Enabled = false;
                if (optByJudge.Checked)
                    PopulateList(Convert.ToInt64(cmbJudges.SelectedValue.ToString()));
                else
                    PopulateList();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SetTopContestant(Convert.ToInt32(cmbContestantCount.SelectedItem.ToString()));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lstScores.Items.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Print Details?",
                "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    List<ListViewItem> items = new List<ListViewItem>();
                    foreach (ListViewItem itm in lstScores.Items)
                        items.Add(itm);
                    string filter = "Overall";
                    string order = "None";
                    if (chkViewTop.Checked)
                        order = "Top " + cmbContestantCount.SelectedItem.ToString();
                    if (optByJudge.Checked)
                        filter ="Judge " + cmbJudges.SelectedItem.ToString().Split(',')[1].Replace("]","");
                    excel.PrintToExcel(items,filter,order);
                }
            }
            else
                MessageBox.Show("There is no Existing data.", "Print Failed");
            
        }
    }


    //criteriaid, criterianame, percentage
    class Criteria
    {
        private long criteriaID;
        private string criteriaName;
        private double percentage;
        public Criteria() { }
        public Criteria(long cid, string cn, double p)
        {
            this.criteriaID = cid;
            this.criteriaName = cn;
            this.percentage = p;
        }
        public long CriteriaID
        {
            set { this.criteriaID = value; }
            get { return this.criteriaID; }
        }
        public string CriteriaName
        {
            set { this.criteriaName = value; }
            get { return this.criteriaName; }
        }
        public double Percentage
        {
            set { this.percentage = value; }
            get { return this.percentage; }
        }
    }
    //contestantid, fullname, photopath, contestantno, remarks
    class Contestant
    {
        private long contestantID;
        private string fullname;
        private string photopath;
        private long contestantNo;
        private string remarks;

        public Contestant() { }
        public Contestant(long id, string fn, string photo, long cno, string r)
        {
            this.contestantID = id;
            this.fullname = fn;
            this.photopath = photo;
            this.contestantNo = cno;
            this.remarks = r;
        }
        public long ContestantID
        {
            set { this.contestantID = value; }
            get { return this.contestantID; }
        }
        public long ContestantNo
        {
            set { this.contestantNo = value; }
            get { return this.contestantNo; }
        }
        public string Fullname
        {
            set { this.fullname = value; }
            get { return this.fullname; }
        }
    }
    //judgeid, fullname, remarks
    class Judge
    {
        private long judgeID;
        private string fullname;
        private string remarks;
        public Judge() { }
        public Judge(long id, string fn, string r)
        {
            this.judgeID = id;
            this.fullname = fn;
            this.remarks = r;
        }
        public long JudgeID
        {
            set { this.judgeID = value; }
            get { return this.judgeID; }
        }
        public string Fullname
        {
            set { this.fullname = value; }
            get { return this.fullname; }
        }
    }
    //scoringid, judgeid, criteriaid, contestantid, score, criteriaaverage
    class Scoring
    {
        private long scoringID;
        private long judgeID;
        private long criteriaID;
        private long contestantID;
        private double score;
        private double criteriaAverage;
        public Scoring() { }
        public Scoring(long sid, long jid, long crid, long coid, double sc, double ca)
        {
            this.scoringID = sid;
            this.judgeID = jid;
            this.criteriaID = crid;
            this.contestantID = coid;
            this.score = sc;
            this.criteriaAverage = ca;
        }
        public long ScoringID
        {
            set { this.scoringID = value; }
            get { return this.scoringID; }
        }
        public long JudgeID
        {
            set { this.judgeID = value; }
            get { return this.judgeID; }
        }
        public long CriteriaID
        {
            set { this.criteriaID = value; }
            get { return this.criteriaID; }
        }
        public long ContestantID
        {
            set { this.contestantID = value; }
            get { return this.contestantID; }
        }
        public double CriteriaAverage
        {
            set { this.criteriaAverage = value; }
            get { return this.criteriaAverage; }
        }
    }
}
