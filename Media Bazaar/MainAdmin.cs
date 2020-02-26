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

        Administration administration = new Administration();
        List<DBEmployee> Allemployees = new List<DBEmployee>();
        List<DBEmployee> ReleasedEmployees = new List<DBEmployee>();
        List<DBEmployee> NotReleasedEmployees = new List<DBEmployee>();
        List<DBDepartament> departaments = new List<DBDepartament>();

        List<int> employeesID = new List<int>();
        //holds the calendar
        Media_Bazaar.Classes.Calendar calendar = new Classes.Calendar();




        public MainAdmin()
        {
            InitializeComponent();
            UpdateEmployeeInfo();
            UpdateDepartamentInfo();
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
     
        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<FlowLayoutPanel> list = new List<FlowLayoutPanel>();            
            list = calendar.listFlDay;
            foreach (FlowLayoutPanel fl in list)
            {   
                fl.Click += new System.EventHandler(this.listFlDays_Click);
                fl.MouseHover += new System.EventHandler(this.listFlDays_MouseHover);
            }
        }
        private void listFlDays_Click(object sender, EventArgs e)
        {
            //Write here the actions when you click a day
            FlowLayoutPanel fl = (FlowLayoutPanel)sender;

            listBox1.Items.Add(calendar.GetFirstDayOfMonth);
            listBox1.Items.Add(calendar.GetTotalDaysOfCurrentDate());  

            //DateTime day;

        }
        //hover
        private void listFlDays_MouseHover(object sender, EventArgs e)
        {
            FlowLayoutPanel fl = (FlowLayoutPanel)sender;
            fl.Cursor = (Cursor)Cursors.Hand;
        }
        //------------------------------------------------------------------------------------------



        private void btnAddNewProfile_Click_1(object sender, EventArgs e)
        {
            string fName="";
            string lName="";
            string dateOfBirth="";
            string email="";
            string phoneNr="";
            string nationality="";
            string username="";
            string password="";
            JobPosition pos=JobPosition.ADMINISTRATOR;                       

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
                    //administrator
                    pos = JobPosition.ADMINISTRATOR;
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
                    SendEmail(email, username, password);
                }
                else
                {
                    if (rbManager.Checked)
                    {
                        //Manager
                        pos = JobPosition.MANAGER;
                        username = autoGenerateUsername(fName, lName, pos);
                        password = autoGeneratePassword();
                        DataAccess db = new DataAccess();
                        db.InsertEmployee(fName, lName, dateOfBirth, email, phoneNr, nationality, pos.ToString(), username, password);
                        //get the employee id from database
                        int employeeID = db.GetIdOfEmployeeByName(fName, lName);
                        tbEmployeeID.Text = employeeID.ToString();
                        tbUsername.Text = username;
                        tbPassword.Text = password;
                        SendEmail(email, username, password);
                    }
                    else if (rbDepotWorker.Checked)
                    {
                        //Depot worker
                        pos = JobPosition.DEPOT;
                        username = autoGenerateUsername(fName, lName, pos);
                        password = autoGeneratePassword();
                        DataAccess db = new DataAccess();
                        db.InsertEmployee(fName, lName, dateOfBirth, email, phoneNr, nationality, pos.ToString(), username, password);
                        //get the employee id from database
                        int employeeID = db.GetIdOfEmployeeByName(fName, lName);
                        tbEmployeeID.Text = employeeID.ToString();
                        tbUsername.Text = username;
                        tbPassword.Text = password;
                        SendEmail(email, username, password);
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
            foreach(DBEmployee e in NotReleasedEmployees)
            {
                employeesID.Add(e.GetID());
            }
            checkedListBox2.DataSource = NotReleasedEmployees;
            checkedListBox2.DisplayMember = "FullInfo";
        }

        private void UpdateDepartamentInfo()
        {
            DataAccess db = new DataAccess();
            departaments = db.GetAllDepartaments();
           
            lbDepartaments.DataSource = departaments;
            lbDepartaments.DisplayMember = "FullInfo";
        }


        private void btnRemoveProfile_Click(object sender, EventArgs e)
        {
            
            if (checkedListBox2.CheckedItems.Count ==0 )
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
                        if(checkedListBox2.SelectedItem != null)
                        {
                            string empl = checkedListBox2.GetItemText(checkedListBox2.SelectedItem);
                            if(empl.Contains($"ID:{i}"))
                            {
                                db.FireEmployeeByID(tbExtraInformationTABremoveProfile.Text,i);
                                MessageBox.Show("yes");
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

        
    }
}