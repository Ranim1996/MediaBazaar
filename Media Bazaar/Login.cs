using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tbUsername_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            tbPassword.Clear();
        }

        private void pbLogin_Click(object sender, EventArgs e)
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
        }
    }
}