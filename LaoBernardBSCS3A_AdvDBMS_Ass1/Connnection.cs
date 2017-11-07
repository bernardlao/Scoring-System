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
    public partial class frmConnnection : Form
    {
        InteractionAddOns ia = new InteractionAddOns();
        MySQLDBUtilities db = new MySQLDBUtilities();
        private bool IsNotValidExit = true;
        ConnectionStringSolution css = new ConnectionStringSolution();

        public frmConnnection()
        {
            InitializeComponent();
        }

        private void frmConnnection_Load(object sender, EventArgs e)
        {
            frmMain.isAnyFormOpen = true;
        }
        private void frmConnnection_MouseDown(object sender, MouseEventArgs e)
        {
            ia.FormDrag(ref sender, ref e, MousePosition, this.Location);
        }
        private void frmConnnection_MouseMove(object sender, MouseEventArgs e)
        {
            if (ia.isMoving)
            {
                this.Location = ia.FormMove(ref sender, ref e, MousePosition);
            }
        }
        private void frmConnnection_MouseUp(object sender, MouseEventArgs e)
        {
            ia.FormDrop(ref sender, ref e);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (IsConnectionValid())
            {
                MessageBox.Show("Connection Valid!");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (IsConnectionValid())
            {
                MessageBox.Show("Connection Valid!");
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to use \nthe established connection?",
                    "Use Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    IsNotValidExit = false;
                    frmMain.isAnyFormOpen = false;
                    this.Close();
                }

            }
        }

        private bool IsConnectionValid()
        {
            string connStr = "SERVER=" + txtServer.Text + ";" +
                             "PORT=" + txtPort.Text + ";" +
                             "DATABASE=" + txtDatabase.Text + ";" +
                             "UID=" + txtUID.Text + ";" +
                             "PASSWORD=" + txtPassword.Text + ";";

            css.CreateRegistryKey("ConnectionString", connStr);
            if (db.OpenConnection() == null)
                return false;
            else
            {
                db.CloseConnection();
                return true;
            }
        }
        //public void CreateConnection(string prompt)
        //{
        //    if (File.Exists("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\settings.ini"))
        //        File.Delete("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\settings.ini");
        //    string[] connstr = { "SERVER=" + txtServer.Text + ";", "PORT=" + txtPort.Text + ";",
        //                          "DATABASE=" + txtDatabase.Text + ";", "UID=" +  txtUID.Text + ";","PASSWORD=" + txtPassword.Text + ";" };
        //    File.WriteAllLines("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\settings.ini", connstr);
        //    if (db.OpenConnection() != null)
        //    {
        //        MessageBox.Show("The Connection was valid!", prompt + " Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        IsNotValidExit = false;
        //        db.CloseConnection();
        //    }
        //    else
        //    {
        //        MessageBox.Show("The Created connection was invalid!", prompt + " Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        IsNotValidExit = true;
        //    }
        //}

        private void menuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void frmConnnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && IsNotValidExit)
                Environment.Exit(1);
        }
    }
}
