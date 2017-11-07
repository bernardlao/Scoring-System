using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyClassCollection;

namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    public partial class frmMain : Form
    {
        public static int height = 0;
        public static bool isAnyFormOpen = false;
        public static bool isAllSet = false;
        ConnectionStringSolution cs = new ConnectionStringSolution();
        MySQLDBUtilities db = new MySQLDBUtilities();

        public frmMain()
        {
            InitializeComponent();
            height = Screen.PrimaryScreen.Bounds.Height;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\Images"))
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\Images");
            mnsHeader.Enabled = false;
            CheckSettings();
            Login();
        }
        private void CheckSettings()
        {
            string temp = "";
            try
            {
                temp = cs.ReadRegistryKey("isAllSet","mysqllao");
                isAllSet = Convert.ToBoolean(temp);
            }
            catch
            {
                cs.CreateRegistryKey("isAllSet", "false");
                isAllSet = Convert.ToBoolean(cs.ReadRegistryKey("isAllSet", "mysqllao"));
            }
        }
        public void Login()
        {
            frmLogin login = new frmLogin();
            login.MdiParent = this;
            login.Show();
        }
        public void AdminPrivelege()
        {
            mnsHeader.Enabled = true;
            menuManageUser.Visible = true;
            menuManageCriteria.Visible = true;
            menuContestant.Visible = true;
            menuStartScoring.Visible = false;
            menuShowTally.Visible = true;
            menuFinalizeSettings.Visible = true;
            menuSubmitAll.Visible = false; 
        }
        public void JudgePrivelege()
        {
            mnsHeader.Enabled = true;
            menuManageUser.Visible = false;
            menuManageCriteria.Visible = false;
            menuContestant.Visible = false;
            menuStartScoring.Visible = true;
            menuShowTally.Visible = false;
            menuFinalizeSettings.Visible = false;
            menuSubmitAll.Visible = true;
        }
        public void NoPrivelege() { mnsHeader.Enabled = false; }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            frmLogin.status = "Logout";
            frmLogin.judgeid = "";
            Login();
        }

        private void tmPrivelegeSetter_Tick(object sender, EventArgs e)
        {
            if (frmLogin.status.Equals("Admin") && !isAnyFormOpen)
            {
                AdminPrivelege();
                if (isAllSet)
                {
                    menuManageCriteria.Visible = false;
                    menuFinalizeSettings.Text = "Reset Application";
                }
                else
                {
                    menuManageCriteria.Visible = true;
                    menuFinalizeSettings.Text = "Finalize Settings";
                }
            }
            else if (frmLogin.status.Equals("Judge") && !isAnyFormOpen)
                JudgePrivelege();
            else if (frmLogin.status.Equals("Logout") || isAnyFormOpen)
                NoPrivelege();
        }

        private void menuAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser um = new frmAddUser();
            um.MdiParent = this;
            um.Show();
        }

        private void menuEditJudge_Click(object sender, EventArgs e)
        {
            frmListOfJudges loj = new frmListOfJudges();
            loj.MdiParent = this;
            loj.Show();
        }

        private void menuChangePass_Click(object sender, EventArgs e)
        {
            frmChangeAdminPass chg = new frmChangeAdminPass();
            chg.MdiParent = this;
            chg.Show();
        }

        private void menuContestantAddEdit_Click(object sender, EventArgs e)
        {
            frmContestant cont = new frmContestant();
            cont.MdiParent = this;
            cont.Show();
        }

        private void menuContestantDelete_Click(object sender, EventArgs e)
        {
            frmDeleteContestant del = new frmDeleteContestant();
            del.MdiParent = this;
            del.Show();
        }

        private void menuManageCriteria_Click(object sender, EventArgs e)
        {
            frmCriteria crit = new frmCriteria();
            crit.MdiParent = this;
            crit.Show();
        }

        private void menuStartScoring_Click(object sender, EventArgs e)
        {
            frmScoring scr = new frmScoring();
            scr.MdiParent = this;
            scr.Show();
        }

        private void menuShowTally_Click(object sender, EventArgs e)
        {
            DataTable crits = db.SelectTable("SELECT * FROM tblcriteria");
            if (crits != null)
            {
                if (crits.Rows.Count > 0)
                {
                    frmTally tally = new frmTally();
                    tally.MdiParent = this;
                    tally.Size = new Size(this.Width - 10, this.Height - 50);
                    tally.Show();
                }
                else
                    MessageBox.Show("Please provide the criterias first.");
            }
            else
                MessageBox.Show("Please provide the criterias first.");
        }

        private void menuFinalizeSettings_Click(object sender, EventArgs e)
        {
            if (menuFinalizeSettings.Text.Equals("Finalize Settings"))
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to Finalize your settings.\nYou cannot criterias when you proceed?",
                    "Finalizing Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    DataTable criteria = db.SelectTable("SELECT * FROM tblcriteria");
                    if (criteria != null)
                    {
                        if (criteria.Rows.Count > 0)
                        {
                            try
                            {
                                cs.CreateRegistryKey("isAllSet", "true");
                                isAllSet = true;
                                MessageBox.Show("All Set. Judges can no proceed in Scoring!", "Settings Done",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                            MessageBox.Show("You must set some criterias before proceeding.");
                    }
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to Start the application from the beginning?",
                    "Resetting Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    isAllSet = false;
                    ResetDatabase();
                    MessageBox.Show("Please wait while resetting application", "Rolling Back",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLogin login = new frmLogin();
                    login.MdiParent = this;
                    login.Show();
                }
            }
        }
        private void ResetDatabase()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tblcontestant");
            List<string> queries = new List<string>();
            foreach (DataRow r in dt.Rows)
                queries.Add("DELETE FROM tblcontestant WHERE contestantid=" + r["contestantid"].ToString());
            dt = db.SelectTable("SELECT * FROM tblcriteria");
            foreach (DataRow r in dt.Rows)
                queries.Add("DELETE FROM tblcriteria WHERE criteriaid=" + r["criteriaid"].ToString());
            dt = db.SelectTable("SELECT * FROM tbljudge");
            foreach (DataRow r in dt.Rows)
                queries.Add("DELETE FROM tbljudge WHERE judgeid=" + r["judgeid"].ToString());
            dt = db.SelectTable("SELECT * FROM tbluser");
            foreach (DataRow r in dt.Rows)
                queries.Add("DELETE FROM tbluser WHERE userid=" + r["userid"].ToString());
            dt = db.SelectTable("SELECT * FROM tblscoring");
            foreach (DataRow r in dt.Rows)
                queries.Add("DELETE FROM tblscoring WHERE scoringid=" + r["scoringid"].ToString());
            queries.Add("ALTER TABLE tblcontestant AUTO_INCREMENT = 1");
            queries.Add("ALTER TABLE tblcriteria AUTO_INCREMENT = 1");
            queries.Add("ALTER TABLE tbljudge AUTO_INCREMENT = 1");
            queries.Add("ALTER TABLE tbluser AUTO_INCREMENT = 1");
            queries.Add("ALTER TABLE tblscoring AUTO_INCREMENT = 1");
            db.InsertMultiple(queries);
            try
            {
                cs.CreateRegistryKey("isAllSet", "false");
                cs.CreateRegistryKey("JudgeDone", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuSubmitAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure to Submit your scores?\n" +
                "You cannot login again when you proceed.", "Finalizing Scores", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question))
            {
                if (IsJudgeCanBeDeactivated())
                {
                    frmLogin.status = "Logout";
                    frmLogin.judgeid = "";
                    Login();
                }
            }
        }
        private bool IsJudgeCanBeDeactivated()
        {
            DataTable dtContestant = db.SelectTable("SELECT * FROM tblcontestant");
            DataTable dtCriteria = db.SelectTable("SELECT * FROM tblcriteria");
            DataTable dtScoring = db.SelectTable("SELECT * FROM tblscoring WHERE judgeid=" + frmLogin.judgeid);
            int totalNeeded = dtContestant.Rows.Count * dtCriteria.Rows.Count;
            if (totalNeeded == dtScoring.Rows.Count)
            {
                try
                {
                    string last = cs.ReadRegistryKey("JudgeDone", "mysqllao");
                    last = last + frmLogin.judgeid + "|";
                    cs.CreateRegistryKey("JudgeDone", last);
                    MessageBox.Show("Scores sumbitted successfully. Logging off account...",
                        "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch
                {
                    MessageBox.Show("We Encountered a problem. Please contact the administrator.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("You must put scores in all of the existing contestant to submit your scores",
                    "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
        }
    }
}
