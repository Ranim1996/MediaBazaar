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
    public partial class MainManager : Form
    {
        Login loginForm;
        public MainManager()
        {
            InitializeComponent();
            loginForm = DataManage.loginForm;
            btnWhite.Visible = false;
            managerStatistics1.Visible = false;
            managerEmployees1.Visible = false;
            managerStocks1.Visible = false;
            managerProfile1.Visible = false;
        }
        private void makeVisibleOnly(UserControl userControl)
        {
            btnWhite.Visible = true;
            managerStatistics1.Visible = false;
            managerEmployees1.Visible = false;
            managerStocks1.Visible = false;
            managerProfile1.Visible = false;
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

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(managerStatistics1);
            makeHeightEqual(btnStatistics);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(managerEmployees1);
            makeHeightEqual(btnEmployees);
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(managerStocks1);
            makeHeightEqual(btnStocks);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(managerProfile1);
            makeHeightEqual(btnProfile);
        }
    }
}
