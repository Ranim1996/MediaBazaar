using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar.Classes
{
    public class DBSchedule
    {
        public int EmployeeId { get; private set; }
        public String Date { get; private set; }
        public String Shift { get; private set; }
        public String Attendance { get; private set; }

        public List<DBSchedule> allSchedules { get; private set; }
        

        public void GetAllSchedules()
        {
            DataAccess db = new DataAccess();
            try
            {
                allSchedules = db.GetAllSchedules();
            }
            catch
            {
                MessageBox.Show("Connection to the server was not possible!");
            }
        }
    }
}
