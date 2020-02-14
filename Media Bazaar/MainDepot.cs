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
    public partial class MainDepot : Form
    {
        Login loginForm;
        public MainDepot()
        {
            InitializeComponent();
            loginForm = DataManage.loginForm;
            btnWhite.Visible = false;
            depotProfile1.Visible = false;
            depotSchedule1.Visible = false;
            depotStock1.Visible = false;
        }
        private void makeVisibleOnly(UserControl userControl)
        {
            btnWhite.Visible = true;
            depotProfile1.Visible = false;
            depotSchedule1.Visible = false;
            depotStock1.Visible = false;
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
            makeVisibleOnly(depotProfile1);
            makeHeightEqual(btnProfile);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(depotSchedule1);
            makeHeightEqual(btnSchedule);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(depotStock1);
            makeHeightEqual(btnStock);
        }
    }
}
