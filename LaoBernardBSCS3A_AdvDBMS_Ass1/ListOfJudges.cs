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
    public partial class frmListOfJudges : Form
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        InteractionAddOns ia = new InteractionAddOns();
        private long judgeid = -1;

        public frmListOfJudges()
        {
            InitializeComponent();
        }

        private void ListOfJudges_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
            RefreshList();
            this.MouseDown += new MouseEventHandler(frm_MouseDown);
            this.MouseMove += new MouseEventHandler(frm_MouseMove);
            this.MouseUp += new MouseEventHandler(frm_MouseUp);
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
        public void RefreshList()
        {
            lstJudges.Items.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tbljudge");
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem itm = new ListViewItem(r["judgeid"].ToString());
                itm.SubItems.Add(r["fullname"].ToString());
                itm.SubItems.Add(r["remarks"].ToString());
                lstJudges.Items.Add(itm);
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (judgeid != -1)
            {
                frmAddUser edit = new frmAddUser();
                edit.judgeid = judgeid;
                edit.lblHead.Text = "Configure Account";
                edit.optAdmin.Enabled = false;
                edit.optJudge.Checked = true;
                frmAddUser.isNew = false;
                edit.ShowDialog();
                RefreshList();
            }
            else
                MessageBox.Show("Please choose a judge to proceed.",
                    "Unknown", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = false;
            this.Close();
        }

        private void lstJudges_Click(object sender, EventArgs e)
        {
            int x = lstJudges.SelectedIndices[0];
            judgeid = Convert.ToInt64(lstJudges.Items[x].Text);
        }
    }
}
