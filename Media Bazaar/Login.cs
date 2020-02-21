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

namespace Media_Bazaar
{
    public partial class Login : Form
    {
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




        private void tbUsername_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            tbPassword.Clear();
        }



        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            if (tbUsername.Text == "Admin" && tbPassword.Text == "1234")
            {
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                this.Visible = false;
                DataManage.username = tbUsername.Text;
                DataManage.loginForm = this;
                MainAdmin MainAdmin = new MainAdmin();
                MainAdmin.Show();
            }

            if (tbUsername.Text == "Manager" && tbPassword.Text == "1234")
            {
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                this.Visible = false;
                DataManage.username = tbUsername.Text;
                DataManage.loginForm = this;
                MainManager MainManager = new MainManager();
                MainManager.Show();
            }

            if (tbUsername.Text == "Depot" && tbPassword.Text == "1234")
            {
                tbUsername.Text = "Username";
                tbPassword.Text = "Password";
                this.Visible = false;
                DataManage.username = tbUsername.Text;
                DataManage.loginForm = this;
                MainDepot MainDepot = new MainDepot();
                MainDepot.Show();
            }
            else
            {
                //MessageBox.Show("Wrong Username/Password");
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    tbPassword.Focus();
            //}
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnLogin.Focus();
            //}
        }
    }
}