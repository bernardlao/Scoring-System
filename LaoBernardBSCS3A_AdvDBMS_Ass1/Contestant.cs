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
using System.IO;

namespace LaoBernardBSCS3A_AdvDBMS_Ass1
{
    public partial class frmContestant : Form
    {
        InteractionAddOns ia = new InteractionAddOns();
        HelperMethods hm = new HelperMethods();
        MySQLDBUtilities db = new MySQLDBUtilities();
        ConnectionStringSolution cs = new ConnectionStringSolution();
        private string path = "";
        private string cid = "0";
        private string oldNo = "";

        public frmContestant()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = false;
            this.Close();
        }

        private void frmContestant_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
            this.MouseDown += new MouseEventHandler(frm_MouseDown);
            this.MouseMove += new MouseEventHandler(frm_MouseMove);
            this.MouseUp += new MouseEventHandler(frm_MouseUp);
            PopulateRecords();
            ClearAllInfo();
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
        private void PopulateRecords()
        {
            lstContestant.Items.Clear();
            DataTable dt = db.SelectTable("SELECT * FROM tblcontestant ORDER BY contestantno");
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem itm = new ListViewItem(r["contestantid"].ToString());
                    itm.SubItems.Add(r["contestantno"].ToString());
                    itm.SubItems.Add(r["fullname"].ToString());
                    itm.SubItems.Add(r["remarks"].ToString());
                    lstContestant.Items.Add(itm);
                }
            }
        }
        private void ClearAllInfo()
        {
            txtRemarks.Text = "";
            txtNo.Text = "";
            txtName.Text = "";
            path = "";
            cid = "0";
            picDP.Image = hm.GetCopyImage(Environment.CurrentDirectory + "\\Images\\default.png");
            oldNo = "";
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, true);
        }

        private void lnkBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image File (*.png,*.jpg*.jpeg)|*.jpeg;*.png;*.jpg";
            if (DialogResult.Cancel != op.ShowDialog())
            { 
                path = op.FileName;
                picDP.Image = hm.GetCopyImage(path);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Finalize information?",
                "Save Datas", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (btnSave.Text.Equals("Save"))
                {
                    if (IsAllInfoValid(""))
                        Save();
                }
                else
                {
                    if (IsAllInfoValid(" AND NOT contestantid = " + cid))
                        UpdateDB();
                }
            }
        }

        public bool IsAllInfoValid(string cons)
        {
            string query = "SELECT * FROM tblcontestant WHERE fullname ='" + txtName.Text.Replace("'","''") + "'" + cons.Replace("'","''");
            DataTable dt = db.SelectTable(query);
            if (txtName.Text.Equals("") || txtNo.Text.Equals("") && txtRemarks.Text.Equals(""))
            {
                MessageBox.Show("Please fillup the whole form.","Warning",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            txtName.Text = hm.CorrectCasing(txtName.Text);
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("Name already exist!", "Information Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            query = "SELECT * FROM tblcontestant WHERE contestantno =" + txtNo.Text + cons;
            dt = db.SelectTable(query);
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("Contestant number already exist!",
                    "Information Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (path.Equals(""))
            {
                MessageBox.Show("Please insert Contestant's image.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try{
                if (!txtNo.Text.Equals(oldNo))
                {
                    File.Copy(@path, "C:\\Users\\" + Environment.UserName +
                        "\\Documents\\Scoring System\\Images\\" + txtNo.Text + ".png", true);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Failed to use current Image.", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public void SetAllJudgesToActive()
        {
            try
            {
                cs.CreateRegistryKey("JudgeDone", "");
            }
            catch
            {
                
            }
        }
        public void Save()
        {
            db.SPInsertContestant(txtName.Text, "C:\\\\Users\\\\" + Environment.UserName.Replace("\\","\\\\") +
                "\\\\Documents\\\\Scoring System\\\\Images\\\\" + txtNo.Text + ".png",
                txtNo.Text, txtRemarks.Text, true, "0");
            PopulateRecords();
            ClearAllInfo();
            SetAllJudgesToActive();
            MessageBox.Show("Save Successful", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void UpdateDB()
        {
            btnSave.Text = "Save";
            lstContestant.Enabled = true;
            btnCancel.Visible = false;
            db.SPInsertContestant(txtName.Text, "C:\\\\Users\\\\" + Environment.UserName.Replace("\\", "\\\\") +
                "\\\\Documents\\\\Scoring System\\\\Images\\\\" + txtNo.Text + ".png", txtNo.Text,
                txtRemarks.Text, false, cid);
            PopulateRecords();
            ClearAllInfo();
            MessageBox.Show("Update Successful", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void lstContestant_DoubleClick(object sender, EventArgs e)
        {
            lstContestant.Enabled = false;
            btnSave.Text = "Update";
            btnCancel.Visible = true;
            ListViewItem itm = lstContestant.SelectedItems[0];
            cid = itm.Text;
            DataTable dt = db.SelectTable("SELECT * FROM tblcontestant WHERE contestantid =" + cid);
            if (dt.Rows.Count != 0)
            {
                DataRow r = dt.Rows[0];
                txtName.Text = r["fullname"].ToString();
                txtNo.Text = r["contestantno"].ToString();
                txtRemarks.Text = r["remarks"].ToString();
                picDP.Image = hm.GetCopyImage(r["photopath"].ToString());
                path = r["photopath"].ToString();
                oldNo = r["contestantno"].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            ClearAllInfo();
            btnSave.Text = "Save";
            lstContestant.Enabled = true;
        }
    }
}
