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
    public partial class frmScoring : Form
    {
        struct Contestant
        {
            public string contestantID;
            public string fullname;
            public string contestantNo;
            public string photoPath;
            public string remarks;
        }
        List<Contestant> contestants = new List<Contestant>();
        int locx = 15;
        int locy = 30;
        const int padx = 15;
        const int pady = 15;
        const int width = 550;
        const int height = 350;
        public static bool isScored = false;
        Panel panel = new Panel();

        MySQLDBUtilities db = new MySQLDBUtilities();
        HelperMethods hm = new HelperMethods();
        InteractionAddOns ia = new InteractionAddOns();

        public frmScoring()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
            CreatePanel();
            GenerateControls();
        }
        private void CreatePanel()
        {
            panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
            panel.Location = new System.Drawing.Point(5, 30);
            panel.Size = new System.Drawing.Size(this.Width - 35, this.Height - 80);
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.AutoScroll = true;
        }
        public void GenerateControls()
        {
            locx = 15;
            locy = 30;

            DataTable dt = db.SelectTable("SELECT * FROM tblcontestant ORDER BY contestantno");

            int counter = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dt.Rows[i];
                Contestant c = new Contestant();
                c.contestantID = r["contestantid"].ToString();
                c.contestantNo = r["contestantno"].ToString();
                c.fullname = r["fullname"].ToString();
                c.photoPath = r["photopath"].ToString();
                c.remarks = r["remarks"].ToString();
                GroupBox gpb = CreateGroupBox(locx, locy, "C# - " + c.contestantNo);
                PictureBox pic = CreatePictureBox(padx,pady, hm.GetCopyImage(c.photoPath));
                gpb.Controls.Add(pic);
                long jid = db.GetID("SELECT * FROM tbluser WHERE userid=" + frmLogin.userid,"judgeid");
                DataTable scored = db.SelectTable("SELECT * FROM tblscoring WHERE contestantid=" + c.contestantID +
                    " AND judgeid=" + jid);
                bool isScored = (scored.Rows.Count > 0?true:false);

                PictureBox ico = CreatePictureBox(gpb.Size.Width - (padx * 2), pady,
                    (!isScored?hm.GetCopyImage(Environment.CurrentDirectory + "\\Images\\cross.png"):
                    hm.GetCopyImage(Environment.CurrentDirectory + "\\Images\\check.png")));
                ico.SizeMode = PictureBoxSizeMode.AutoSize;
                ico.BorderStyle = BorderStyle.None;
                //pictures[i - 1] = ico;
                gpb.Controls.Add(ico);

                Size s = new Size(gpb.Width - pic.Width - (padx * 2), (pic.Height/3) * 2);
                Label remarks = CreateLabel((pic.Size.Width + padx), ((pic.Height / 3) + 20), s, c.remarks);
                remarks.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                remarks.BorderStyle = BorderStyle.FixedSingle;
                gpb.Controls.Add(remarks);

                s = new Size(gpb.Width - pic.Width - (padx * 2),40);
                Label name = CreateLabel((pic.Size.Width + padx),pady + 20 , s ,c.fullname);
                name.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                gpb.Controls.Add(name);

                s = new Size(gpb.Width - pic.Width - (padx * 2), 40);
                Label details = CreateLabel((pic.Size.Width + padx), pady + 60, s, "Details : ");
                details.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
                gpb.Controls.Add(details);

                s = new Size(gpb.Width - (padx * 2), 40);
                Button btnSubmit = CreateButton(padx , gpb.Height - 40 - pady, s,(isScored?"Edit":"Enter") + " Your Score for C# - " + c.contestantNo,i.ToString());
                btnSubmit.Click += new EventHandler(btnSave_Click);
                gpb.Controls.Add(btnSubmit);

                locx += padx + width;
                counter++;
                if (counter == 2)
                {
                    locx = padx;
                    locy += pady + height;
                    counter = 0;
                }
                panel.Controls.Add(gpb);
                contestants.Add(c);
            }

            this.Controls.Add(panel);
            this.Size = new Size(1180, frmMain.height - 90);
        }
        public GroupBox CreateGroupBox(int x, int y, string text)
        {
            GroupBox gpb = new GroupBox();
            gpb.Location = new Point(x, y);
            gpb.Size = new Size(width, height);
            gpb.Text = text;
            gpb.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            return gpb;
        }
        public PictureBox CreatePictureBox(int x, int y, Image bm)
        {
            PictureBox pic = new PictureBox();
            pic.Location = new Point(x, y + 5);
            pic.Image = bm;
            pic.Size = new Size(270, 250);
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            return pic;
        }
        public Label CreateLabel(int x, int y,Size s , string text)
        {
            Label lbl = new Label();
            lbl.Location = new Point(x, y);
            lbl.AutoSize = false;
            lbl.Size = s;
            lbl.Text = text;
            return lbl;
        }
        public Button CreateButton(int x, int y,Size s,string text,string name)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 10F,FontStyle.Bold);
            btn.Size = s;
            btn.Name = name;
            btn.Location = new Point(x, y);
            return btn;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Button btn = (Button)sender;
                string[] temp = btn.Text.Split(' ');
                Contestant c = contestants[Convert.ToInt32(btn.Name)];
                frmApplyScore apply = new frmApplyScore();
                apply.cid = c.contestantID;
                apply.ShowDialog();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = false;
            this.Close();
        }

        private void mnsHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ia.FormDrag(ref sender, ref e, MousePosition, this.Location);
        }

        private void mnsHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (ia.isMoving)
            {
                this.Location = ia.FormMove(ref sender, ref e, MousePosition);
            }
        }

        private void mnsHeader_MouseUp(object sender, MouseEventArgs e)
        {
            ia.FormDrop(ref sender, ref e);
        }

        private void tmDone_Tick(object sender, EventArgs e)
        {
            if (isScored )
            {
                panel.Controls.Clear();
                contestants.Clear();
                GenerateControls();
                panel.Focus();
                isScored = false;
            }
        }
    }
}
