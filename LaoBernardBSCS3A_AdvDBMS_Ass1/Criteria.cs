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
    public partial class frmCriteria : Form
    {
        struct Criteria
        {
            public TextBox txtName;
            public TextBox txtAverage;
        }
        List<Criteria> criterias = new List<Criteria>();
        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        InteractionAddOns ia = new InteractionAddOns();
        const int pady = 15;
        int posy = 15;
        int counter = 0;

        public frmCriteria()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = false;
            this.Close();
        }
        private void frmCriteria_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
            this.MouseDown += new MouseEventHandler(frm_MouseDown);
            this.MouseMove += new MouseEventHandler(frm_MouseMove);
            this.MouseUp += new MouseEventHandler(frm_MouseUp);
            mnsHeader.MouseDown+= new MouseEventHandler(frm_MouseDown);
            mnsHeader.MouseMove += new MouseEventHandler(frm_MouseMove);
            mnsHeader.MouseUp += new MouseEventHandler(frm_MouseUp);
            DataTable dt = db.SelectTable("SELECT * FROM tblcriteria");
            if (dt != null) 
            {
                if (dt.Rows.Count != 0)
                    SetDetails(dt);
                else
                    AddControl();
            }
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
        private void AddControl()
        {
            Criteria c = new Criteria();

            TextBox txtN = CreateTextBox(10, posy, new Size(190, 27));
            txtN.KeyPress += new KeyPressEventHandler(TextKeyPressLetter);
            c.txtName = txtN;
            TextBox txtA = CreateTextBox(222, posy, new Size(50, 27));
            txtA.KeyPress += new KeyPressEventHandler(TextKeyPressDecimal);
            c.txtAverage = txtA;
            criterias.Add(c);

            pnlCriteria.Controls.Add(c.txtName);
            pnlCriteria.Controls.Add(c.txtAverage);
        }
        private void SetDetails(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dt.Rows[i];
                Criteria c = new Criteria();

                TextBox txtN = CreateTextBox(10, posy, new Size(190, 27));
                txtN.KeyPress += new KeyPressEventHandler(TextKeyPressLetter);
                txtN.Text = r["criterianame"].ToString();
                c.txtName = txtN;
                TextBox txtA = CreateTextBox(222, posy, new Size(50, 27));
                txtA.KeyPress += new KeyPressEventHandler(TextKeyPressDecimal);
                txtA.Text = r["percentage"].ToString();
                c.txtAverage = txtA;

                pnlCriteria.Controls.Add(c.txtName);
                pnlCriteria.Controls.Add(c.txtAverage);
                criterias.Add(c);
                if (i < dt.Rows.Count - 1)
                {
                    posy = posy + pady + 27;
                    btnPlus.Location = new Point(btnPlus.Location.X, posy);
                    btnMinus.Location = new Point(btnMinus.Location.X, posy);
                }
            }
        }
        public Label CreateLabel(int x, int y, Size s, string text)
        {
            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.AutoSize = false;
            lbl.Size = s;
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 11.25F);
            return lbl;
        }
        public TextBox CreateTextBox(int x, int y, Size s)
        {
            TextBox txt = new TextBox();
            txt.Location = new Point(x, y);
            txt.Size = s;
            txt.Font = new Font("Segoe UI", 11.25F);
            return txt;
        }
        public Button CreateButton(int x, int y, Size s, string text)
        {
            Button btn = new Button();
            btn.Location = new Point(x, y);
            btn.Size = s;
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 11.25F);
            return btn;
        }
        public void TextKeyPressLetter(object sender, KeyPressEventArgs e)
        {
            hm.TextHandle(ref sender, ref e, false);
        }
        public void TextKeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            hm.DecimalHandle(ref sender, ref e);
            hm.LimitTo(ref sender, ref e, 100);
        }
        private bool IsAllInfoValid()
        {
            List<string> textCheck = new List<string>();
            double total = 0;
            foreach (Criteria c in criterias)
            {
                if (c.txtName.Text.Equals("") || c.txtAverage.Text.Equals(""))
                {
                    MessageBox.Show("All information must be a non empty field");
                    return false;
                }
                if (textCheck.Contains(c.txtName.Text))
                {
                    MessageBox.Show("The Criteria name must no be redundant.");
                    return false;
                }
                else
                    textCheck.Add(c.txtName.Text);
                total += Convert.ToDouble(c.txtAverage.Text);
            }
            if (total != 100.00)
            {
                MessageBox.Show("The total value of all criteria average must be 100.00.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        private void Save()
        {
            List<string> ids = new List<string>();
            List<string> queries = new List<string>();
            DataTable dt = db.SelectTable("SELECT * FROM tblcriteria");
            foreach (DataRow r in dt.Rows)
                ids.Add(r["criteriaid"].ToString());
            int diff = 0;
            if (ids.Count <= criterias.Count)
            {
                diff = criterias.Count - ids.Count;
                for (int i = 0; i < criterias.Count; i++)
                {
                    Criteria c = criterias[i];

                    if (i >= ids.Count)
                    {
                        queries.Add("INSERT INTO tblcriteria (criterianame,percentage) VALUES('" +
                                hm.CorrectCasing(c.txtName.Text) + "'," + c.txtAverage.Text + ");");
                    }
                    else
                    {
                        queries.Add("UPDATE tblcriteria SET criterianame = '" + hm.CorrectCasing(c.txtName.Text) +
                                               "', percentage=" + c.txtAverage.Text + " WHERE criteriaid=" + ids[i]);
                    }

                }
            }
            else
            {
                diff = ids.Count - criterias.Count;
                for (int i = 0; i < criterias.Count; i++)
                {
                    Criteria c = criterias[i];
                    queries.Add("UPDATE tblcriteria SET criterianame = '" + hm.CorrectCasing(c.txtName.Text) +
                        "', percentage=" + c.txtAverage.Text + " WHERE criteriaid=" + ids[i]);

                }
                for (int i = criterias.Count; i < ids.Count; i++)
                {
                    queries.Add("DELETE FROM tblcriteria WHERE criteriaid = " + ids[i]);
                }
            }
                
            db.InsertMultiple(queries);
            frmMain.isAnyFormOpen = false;
            this.Close();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            posy = posy + pady + 27;
            btnPlus.Location = new Point(btnPlus.Location.X, posy);
            btnMinus.Location = new Point(btnMinus.Location.X, posy);
            AddControl();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            posy = posy - pady - 27;
            btnPlus.Location = new Point(btnPlus.Location.X, posy);
            btnMinus.Location = new Point(btnMinus.Location.X, posy);
            Criteria c = criterias[criterias.Count - 1];
            c.txtAverage.Dispose();
            c.txtName.Dispose();
            criterias[criterias.Count - 1] = c;
            criterias.RemoveAt(criterias.Count - 1);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure to save the following?",
                "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (IsAllInfoValid())
                {
                    Save();
                }
            }
        }
    }
}
