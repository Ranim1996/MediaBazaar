using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Media_Bazaar.Classes;

namespace Media_Bazaar
{
    public partial class Login : Form
    {
        DataAccess db;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        //closes login form and exits the app
        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimize login form
        private void btnLoginMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private int nrRows;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //db = new DataAccess();
            //nrRows = db.GetProfileDetails(tbUsername.Text, tbPassword.Text);

            //if (nrRows>0)
            //{
            //    tbUsername.Text = "Username";
            //    tbPassword.Text = "Password";
            //    MainAdmin MainAdmin = new MainAdmin();
            //    MainAdmin.Show();
            //    this.Visible = false;
            //}

            //else
            //{
            //    MessageBox.Show("Wrong Username/Password");
            //    tbUsername.Text = "Username";
            //    tbPassword.Text = "Password";
            //}



            if (tbUsername.Text == "Admin" && tbPassword.Text == "1234")
            {
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                MainAdmin MainAdmin = new MainAdmin();
                MainAdmin.Show();
                this.Visible = false;
            }
            else
            {
                if (tbUsername.Text == "Manager" && tbPassword.Text == "1234")
                {
                    tbUsername.Text = "Username";
                    tbPassword.Text = "Password";
                    MainManager MainManager = new MainManager();
                    MainManager.Show();
                    this.Visible = false;
                }
                else
                {
                    if (tbUsername.Text == "Depot" && tbPassword.Text == "1234")
                    {
                        tbUsername.Text = "Username";
                        tbPassword.Text = "Password";
                        MainDepot MainDepot = new MainDepot();
                        MainDepot.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username/Password");
                        tbUsername.Text = "Username";
                        tbPassword.Text = "Password";
                    }
                }
            }
        }
    }
}
