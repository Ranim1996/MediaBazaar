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
using System.Net;
using System.Net.Mail;

namespace Media_Bazaar
{
    public partial class MainAdmin : Form
    {

        List<DBEmployee> Allemployees = new List<DBEmployee>();
        List<DBEmployee> ReleasedEmployees = new List<DBEmployee>();
        List<DBEmployee> NotReleasedEmployees = new List<DBEmployee>();
        List<DBDepartament> departaments = new List<DBDepartament>();
        List<DBRestockRequest> restockRequests = new List<DBRestockRequest>();


        List<int> employeesID = new List<int>();
        List<int> restockID = new List<int>();
        //holds the calendar
        Media_Bazaar.Classes.Calendar calendar = new Classes.Calendar();

        DataAccess db;

        DBSchedule schedule = new DBSchedule();
        private object send;

        public MainAdmin()
        {
            InitializeComponent();
            UpdateEmployeeInfo();
            UpdateDepartamentInfo();
            UpdateRestockInfo();
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
            schedule.GetAllSchedules();
            calendar.GenerateDayPanel(42, flDays);
            calendar.DisplayCurrentDate(schedule.allSchedules, lblMonthAndYear);

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
            UpdateEmployeeInfo();
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
            UpdateRestockInfo();
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
            calendar.PrevMonth(schedule.allSchedules, lblMonthAndYear);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            calendar.Today(schedule.allSchedules, lblMonthAndYear);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            calendar.NextMonth(schedule.allSchedules, lblMonthAndYear);
        }

        public void linkLabel_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            LinkLabel link = (LinkLabel)sender;
            //the linkLabel.Tag is the employeeID
            sender = link.Tag;
            int ok = 1;
            string shiftDetails = db.GetShiftDetailsById(Convert.ToInt32(sender));
            string shiftDate = db.GetShiftDateById(Convert.ToInt32(sender));
            int employeeId = Convert.ToInt32(sender);

            MessageBoxManager.Yes = "On Time";
            MessageBoxManager.No = "Late";
            MessageBoxManager.Cancel = "Absent";
            MessageBoxManager.Register();
            DialogResult dialog = MessageBox.Show($"ID({employeeId}): {shiftDetails}", "Attendance!", MessageBoxButtons.YesNoCancel);
            MessageBoxManager.Unregister();
            if (dialog == DialogResult.None)
            {
                ok = 0;
            }
            if (dialog == DialogResult.Yes && ok == 1)
            {
                string attendance = "PRESENT";
                db.AddAttendanceForEmployeeByIdAndShift(employeeId, attendance, shiftDetails, shiftDate);
                link.BackColor = Color.LightGreen;
            }
            else
            {
                if(dialog == DialogResult.No && ok == 1)
                {
                    string attendance = "LATE";
                    db.AddAttendanceForEmployeeByIdAndShift(employeeId, attendance, shiftDetails, shiftDate);
                    link.BackColor = Color.Yellow;
                }
                else
                {
                    if(dialog == DialogResult.Cancel && ok == 1)
                    {
                        string attendance = "ABSENT";
                        db.AddAttendanceForEmployeeByIdAndShift(employeeId, attendance, shiftDetails, shiftDate);
                        link.BackColor = Color.Red;
                    }                  
                     //I DONT KNOW HOW TO FIX THIS
                     //When you press 'X' to close the messageBox , is automatically set to DialogResult.Cancel so it is set to ABSENT and the color of the link is set to red
                     //TRY TO FIX THIS
                }
            }
        }

        /*public void linkLabel_DoubleClick(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            LinkLabel link = (LinkLabel)sender;
            //the linkLabel.Tag is the employeeID
            sender = link.Tag;

            string shiftDetails = db.GetShiftDetailsById(Convert.ToInt32(sender));
            int employeeId = Convert.ToInt32(sender);
            DialogResult dialog = MessageBox.Show($"ID({employeeId}): {shiftDetails}", "Delete Shift", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {

            }
        }*/

        //------------------------------------------------------------------------------------------

        private void CreateEmpl(string fName, string lName, string dateOfBirth, string email, string phoneNr, string nationality, JobPosition pos)
        {
            string username = autoGenerateUsername(fName, lName, pos);
            string password = autoGeneratePassword();
            DataAccess db = new DataAccess();
            db.InsertEmployee(fName, lName, dateOfBirth, email, phoneNr, nationality, pos.ToString(), username, password);
            //get the employee id from database
            int employeeID = db.GetIdOfEmployeeByName(fName, lName);
            tbEmployeeID.Text = employeeID.ToString();
            tbUsername.Text = username;
            tbPassword.Text = password;
            SendEmail(email, username, password);
        }

        private void btnAddNewProfile_Click_1(object sender, EventArgs e)
        {
            string fName = "";
            string lName = "";
            string dateOfBirth = "";
            string email = "";
            string phoneNr = "";
            string nationality = "";
            string username = "";
            string password = "";
            JobPosition pos = JobPosition.ADMINISTRATOR;

            if (tbFirstName.Text != "" && tbLastName.Text != "" && tbDateOfBirth.Text != "" && tbEmail.Text != "" && tbEmail.Text != "" && tbPhoneNr.Text != "" && tbNationality.Text != "")
            {
                fName = tbFirstName.Text;
                lName = tbLastName.Text;
                dateOfBirth = tbDateOfBirth.Text;
                email = tbEmail.Text;
                phoneNr = tbPhoneNr.Text;
                nationality = tbNationality.Text;

                if (rbAdministrator.Checked)
                {
                    /*//administrator                   
                    username = autoGenerateUsername(fName, lName, pos);
                    password = autoGeneratePassword();
                    DataAccess db = new DataAccess();
                    db.InsertEmployee(fName, lName, dateOfBirth, email, phoneNr, nationality, pos.ToString(), username, password);
                    //get the employee id from database
                    int employeeID = db.GetIdOfEmployeeByName(fName, lName);
                    //adding the info in the textboxes that cannot be edited
                    tbEmployeeID.Text = employeeID.ToString();
                    tbUsername.Text = username;
                    tbPassword.Text = password;
                    SendEmail(email, username, password);*/
                    pos = JobPosition.ADMINISTRATOR;
                    CreateEmpl(fName, lName, dateOfBirth, email, phoneNr, nationality, pos);
                }
                else
                {
                    if (rbManager.Checked)
                    {
                        //Manager
                        pos = JobPosition.MANAGER;
                        CreateEmpl(fName, lName, dateOfBirth, email, phoneNr, nationality, pos);
                    }
                    else if (rbDepotWorker.Checked)
                    {
                        //Depot worker
                        pos = JobPosition.DEPOT;
                        CreateEmpl(fName, lName, dateOfBirth, email, phoneNr, nationality, pos);
                    }
                    else if(rbEmployee.Checked)
                    {
                        //Employee
                        pos = JobPosition.EMPLOYEE;
                        CreateEmpl(fName, lName, dateOfBirth, email, phoneNr, nationality, pos);
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill in all fields correctly.");
            }
        }

        //Useable methods for autogenerating username and Pass
        //----------------------------
        public String autoGenerateUsername(string fName, string lName, JobPosition pos)
        {
            string position = pos.ToString();
            return $"{fName.ToLower()}.{lName.ToLower()}.{position.ToLower()}@mediabazaar";
        }
        public String autoGeneratePassword()
        {
            List<String> password = new List<String>();
            //the autogenerated password will have 8characters(containing symbols)
            password = PasswordGenerator.GeneratePasswords(8, 1, true);
            foreach (String pass in password)
            {
                return pass;
            }
            return null;
        }
        //----------------------------------


        private void btnCreateProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New employee account has been successfully created.");
            tbFirstName.Clear();
            tbLastName.Clear();
            tbDateOfBirth.Clear();
            tbEmail.Clear();
            tbPhoneNr.Clear();
            tbNationality.Clear();
            tbEmployeeID.Clear();
            tbUsername.Clear();
            tbPassword.Clear();
        }
        private void UpdateEmployeeInfo()
        {
            DataAccess db = new DataAccess();
            NotReleasedEmployees = db.GetNotFiredEmployees();
            foreach (DBEmployee e in NotReleasedEmployees)
            {
                employeesID.Add(e.GetID());
            }
            checkedListBox2.DataSource = NotReleasedEmployees;
            checkedListBox2.DisplayMember = "FullInfo";

            checkedListBox3.DataSource = NotReleasedEmployees;
            checkedListBox3.DisplayMember = "FullInfo";
        }
        private void UpdateDepartamentInfo()
        {
            DataAccess db = new DataAccess();

            departaments = db.GetAllDepartaments();
            lbDepartaments.DataSource = departaments;
            lbDepartaments.DisplayMember = "FullInfo";

            foreach (DBDepartament dBD in departaments)
            {
                cmbDepartments.Items.Add(dBD.GetName());
            }
        }

        private void UpdateRestockInfo()
        {
            DataAccess db = new DataAccess();
            restockRequests = db.GetAllRequests();
            foreach (DBRestockRequest rr in restockRequests)
            {
                restockID.Add(rr.GetID());
            }
            checkedListBox1.DataSource = restockRequests;
            checkedListBox1.DisplayMember = "FullInfo";
        }


        private void btnRemoveProfile_Click(object sender, EventArgs e)
        {

            if (checkedListBox2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select employee");

            }
            else
            {
                if (String.IsNullOrEmpty(tbExtraInformationTABremoveProfile.Text))
                {
                    MessageBox.Show("Please enter information for release");
                }
                else
                {
                    DBEmployee temp = new DBEmployee();
                    DataAccess db = new DataAccess();
                    foreach (int i in employeesID)
                    {
                        if (checkedListBox2.SelectedItem != null)
                        {
                            string empl = checkedListBox2.GetItemText(checkedListBox2.SelectedItem);
                            if (empl.Contains($"ID:{i}"))
                            {
                                db.FireEmployeeByID(tbExtraInformationTABremoveProfile.Text, i);
                            }


                        }

                    }


                }
            }
            UpdateEmployeeInfo();
        }

        private void btnRemoveProfTABremoveProfile_Click(object sender, EventArgs e)
        {
            UpdateEmployeeInfo();
        }

        private void btnCreateDepartment_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            db.InsertDepartament(tbDepName.Text, Convert.ToInt32(tbMinNr.Text), Convert.ToInt32(tbMaxNr.Text));
            UpdateDepartamentInfo();
        }

        //Email generator
        public void SendEmail(string receiverEmail, string username, string password)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("media.bazaar2020@gmail.com");
                message.To.Add(receiverEmail);
                message.Body = $"Welcome to Media Bazaar company. \n" + "\n" + "\n" +
                    $"Below you can find your account details which you will have to use when accessing your account. \n" +
                    $"Username: {username} \n" +
                    $"Password: {password} \n" + "\n" +
                    $"You can change your password using the website.";
                message.Subject = "Login Credentials";
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;

                client.Credentials = new System.Net.NetworkCredential("media.bazaar2020@gmail.com", "Mediabazaar2020");
                client.Send(message);
                message = null;

            }

            catch (Exception s)
            {
         
            }

        }

        private void btnAssignToDepartment_Click(object sender, EventArgs e)
        {

            if (checkedListBox3.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select employee");

            }
            else
            {
                if (cmbDepartments.SelectedItem == null)
                {
                    MessageBox.Show("Please select departament");
                }
                else
                {
                    DBEmployee temp = new DBEmployee();
                    DataAccess db = new DataAccess();
                    foreach (int i in employeesID)
                    {
                        if (checkedListBox3.SelectedItem != null)
                        {
                            string empl = checkedListBox3.GetItemText(checkedListBox3.SelectedItem);
                            if (empl.Contains($"ID:{i}"))
                            {
                                db.AssignEmployeeToDepartament(i, cmbDepartments.SelectedItem.ToString());

                            }


                        }

                    }


                }
            }
            UpdateEmployeeInfo();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select request");

            }
            else
            {
                DBRestockRequest temp = new DBRestockRequest();
                DataAccess db = new DataAccess();
                foreach (int i in restockID)
                {
                    if (checkedListBox1.SelectedItem != null)
                    {
                        string req = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
                        if (req.Contains($"ID:{i}"))
                        {
                            db.ConfirmRequest(i);
                        }
                    }
                }
            }
            UpdateRestockInfo();
        }

        private void btnRestockReqTABrestock_Click(object sender, EventArgs e)
        {
            UpdateRestockInfo();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select request");

            }
            else
            {
                DBRestockRequest temp = new DBRestockRequest();
                DataAccess db = new DataAccess();
                foreach (int i in restockID)
                {
                    if (checkedListBox1.SelectedItem != null)
                    {
                        string req = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
                        if (req.Contains($"ID:{i}"))
                        {
                            db.RejectRequest(i);
                        }
                    }
                }
            }
            UpdateRestockInfo();
        }

        private void btnAssignWorkShift_Click(object sender, EventArgs e)
        {
            int employeeId = -1;         
            string date = "";
            string shift = "";
            if(tbEmployeeIdAssignShift.Text != "" && dateTimePicker1.Value != null && (cmbBxWorkShiftSaturday.SelectedItem != null || cmbBxWorkShiftSunday.SelectedItem != null || cmbBxWorkShiftWeekDay.SelectedItem != null))
            {
                employeeId = Convert.ToInt32(tbEmployeeIdAssignShift.Text);
                date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                DayOfWeek day = dateTimePicker1.Value.DayOfWeek;
                if( day == DayOfWeek.Sunday)
                {
                    shift = "12:00-18:00";
                }
                else
                {
                    if(day == DayOfWeek.Saturday && cmbBxWorkShiftSaturday.SelectedItem.ToString() == "Morning -> 9:00-15:00")
                    {
                        shift = "9:00-15:00";
                    }
                    else
                    {
                        if(day == DayOfWeek.Saturday && cmbBxWorkShiftSaturday.SelectedItem.ToString() == "Afternoon -> 15:00-18:00")
                        {
                            shift = "15:00-18:00";
                        }
                        else
                        {
                            if(cmbBxWorkShiftWeekDay.SelectedItem.ToString() == "Morning -> 7:00-12:00")
                            {
                                shift = "7:00-12:00";
                            }
                            else
                            {
                                if(cmbBxWorkShiftWeekDay.SelectedItem.ToString() == "Afternoon -> 12:00-17:00")
                                {
                                    shift = "12:00-17:00";
                                }
                                else
                                {
                                    if(cmbBxWorkShiftWeekDay.SelectedItem.ToString() == "Evening-> 17:00 - 22:00")
                                    {
                                        shift = "17:00-22:00";
                                    }
                                }
                            }
                        }
                    }
                }                
            }
            else
            {
                MessageBox.Show("Fill in all fields.");
            }
            DataAccess db = new DataAccess();
            if(employeeId != -1 && date != "" && shift != "")
            {
                List<DBEmployee> empl = db.GetDBEmployeeByID(employeeId);
                if(empl.Count != 0)
                {
                    db.AddSchedule(employeeId, date, shift);
                }
                else
                {
                    MessageBox.Show("No employee found with the specified ID.");
                }

            }
            schedule.GetAllSchedules();
            calendar.GenerateDayPanel(42, flDays);
            calendar.DisplayCurrentDate(schedule.allSchedules, lblMonthAndYear);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DayOfWeek day = dateTimePicker1.Value.DayOfWeek;
            //showing the combo box with the work shifts depending on what day is chosen
            switch (day)
            {
                case DayOfWeek.Sunday:
                    {
                        cmbBxWorkShiftSunday.Visible = true;
                        cmbBxWorkShiftSaturday.Visible = false;
                        cmbBxWorkShiftWeekDay.Visible = false;
                        break;
                    }
                case DayOfWeek.Saturday:
                    {
                        cmbBxWorkShiftSaturday.Visible = true;
                        cmbBxWorkShiftSunday.Visible = false;
                        cmbBxWorkShiftWeekDay.Visible = false;
                        break;
                    }
                default:
                    {
                        cmbBxWorkShiftWeekDay.Visible = true;
                        cmbBxWorkShiftSunday.Visible = false;
                        cmbBxWorkShiftSaturday.Visible = false;
                        break;
                    }
            }
        }

        private void btnNewProfTABaddProf_Click(object sender, EventArgs e)
        {

        }
    }
}