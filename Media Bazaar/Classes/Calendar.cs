using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;


namespace Media_Bazaar.Classes
{
    public class Calendar 
    {
        //list with dates and their info
        public List<FlowLayoutPanel> listFlDay { get; private set; }

        //date that gets modified based on the controls of the form ---> used as a refrence in other months
        private DateTime currentDate = DateTime.Today;

        public Calendar()
        {
            listFlDay = new List<FlowLayoutPanel>();

        }

        // -- functions --
        private int GetFirstDayOfWeekOfCurrentDate()
        {
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            return Convert.ToInt32(firstDayOfMonth.DayOfWeek + 1);
        }
        private DayOfWeek GetFirstDayOfMonth()
        {
            DateTime first = new DateTime(currentDate.Year, currentDate.Month, 1);
            return first.DayOfWeek;
        }

        public int GetTotalDaysOfCurrentDate()
        {
            DateTime firstDayOfCurrentDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            return firstDayOfCurrentDate.AddMonths(1).AddDays(-1).Day;
        }

        // -- methods --
        //used in the buttons
        public void PrevMonth(List<DBSchedule> list, Label lb)
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayCurrentDate(list, lb);
        }
        public void NextMonth(List<DBSchedule> list, Label lb)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayCurrentDate(list, lb);
        }
        public void Today(List<DBSchedule> list, Label lb)
        {
            currentDate = DateTime.Today;
            DisplayCurrentDate(list, lb);
        }
        public void DisplayCurrentDate(List<DBSchedule> list, Label lb)
        { 
            lb.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekOfCurrentDate();
            int totalDay = GetTotalDaysOfCurrentDate();
            AddLabelDayToFlDay(firstDayAtFlNumber, totalDay, list);
        }

        // -- MAIN methods --
        public void GenerateDayPanel(int totalDays,FlowLayoutPanel flDays)
        {
            flDays.Controls.Clear();
            listFlDay.Clear();
            for (int i = 1; i <= totalDays; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDay{i}";
                fl.Size = new Size(140, 95);
                fl.BackColor = Color.White;
                fl.BorderStyle = BorderStyle.FixedSingle;
                fl.FlowDirection = FlowDirection.TopDown;

                fl.AutoScroll = true;
                fl.WrapContents = false;
                flDays.Controls.Add(fl);
                listFlDay.Add(fl);
            }

        }
        
        // -- modified part
        public void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth, List<DBSchedule> schedules)
        {
            //needs to be adjusted ---> WORK IN PROGGRESS
            //string[] date = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            string[] date = currentDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Split('/');
            int reset;
            int nr = 0;
            int ok = 1;
            foreach (FlowLayoutPanel fl in listFlDay)
            {
                //fl.Controls.Clear();
                fl.Tag = 0;
                fl.BackColor = Color.White;
                fl.AutoScroll = true;
            }
            for (int i = 1; i <= totalDaysInMonth; i++)
            {
                string topic = "";
                string time = "";
                string info = "";// -- experimental ---> sub tab for calendar

                // -- label date
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(130, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Arial", 10, FontStyle.Bold);
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lbl);


                //change the color of today
                if (new DateTime(currentDate.Year, currentDate.Month, i) == DateTime.Today)
                {
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Bisque;
                }

                // -- BETA ---> Get the chosen work shifts 

                 List<DBSchedule> listForTheDay= new List<DBSchedule>();

                 // -- gets only the shifts i need
                 foreach (DBSchedule sch in schedules)
                 {
                     string[] dateSchedule = sch.Date.Split('/');

                     if ((dateSchedule[2] == date[2]) && (dateSchedule[1] == date[1]) && (Convert.ToInt32(dateSchedule[0]) == i))
                     {
                         listForTheDay.Add(sch);
                     }
                 }

                // constructor
                // -- modified part ---> topic and event info
                 DataAccess db = new DataAccess();
                 int y = 0;
                 foreach(DBSchedule schOfTheDay in listForTheDay)
                 {
                    MainAdmin main = new MainAdmin();
                    string firstNameOfEmployee;
                    int id = schOfTheDay.EmployeeId;
                    string attendance = schOfTheDay.Attendance;
                    
                    firstNameOfEmployee = db.GetFirstNameOfEmployeeById(id);
                    LinkLabel lblInfo = new LinkLabel();                    
                    lblInfo.Name = $"lblInfo{i}{y}";

                    //adding the id for the shift to be recognized when clicked in the form  <for attendance>
                    lblInfo.Tag = $"{id}";
                    //db.AddShiftId(Convert.ToInt32(lblInfo.Tag));

                    lblInfo.AutoSize = false;
                    lblInfo.TextAlign = ContentAlignment.MiddleCenter;
                    lblInfo.Size = new Size(120, 23);
                    lblInfo.Text = $"ID({id}): {schOfTheDay.Shift}"; // chosen shift and the name+id of the employee
                    lblInfo.Font = new Font("Arial", 9, FontStyle.Bold);

                    lblInfo.Click += new EventHandler(main.linkLabel_Click);
                    //lblInfo.DoubleClick += new EventHandler(main.LinkLabel_DoubleClick);
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lblInfo);
                    y++;
                 } 
                //-------------------------------------------------------------------------------------------




            }
        }
        

      
    }
}
