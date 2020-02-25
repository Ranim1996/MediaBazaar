using Media_Bazaar.Classes;
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

        Administration administration = new Administration();

        //holds the calendar
        Media_Bazaar.Classes.Calendar calendar = new Classes.Calendar();




        public MainAdmin()
        {
            InitializeComponent();
        }
        private void MainAdmin_Load(object sender, EventArgs e)
        {
            //GUI load
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabPages[0].BackColor = Color.FromArgb(116, 208, 252);


            // --- Schedule Tab ---
            //evn.GetAllEvents();   //Shifts listed in calendar
            calendar.GenerateDayPanel(42, flDays);
            calendar.DisplayCurrentDate(lblMonthAndYear);

        }

        //----------------------------------Start
        //All buttons connections for the AdminForm 
        //DO NOT Modify THIS !!!
        private void MainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnEmployeeManageTABaddProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabAddProfile;
        }

        private void btnRemoveProfTABaddProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabRemoveProfile;
        }

        private void btnAssignToDepTABaddProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabAssignDep;
        }

        private void btnScheduleTABaddProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSchedule;
        }

        private void btnRestockTABaddProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabRestockReq;
        }

        private void btnDepartManageTABaddProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDepartManage;
        }

        private void btnNewProfileTABremoveProfile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabAddProfile;
        }

        private void btnLogOutTABaddProfile_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Visible = false;
            //this.Dispose();    ??? should be used when the database will be created????
        }
        //----------------------------------------Finish




        //------------------------------start
        //Method for changing back color of the selected menu
        public void ChangeBackColorOfMenus(TabControl tc)
        {
            if (tc.SelectedTab == tabAddProfile || tc.SelectedTab == tabRemoveProfile || tc.SelectedTab == tabAssignDep)
            {
                btnEmployeeManageTABaddProfile.BackColor = Color.FromArgb(32, 126, 177);
                btnEmployeeManageTABassignDep.BackColor = Color.FromArgb(32, 126, 177);
                btnEmployeeManageTABremoveProfile.BackColor = Color.FromArgb(32, 126, 177);
            }
            else
            {
                if (tc.SelectedTab == tabSchedule)
                {
                    btnScheduleTABschedule.BackColor = Color.FromArgb(32, 126, 177);
                }
                else
                {
                    if (tc.SelectedTab == tabRestockReq)
                    {
                        btnRestockReqTABrestock.BackColor = Color.FromArgb(32, 126, 177);
                    }
                    else
                    {
                        if (tc.SelectedTab == tabDepartManage)
                        {
                            btnDepartmentTABdepartManage.BackColor = Color.FromArgb(32, 126, 177);
                        }
                    }
                }
            }
        }
        private void timerChangingMenusColor_Tick(object sender, EventArgs e)
        {
            ChangeBackColorOfMenus(tabControl1);
        }
        //---------------------------------------------------finish



        // ----- SCHEDULE Tab ---
        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            calendar.PrevMonth(lblMonthAndYear);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            calendar.Today(lblMonthAndYear);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            calendar.NextMonth(lblMonthAndYear);
        }
        //------------------------------------------------------------------------------------------

        private void btnAddNewProfile_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewProfile_Click_1(object sender, EventArgs e)
        {

            string fName;
            string lName;
            string dateOfBirth;
            string email;
            int phoneNr;
            string nationality;
            JobPosition pos;
            if (tbFirstName.Text != "" && tbLastName.Text != "" && tbDateOfBirth.Text != "" && tbEmail.Text != "" && tbEmail.Text != "" && tbPhoneNr.Text != "" && tbNationality.Text != "")
            {
                fName = tbFirstName.Text;
                lName = tbLastName.Text;
                dateOfBirth = tbDateOfBirth.Text;
                email = tbEmail.Text;
                phoneNr = Convert.ToInt32(tbPhoneNr.Text);
                nationality = tbNationality.Text;
                if (rbAdministrator.Checked)
                {
                    //administrator
                    pos = JobPosition.ADMINISTRATOR;
                    administration.AddEmployee(new Admin(fName, lName, dateOfBirth, email, phoneNr, nationality, pos));
                    //Employee empl = administration.GetEmployeeByName(fName, lName);

                }
                else
                {
                    if (rbManager.Checked)
                    {
                        //Manager
                        pos = JobPosition.MANAGER;
                        administration.AddEmployee(new Manager(fName, lName, dateOfBirth, email, phoneNr, nationality, pos));
                    }
                    else if (rbDepotWorker.Checked)
                    {
                        //Depot worker
                        pos = JobPosition.DEPOTWORKER;
                        administration.AddEmployee(new DepotWorker(fName, lName, dateOfBirth, email, phoneNr, nationality, pos));
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill in all fields correctly.");
            }


        }
    }
}