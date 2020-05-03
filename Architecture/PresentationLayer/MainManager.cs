using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar.Classes;
using MySql.Data.MySqlClient;

namespace Media_Bazaar
{
    public partial class MainManager : Form
    {
        List<IEmployeeModel> employees = new List<IEmployeeModel>();
        List<IDepartmentModel> departments = new List<IDepartmentModel>();
        List<IRestockRequest> restocks = null;
        List<IEmployeeModel> allEmployees = null;
        List<DBSchedule> schedules = null;
        DataAccess db;
    
        public MainManager()
        {
            db = new DataAccess();
            allEmployees = db.GetAllEmployees();
            schedules = db.GetAllSchedules();
            restocks = db.GetAllRequests();
            InitializeComponent();

            UpdateList();
            CheckFiredAndWorkingChart();
            CheckAttendance();
            CheckRequests();
            CheckPositions();
        }

        private void UpdateList()
        {
            checkLbProfile.DataSource = employees;
            checkLbProfile.DisplayMember = "FullInfo";
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
            tbxSearchID.Clear();
            tbxSearchLastname.Clear();
            foreach (var series in chartEmplAttendance.Series)
            {
                series.Points.Clear();
            }
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
            if (tc.SelectedTab == tabEmployeeStats || tc.SelectedTab == tabShiftStats || tc.SelectedTab == tabDepartStats)
            {
                btnStatsTABdepart.BackColor = Color.FromArgb(32, 126, 177);
                btnStatsTABemployeeStats.BackColor = Color.FromArgb(32, 126, 177);
                btnStatisticsTABshiftStats.BackColor = Color.FromArgb(32, 126, 177);
            }
            else
            {
                if (tc.SelectedTab == tabSearchEmpl || tc.SelectedTab == tabProfile)
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
            if (cmbSelectSeachMethod.Text == "Last name")
            {
                employees = db.GetNotFiredEmployeesByLastName(this.tbxSearchLastname.Text);
                if(employees.Count == 0)
                {
                    MessageBox.Show("Employee with the specified last name cannot be found. He may be fired.");
                    tbxSearchLastname.Clear();
                }
                else
                {
                    UpdateList();
                    UpdateInfoByLastname(this.tbxSearchLastname.Text);
                    checkLbProfile.Visible = true;
                    btnViewProfile.Visible = true;
                }
                
            }
            else if (cmbSelectSeachMethod.Text == "ID")
            {
                employees = db.GetNotFiredEmployeesByID(Convert.ToInt32(this.tbxSearchID.Text));
                if(employees.Count == 0)
                {
                    MessageBox.Show("Employee with the specified ID cannot be found. He may be fired.");
                    tbxSearchID.Clear();
                }
                else
                {
                    UpdateList();
                    UpdateInfoByID(Convert.ToInt32(this.tbxSearchID.Text));
                    checkLbProfile.Visible = true;
                    btnViewProfile.Visible = true;
                }
                
            }
        }

        private void UpdateInfoByID(int id)
        {
            //display the data in the labels
            lbUpcomingShifts.Items.Clear();
            DateTime dateNow = DateTime.Today;
            string[] date = dateNow.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Split('/');

            employees = db.GetDBNotFiredEmployeeByID(id);
            foreach (IEmployeeModel empl in employees)
            {
                this.lblFirstName.Text = empl.FirstName;
                this.lblLastName.Text = empl.LastName;
                this.lblPosInCompany.Text = empl.Position;
                this.lblEmail.Text = empl.Email;
                this.lblPhoneNumber.Text = empl.PhoneNumber;
                this.lblNationality.Text = empl.Nationality;
                this.lblDateOfBirth.Text = empl.DateOfBirth;
            }
            schedules = db.GetSchedulesByEmplId(id);

            foreach (DBSchedule sch in schedules)
            {
                string[] dateShift = sch.Date.Split('/');
                if (((dateShift[2] == date[2]) && (dateShift[1] == date[1]) && (Convert.ToInt32(dateShift[0]) >= Convert.ToInt32(date[0]))))
                {
                    //if is not the upcoming day
                    lbUpcomingShifts.Items.Add($"{dateShift[0]}/{dateShift[1]}/{dateShift[2]} -> {sch.Shift}");
                }
                else
                {
                    //if the month has passed
                    if ((Convert.ToInt32(dateShift[1]) != Convert.ToInt32(date[1])) && (Convert.ToInt32(dateShift[1]) >= Convert.ToInt32(date[1])) && (dateShift[2] == date[2]) && ((Convert.ToInt32(dateShift[0]) >= Convert.ToInt32(date[0])) || (Convert.ToInt32(dateShift[0]) < Convert.ToInt32(date[0]))))

                    {
                        lbUpcomingShifts.Items.Add($"{dateShift[0]}/{dateShift[1]}/{dateShift[2]} -> {sch.Shift}");
                    }
                    else
                    {
                        //if the year is different
                        if ((Convert.ToInt32(dateShift[2]) != Convert.ToInt32(date[2])) && (Convert.ToInt32(dateShift[2]) >= Convert.ToInt32(date[2])) && ((Convert.ToInt32(dateShift[1]) >= Convert.ToInt32(date[1])) || (Convert.ToInt32(dateShift[1]) < Convert.ToInt32(date[1]))) && ((Convert.ToInt32(dateShift[0]) >= Convert.ToInt32(date[0])) || (Convert.ToInt32(dateShift[0]) < Convert.ToInt32(date[0]))))
                        {
                            lbUpcomingShifts.Items.Add($"{dateShift[0]}/{dateShift[1]}/{dateShift[2]} -> {sch.Shift}");
                        }
                    }
                }

            }
            CheckEmployeeAttendance(id);
        }

        private void UpdateInfoByLastname(string lastName)
        {
            //display the data in the labels
            lbUpcomingShifts.Items.Clear();
            DateTime dateNow = DateTime.Today;
      
            string[] date = dateNow.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Split('/');
            int employeeId = -1;
            employees = db.GetDBEmployeesByLastName(lastName);
            foreach(IEmployeeModel empl in employees)
            {
                this.lblFirstName.Text = empl.FirstName;
                this.lblLastName.Text = lastName;
                this.lblPosInCompany.Text = empl.Position;
                this.lblEmail.Text = empl.Email;
                this.lblPhoneNumber.Text = empl.PhoneNumber;
                this.lblNationality.Text = empl.Nationality;
                this.lblDateOfBirth.Text = empl.DateOfBirth;
                employeeId = empl.EmployeeID;
            }
            schedules = db.GetSchedulesByEmplId(employeeId);

            foreach(DBSchedule sch in schedules)
            {
                string[] dateShift = sch.Date.Split('/');
                if(((dateShift[2] == date[2]) && (dateShift[1] == date[1]) && (Convert.ToInt32(dateShift[0]) >= Convert.ToInt32(date[0]) )) )
                {
                    //if is not the upcoming day
                    lbUpcomingShifts.Items.Add($"{dateShift[0]}/{dateShift[1]}/{dateShift[2]} -> {sch.Shift}");
                }
                else
                {
                    //if the month has passed
                    if((Convert.ToInt32(dateShift[1]) != Convert.ToInt32(date[1])) && (Convert.ToInt32(dateShift[1]) >= Convert.ToInt32(date[1])) && (dateShift[2] == date[2]) && ((Convert.ToInt32(dateShift[0]) >= Convert.ToInt32(date[0])) || (Convert.ToInt32(dateShift[0]) < Convert.ToInt32(date[0]))))
                    
                    {
                        lbUpcomingShifts.Items.Add($"{dateShift[0]}/{dateShift[1]}/{dateShift[2]} -> {sch.Shift}");
                    }
                    else
                    {
                        //if the year is different
                        if( (Convert.ToInt32(dateShift[2]) != Convert.ToInt32(date[2]) ) && (Convert.ToInt32(dateShift[2]) >= Convert.ToInt32(date[2])) && ((Convert.ToInt32(dateShift[1]) >= Convert.ToInt32(date[1])) || (Convert.ToInt32(dateShift[1]) < Convert.ToInt32(date[1]) )) && ((Convert.ToInt32(dateShift[0]) >= Convert.ToInt32(date[0])) || (Convert.ToInt32(dateShift[0]) < Convert.ToInt32(date[0]))))
                        {
                            lbUpcomingShifts.Items.Add($"{dateShift[0]}/{dateShift[1]}/{dateShift[2]} -> {sch.Shift}");
                        }
                    }
                }    
            }
            CheckEmployeeAttendance(employeeId);
        }
        

        private void CheckFiredAndWorkingChart()
        {
            //nrFired = db.GetNumOfFired();
            //nrNotFired = db.GetNumOfnOTFired();
            int nrFired = 0;
            int nrNotFired = 0;
            foreach (IEmployeeModel employee in allEmployees)
            {
                if(employee.ReasonsForRelease == null)
                {
                    nrNotFired++;
                }
                else if(employee.ReasonsForRelease != null)
                {
                    nrFired++;
                }
            }        
            chartReleasedAndNot.Series["s1"].Points.AddXY("Fired", nrFired);
            chartReleasedAndNot.Series["s1"].Points.AddXY("Working", nrNotFired);
        }

        private void CheckPositions()
        {
            int nrAdmins = 0;
            int nrManagers = 0;
            int nrDepot = 0;
            //nrAmdins = db.GetNumAdmins();
            //nrManagers = db.GetNumManagers();
            //nrDepot = db.GetNumDepotWorkers();
            foreach(IEmployeeModel employee in allEmployees)
            {
                if(employee.Position == "ADMINISTRATOR")
                {
                    nrAdmins++;
                }
                else
                {
                    if(employee.Position == "MANAGER")
                    {
                        nrManagers++;
                    }
                    else
                    {
                        if(employee.Position == "DEPOT")
                        {
                            nrDepot++;
                        }
                    }
                }
            }
            chartPositions.Series["s1"].Points.AddXY("Administrators", nrAdmins);
            chartPositions.Series["s1"].Points.AddXY("Managers", nrManagers);
            chartPositions.Series["s1"].Points.AddXY("Depot workers", nrDepot);
        }

        int nrOfPresent = 0;
        int nrOfAbsent = 0;
        int nrOfLate = 0;
        private void CheckAttendance()
        {           
            //nrOfAbsent = db.GetNumOfAbsent();
            //nrOfPresent = db.GetNumOfPresent();
            //nrOfLate = db.GetNumOfLate();

            foreach(DBSchedule sch in schedules)
            {
                if(sch.Attendance == "PRESENT")
                {
                    nrOfPresent++;
                }
                else
                {
                    if(sch.Attendance == "LATE")
                    {
                        nrOfLate++;
                    }
                    else
                    {
                        if(sch.Attendance == "ABSENT")
                        {
                            nrOfAbsent++;
                        }
                    }
                }
            }
            chartAttendance.Series["s1"].Points.AddXY("Present", nrOfPresent);
            chartAttendance.Series["s1"].Points.AddXY("Absent", nrOfAbsent);
            chartAttendance.Series["s1"].Points.AddXY("Late", nrOfLate);
        }
        
        private void CheckEmployeeAttendance(int id)
        {
            nrOfAbsent = db.GetNumOfAbsentById(id);
            nrOfPresent = db.GetNumOfPresentById(id);
            nrOfLate = db.GetNumOfLateById(id);

            chartEmplAttendance.Series["s1"].Points.AddXY("Present", nrOfPresent);
            chartEmplAttendance.Series["s1"].Points.AddXY("Absent", nrOfAbsent);
            chartEmplAttendance.Series["s1"].Points.AddXY("Late", nrOfLate);

            chartEmplAttendance.Series["s1"]["PieLabelStyle"] = "Disabled";
        }

        private void CheckRequests()
        {
            //nrOfConfirmed = db.GetNumOfConfirmedRequests();
            //nrOfRejected = db.GetNumOfRejectedRequests();
            //nrOfWaiting = db.GetNumOfWaitingRequests();
            int nrOfConfirmed = 0;
            int nrOfRejected = 0;
            int nrOfWaiting = 0;

            foreach (IRestockRequest req in restocks)
            {
                if(req.AdminConfirmation == "CONFIRMED")
                {
                    nrOfConfirmed++;
                }
                else
                {
                    if(req.AdminConfirmation == "REJECTED")
                    {
                        nrOfRejected++;
                    }
                    else
                    {
                        if(req.AdminConfirmation == null)
                        {
                            nrOfWaiting++;
                        }
                    }
                }
            }
            chartRequests.Series["s1"].Points.AddXY("Confirmed", nrOfConfirmed);
            chartRequests.Series["s1"].Points.AddXY("Rejected", nrOfRejected);
            chartRequests.Series["s1"].Points.AddXY("Waiting", nrOfWaiting);

            /*chartEmplAttendance.Legends.Clear();
            chartEmplAttendance.Series.Clear();*/
        }

        

        private void btnSearchTABsearch_Click(object sender, EventArgs e)
        {
            checkLbProfile.Visible = false;
            btnViewProfile.Visible = false;
            tbxSearchLastname.Enabled = true;
            tbxSearchID.Enabled = true;
            
        }

        private void cmbSelectSeachMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSelectSeachMethod.Text == "Last name")
            {
                tbxSearchID.Enabled = false;
                tbxSearchLastname.Enabled = true;
            }
            else
            {
                tbxSearchLastname.Enabled = false;
                tbxSearchID.Enabled = true;
            }
        }

        private void btnEmployeesTABemplStats_Click(object sender, EventArgs e)
        {

        }
    }

}
