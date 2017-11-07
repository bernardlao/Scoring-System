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
    public partial class frmAddUser : Form
    {
        InteractionAddOns ia = new InteractionAddOns();
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();

        public long judgeid = 0;
        private long userid = 0;
        public static bool isNew = true;

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
            this.MouseDown += new MouseEventHandler(frm_MouseDown);
            this.MouseMove += new MouseEventHandler(frm_MouseMove);
            this.MouseUp += new MouseEventHandler(frm_MouseUp);
            if (lblHead.Text.Equals("Configure Account"))
            {
                SetDetails();
            }
        }
        public void SetDetails()
        {
            DataTable dt = db.SelectTable("SELECT * FROM tbljudge WHERE judgeid =" + judgeid);
            DataRow r = dt.Rows[0];
            txtFullname.Text = r["fullname"].ToString();
            txtRemarks.Text = r["remarks"].ToString();
            dt = db.SelectTable("SELECT * FROM tbluser WHERE judgeid =" + judgeid);
            r = dt.Rows[0];
            txtUsername.Text = r["username"].ToString();
            txtPassword.Text = r["userpassword"].ToString();
            userid = db.GetID("SELECT * FROM tbluser WHERE judgeid=" + judgeid, "userid");
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
        private void optJudge_CheckedChanged(object sender, EventArgs e)
        {
            if (optAdmin.Checked == true)
                gpbJudgeInfo.Enabled = false;
            else
                gpbJudgeInfo.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure do you want to proceed?",
                "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (lblHead.Text.Equals("Create User"))
                    SaveUser(optAdmin.Checked);
                else
                    UpdateUser();
            }
        }
        public void UpdateUser()
        {
            if (IsInputValid(false))
            {
                db.SPInsertJudge(hm.CorrectCasing(txtFullname.Text), txtRemarks.Text, false, judgeid);
                db.SPInsertUser(txtUsername.Text, txtPassword.Text, "Judge", judgeid, false,this.userid);
                MessageBox.Show("Update Successful", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain.isAnyFormOpen = false;
                isNew = true;
                this.Close();
            }
        }
        private void SaveUser(bool IsAdmin)
        {
            if(IsInputValid(IsAdmin))
            {
                if (!IsAdmin)
                {
                    db.SPInsertJudge(hm.CorrectCasing(txtFullname.Text), txtRemarks.Text, true, 0);
                    judgeid = db.GetID("SELECT * FROM tbljudge WHERE fullname = '" +
                        txtFullname.Text.Replace("'","''") + "' AND remarks = '" + txtRemarks.Text.Replace("'","''") + "'", "judgeid");
                }
                db.SPInsertUser(txtUsername.Text, txtPassword.Text, (IsAdmin ? "Admin" : "Judge"), judgeid, true, 0);
                MessageBox.Show("Account Saved Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                judgeid = 0;
                Clear();
            }

        }
        private bool IsInputValid(bool IsAdmin)
        {
            DataTable dtUser = db.SelectTable("SELECT * FROM tbluser WHERE username = '" + txtUsername.Text.Replace("'","''") + "'");
            DataTable dtJudge = db.SelectTable("SELECT * FROM tbljudge WHERE fullname = '" + txtFullname.Text.Replace("'","''") + "'");
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                if (dtUser.Rows.Count != 0 && isNew)
                {
                    MessageBox.Show("Username Already Exist!",
                        "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            else if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill up the whole form");
                return false;
            }
            if (!IsAdmin)
            {
                if (txtFullname.Text == "" && txtRemarks.Text == "")
                {
                    MessageBox.Show("Please fill up the judge details");
                    return false;
                }
            }
            return true;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = false;
            this.Close();
        }
        public void Clear()
        {
            txtFullname.Text = "";
            txtPassword.Text = "";
            txtRemarks.Text = "";
            txtUsername.Text = "";
            gpbJudgeInfo.Enabled = false;
            optAdmin.Checked = true;
            optJudge.Checked = false;
        }
    }
}
