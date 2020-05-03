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
        private static DateTime currentDate = DateTime.Today;
        //private static DateTime date = new DateTime();

        public Calendar()
        {
            listFlDay = new List<FlowLayoutPanel>();
            //currentDate ;
        }

        MainAdmin main;

        /*public int GetCurrentYear
        {
            get { return this.currentDate.Year; }
        }
        public int GetCurrentMonth
        {
            get { return this.currentDate.Month; }
        }*/
        public DateTime GetDate()
        {
            return currentDate;
        }
        // -- functions --
        private int GetFirstDayOfWeekOfCurrentDate()
        {
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            return Convert.ToInt32(firstDayOfMonth.DayOfWeek + 1);
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
            //date = currentDate;
        }
        public void NextMonth(List<DBSchedule> list, Label lb)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayCurrentDate(list, lb);
            //date = currentDate;
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
            main = new MainAdmin();
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
                fl.Cursor = Cursors.Hand;
                fl.Click += new EventHandler(main.Flow_Click);
                fl.AutoScroll = true;
                fl.WrapContents = false;
                flDays.Controls.Add(fl);
                listFlDay.Add(fl);
            }

        }

        List<DBSchedule> listForTheDay = new List<DBSchedule>();

        // -- modified part
        public void AddLabelDayToFlDay(int startDayAtFlNumber, int totalDaysInMonth, List<DBSchedule> schedules)
        {
            //needs to be adjusted ---> WORK IN PROGGRESS
            //string[] date = DateTime.Now.ToString("dd/MM/yyyy").Split('/');
            string[] date = currentDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Split('/');
           /* int reset;
            int nr = 0;
            int ok = 1;*/
            foreach (FlowLayoutPanel fl in listFlDay)
            {
                fl.Controls.Clear();
                fl.Tag = 0;
                fl.BackColor = Color.White;
                fl.AutoScroll = true;
            }
            for (int i = 1; i <= totalDaysInMonth; i++)
            {
                /*string topic = "";
                string time = "";
                string info = "";// -- experimental ---> sub tab for calendar*/

                // -- label date
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(120, 23);
                lbl.Text = i.ToString();
                lbl.Font = new Font("Arial", 10, FontStyle.Bold);
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Tag = i;
                listFlDay[(i - 1) + (startDayAtFlNumber - 1)].Controls.Add(lbl);


                //change the color of today
                if (new DateTime(currentDate.Year, currentDate.Month, i) == DateTime.Today)
                {
                    listFlDay[(i - 1) + (startDayAtFlNumber - 1)].BackColor = Color.Bisque;
                }

               
                //-------------------------------------------------------------------------------------------
            }
        }
        
      

      
    }
}
