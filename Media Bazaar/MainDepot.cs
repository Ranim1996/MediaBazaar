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
            pnlProfile.Visible = false;
            pnlSchedule.Visible = false;
            pnlStock.Visible = false;
        }
        private void makeVisibleOnly(Panel panel)
        {
            btnWhite.Visible = true;
            pnlProfile.Visible = false;
            pnlSchedule.Visible = false;
            pnlStock.Visible = false;
            panel.Visible = true;
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
            makeVisibleOnly(pnlProfile);
            makeHeightEqual(btnProfile);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(pnlSchedule);
            makeHeightEqual(btnSchedule);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            makeVisibleOnly(pnlStock);
            makeHeightEqual(btnStock);
        }
    }
}
