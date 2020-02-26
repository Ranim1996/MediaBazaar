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
        public void PrevMonth(Label lb)
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayCurrentDate(lb);
        }
        public void NextMonth( Label lb)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayCurrentDate(lb);
        }
        public void Today( Label lb)
        {
            currentDate = DateTime.Today;
            DisplayCurrentDate(lb);
        }
        public void DisplayCurrentDate(Label lb)
        { 
            lb.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekOfCurrentDate();
            int totalDay = GetTotalDaysOfCurrentDate();
            AddLabelDayToFlDay(firstDayAtFlNumber, totalDay);
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
                fl.Size = new Size(130, 95);
                fl.BackColor = Color.White;
                fl.BorderStyle = BorderStyle.FixedSingle;
                fl.AutoScroll = true;
                flDays.Controls.Add(fl);
                listFlDay.Add(fl);
            }
        }
        
        // -- modified part
        public void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth)
        {
            //needs to be adjusted ---> WORK IN PROGGRESS
            //string[] date = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            string[] date = currentDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Split('/');
            int reset;
            int nr = 0;
            int ok = 1;
            foreach (FlowLayoutPanel fl in listFlDay)
            {
                fl.Controls.Clear();
                fl.Tag = 0;
                fl.BackColor = Color.White;
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
                lbl.Size = new Size(120, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Arial", 10);
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lbl);


                //HERE ADD A REFERENCE for the day 
                //-----Add the tag for each panel to recognize the day
                //------------using the first day of the month 
                DayOfWeek nextDay2 = new DayOfWeek();
                nextDay2 = GetFirstDayOfMonth();
                reset = (int)nextDay2;
                nextDay2 = (DayOfWeek)(((int)reset + nr) % 7);
                nr++;
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = nextDay2;
                //--------------------


                //change the color of today
                if (new DateTime(currentDate.Year, currentDate.Month, i) == DateTime.Today)
                {
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Bisque;
                }

                // -- BETA ---> INFORMATION LAYOUT 
                // -- modified part
                /* List<Event> listForTheDay_RAW = new List<Event>();
                 List<Event> listForTheDay = new List<Event>();

                 // -- gets only the events i need
                 foreach (Event evnts in events)
                 {
                     string[] dateEvent = evnts.Date.Split('/');

                     if ((dateEvent[2] == date[2]) && (dateEvent[1] == date[1]) && (Convert.ToInt32(dateEvent[0]) == i) && (evnts.Status == "Approved"))
                     {
                         listForTheDay_RAW.Add(evnts);
                     }
                 }
                 // -- re-orders them ---> experimental
                 for (int h = 0; h < 23; h++) // -- hours
                 {
                     for (int m = 0; m < 59; m++) // -- minutes
                     {
                         foreach (Event evnts in listForTheDay_RAW)
                         {
                             string[] timeStamp = evnts.Time.Split(':');

                             if(Convert.ToInt32(timeStamp[0]) == h)
                             {
                                 if(Convert.ToInt32(timeStamp[1]) == m)
                                 {
                                     listForTheDay.Add(evnts);
                                 }
                             }

                         }
                     } 
                 }
                 // constructor
                 // -- modified part ---> topic and event info
                 int y = 0;
                 foreach(Event eOfDay in listForTheDay)
                 {
                     Label lblInfo = new Label();
                     lblInfo.Name = $"lblInfo{i}{y}";
                     lblInfo.AutoSize = false;
                     lblInfo.TextAlign = ContentAlignment.MiddleCenter;
                     lblInfo.Size = new Size(120, 23);
                     lblInfo.Text = $"{eOfDay.Time}     {eOfDay.Topic}"; // topic
                     lblInfo.Font = new Font("Arial", 10);
                     listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                     listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lblInfo);
                     y++;
                 } */
                //-------------------------------------------------------------------------------------------




            }
        }
        

      
    }
}
