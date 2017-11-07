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
    public partial class frmDeleteContestant : Form
    {
        InteractionAddOns ia = new InteractionAddOns();
        MySQLDBUtilities db = new MySQLDBUtilities();
        string cid = "0";

        public frmDeleteContestant()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteContestant_Load(object sender, EventArgs e)
        {
            this.MouseDown += new MouseEventHandler(frm_MouseDown);
            this.MouseMove += new MouseEventHandler(frm_MouseMove);
            this.MouseUp += new MouseEventHandler(frm_MouseUp);
            PopulateRecords();
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
        public void PopulateRecords()
        {
            lstContestants.Items.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tblcontestant ORDER BY contestantno");
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem itm = new ListViewItem(r["contestantid"].ToString());
                itm.SubItems.Add(r["contestantno"].ToString());
                itm.SubItems.Add(r["fullname"].ToString());
                itm.SubItems.Add(r["remarks"].ToString());
                lstContestants.Items.Add(itm);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the selected contestant?",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) && !cid.Equals("0"))
            {
                db.InsertQuery("DELETE FROM tblcontestant WHERE contestantid =" + cid);
                MessageBox.Show("Record deleted Successfully!", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateRecords();
            }
        }

        private void lstContestants_Click(object sender, EventArgs e)
        {
            ListViewItem itm = lstContestants.SelectedItems[0];
            cid = itm.Text;
        }

    }
}
