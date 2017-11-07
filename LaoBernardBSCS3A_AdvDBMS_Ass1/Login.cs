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
    public partial class frmLogin : Form
    {
        InteractionAddOns ia = new InteractionAddOns();
        MySQLDBUtilities db = new MySQLDBUtilities();
        ConnectionStringSolution cs = new ConnectionStringSolution();
        public static long userid;
        private bool IsNotDone = true;
        public static string status = "Logout";
        public static string judgeid = "";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
            if (!Directory.Exists("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\Images"))
                Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\Images");
            this.MouseDown += new MouseEventHandler(frm_MouseDown);
            this.MouseMove += new MouseEventHandler(frm_MouseMove);
            this.MouseUp += new MouseEventHandler(frm_MouseUp);
            if (db.OpenConnection() == null)
            {
                db.CloseConnection();
                frmConnnection conn = new frmConnnection();
                conn.ShowDialog();
            }
            SetAdminIfNotExist();
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

        private void SetAdminIfNotExist()
        {
            if (db.SelectTable("SELECT * FROM tbluser").Rows.Count == 0)
                db.SPInsertUser("admin","pass","Admin",0,true,-1);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Environment.Exit(1);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtUsername.Text != "")
            {
                if (IsAccountValid())
                {
                    frmMain.isAnyFormOpen = false;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Please Enter your username and password.",
                    "Cannot access application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool IsAccountValid()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tbluser WHERE username = '" + txtUsername.Text.Replace("'","''") + "'");
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r["username"].ToString().Equals(txtUsername.Text) &&
                        r["userpassword"].ToString().Equals(txtPassword.Text))
                    {
                        if (r["usertype"].ToString().Equals("Judge"))
                        {
                            status = "Judge";
                            judgeid = r["judgeid"].ToString();
                        }
                        else
                            status = "Admin";
                        userid = Convert.ToInt64(r["userid"].ToString());
                        if (judgeid != "")
                        {
                            if (frmMain.isAllSet)
                            {
                                if (!IsJudgeActive())
                                {
                                    MessageBox.Show("You cannot Login after submitting your scores.");
                                    judgeid = "";
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please wait for the admin to finalize settings.", "Access Denied");
                                judgeid = "";
                                return false;
                            }
                        }
                        return true;
                    }
                }
                MessageBox.Show("Incorrect User Account!", "Access Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                MessageBox.Show("User doesn't exist.",
                    "User Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool IsJudgeActive()
        {
            try
            {
                string temp = cs.ReadRegistryKey("JudgeDone", "mysqllao");
                string[] jids = temp.Split('|');
                foreach (string s in jids)
                {
                    if (s.Equals(judgeid))
                        return false;
                }
                return true;
            }
            catch
            {
                try
                {
                    cs.CreateRegistryKey("JudgeDone", "");
                }
                catch { }
                return true;
            }
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && IsNotDone) { }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtPassword.Text != "" && txtUsername.Text != "")
                {
                    if (IsAccountValid())
                    {
                        frmMain.isAnyFormOpen = false;
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Please Enter your username and password.",
                        "Cannot access application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
