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
    public partial class frmChangeAdminPass : Form
    {
        InteractionAddOns ia = new InteractionAddOns();
        MySQLDBUtilities db = new MySQLDBUtilities();
        string username;
        string password;

        public frmChangeAdminPass()
        {
            InitializeComponent();
        }

        private void frmChangeAdminPass_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
            this.MouseDown += new MouseEventHandler(frm_MouseDown);
            this.MouseMove += new MouseEventHandler(frm_MouseMove);
            this.MouseUp += new MouseEventHandler(frm_MouseUp);
            DataTable dt = db.SelectTable("SELECT username, userpassword FROM tbluser WHERE userid =" + frmLogin.userid);
            DataRow r = dt.Rows[0];
            username = r["username"].ToString();
            password = r["userpassword"].ToString();
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
            frmMain.isAnyFormOpen = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOld.Text.Equals(password) && txtNew.Text != "" &&
                DialogResult.Yes == MessageBox.Show("Are you sure to modify your password?","Change Password",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                db.InsertQuery("UPDATE tbluser SET userpassword='" +
                    txtNew.Text.Replace("'","''") + "' WHERE userid=" + frmLogin.userid);
                MessageBox.Show("Password changed", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain.isAnyFormOpen = false;
                this.Close();
            }
        }
    }
}
