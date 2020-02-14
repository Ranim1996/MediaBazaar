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
    public partial class MainAdmin : Form
    {
        Login loginForm;
        public MainAdmin()
        {
            InitializeComponent();
            loginForm = DataManage.loginForm;
            btnWhite.Visible = false;
            adminEmployees1.Visible = false;
            adminSchedule1.Visible = false;
            adminProfile1.Visible = false;
        }
        private void makeVisibleOnly(UserControl userControl)
        {
            btnWhite.Visible = true;
            adminEmployees1.Visible = false;
            adminSchedule1.Visible = false;
            adminProfile1.Visible = false;
            userControl.Visible = true;
        }

        private void makeHeightEqual(Button button) //To display the tab we are using
        {
            btnWhite.Height = button.Height;
            btnWhite.Top = button.Top;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            loginForm.Show();
            btnWhite.Height = btnLogout.Height;
            btnWhite.Top = btnLogout.Top;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(adminProfile1);
            makeHeightEqual(btnProfile);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(adminEmployees1);
            makeHeightEqual(btnEmployees);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(adminSchedule1);
            makeHeightEqual(btnSchedule);
        }
    }
}