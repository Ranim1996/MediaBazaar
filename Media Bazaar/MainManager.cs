using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar.Classes;

namespace Media_Bazaar
{
    public partial class MainManager : Form
    {
        List<DBEmployee> employees = new List<DBEmployee>();

        public MainManager()
        {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            checkedListBox2.DataSource = employees;
            checkedListBox2.DisplayMember = "FullInfo";
        }
       
        private void MainManager_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabPages[0].BackColor = Color.FromArgb(116, 208, 252);
        }


        //----------------------------------Start
        //All buttons connections for the AdminForm 
        //DO NOT Modify THIS !!!
        private void btnSearchTABemplStats_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSearchEmpl;
        }

        private void btnLogOutTABdepart_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Visible = false;
        }

        private void MainManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnShiftsTABemplStats_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabShiftStats;
        }

        private void btnDepartStockTABemplStats_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDepartStats;
        }

        private void btnEmployeesTABshiftStats_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEmployeeStats;
        }

        private void btnStatisticsTABsearch_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEmployeeStats;
        }
        //Here information about the employee should be added, in order to display his correct info on the profile TAB.
        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabProfile;
        }
        //----------------------------------------Finish



        //------------------------------start
        //Method for changing back color of the selected menu
        public void ChangeBackColorOfMenus(TabControl tc)
        {
            if(tc.SelectedTab == tabEmployeeStats || tc.SelectedTab == tabShiftStats || tc.SelectedTab == tabDepartStats)
            {
                btnStatsTABdepart.BackColor = Color.FromArgb(32, 126, 177);
                btnStatsTABemployeeStats.BackColor = Color.FromArgb(32, 126, 177);
                btnStatisticsTABshiftStats.BackColor = Color.FromArgb(32, 126, 177);
            }
            else
            {
                if(tc.SelectedTab == tabSearchEmpl || tc.SelectedTab == tabProfile)
                {
                    btnSearchTABprofile.BackColor = Color.FromArgb(32, 126, 177); 
                    btnSearchTABsearch.BackColor = Color.FromArgb(32, 126, 177);
                }
            }
        }
        private void timerSelectedMenu_Tick(object sender, EventArgs e)
        {
            ChangeBackColorOfMenus(tabControl1);
        }

        private void btnSearchForSpecificEmployee_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            if (cmbSelectSeachMethod.Text=="Last name")
            {
                employees = db.GetDBEmployeesByLastName(this.tbxSearchLastname.Text);
                UpdateList();
                UpdateInfoByLastname();
            }

            else if (cmbSelectSeachMethod.Text == "ID")
            {
                employees = db.GetDBEmployeeByID(Convert.ToInt32(this.tbxSearchID.Text));
                UpdateList();
                UpdateInfoByID();
            }
        }

        private void UpdateInfoByID()
        {
            //display the data in the labels
            DataAccess db = new DataAccess();

            this.lblFirstName.Text = db.GetFirstNameOfEmployeeById(Convert.ToInt32(this.tbxSearchID.Text)).ToString();
            this.lblLastName.Text = db.GetLastNameOfEmployeeById(Convert.ToInt32(this.tbxSearchID.Text)).ToString();
            this.lblPosInCompany.Text = db.GetPosOfEmployeeById(Convert.ToInt32(this.tbxSearchID.Text)).ToString();
            this.lblEmail.Text = db.GetEmailOfEmployeeById(Convert.ToInt32(this.tbxSearchID.Text)).ToString();
            this.lblPhoneNumber.Text = db.GetPhoneNumberOfEmployeeById(Convert.ToInt32(this.tbxSearchID.Text)).ToString();
            this.lblNationality.Text = db.GetNationalityOfEmployeeById(Convert.ToInt32(this.tbxSearchID.Text)).ToString();
            this.lblDateOfBirth.Text = db.GetDateOfBirthOfEmployeeById(Convert.ToInt32(this.tbxSearchID.Text)).ToString();

        }

        private void UpdateInfoByLastname()
        {
            //display the data in the labels
            DataAccess db = new DataAccess();

            this.lblFirstName.Text = db.GetFirstNameOfEmployeeByLastname(this.tbxSearchLastname.Text).ToString();
            this.lblLastName.Text = db.GetLastNameOfEmployeeByLastname(this.tbxSearchLastname.Text).ToString();
            this.lblPosInCompany.Text = db.GetPosOfEmployeeByLastname(this.tbxSearchLastname.Text).ToString();
            this.lblEmail.Text = db.GetEmailOfEmployeeByLastname(this.tbxSearchLastname.Text).ToString();
            this.lblPhoneNumber.Text = db.GetPhoneNumberOfEmployeeByLastname(this.tbxSearchLastname.Text).ToString();
            this.lblNationality.Text = db.GetNationalityOfEmployeeByLastname(this.tbxSearchLastname.Text).ToString();
            this.lblDateOfBirth.Text = db.GetDateOfBirthOfEmployeeByLastname(this.tbxSearchLastname.Text).ToString();

        }
        //---------------------------------------------------finish
    }
}
