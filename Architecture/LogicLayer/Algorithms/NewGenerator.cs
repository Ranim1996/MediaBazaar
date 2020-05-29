using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.LogicLayer.Algorithms
{
    public class NewGenerator
    {
        //key=>emplId ; value=>preferredShifts. stores the prefered shifts per a specific day
        List<EmployeeBase> employeesPreferences;
        DataAccess db;

        public NewGenerator()
        {
            employeesPreferences = new List<EmployeeBase>();
            db = new DataAccess();
        }

        public void AssignPreferences(DateTime date, string position, string department, string shift)
        {
            foreach(EmployeeBase employee in employeesPreferences)
            {
                //if(employee.)
            }
        }
        public void GenerateScheduleWeek(string department, int nrOfAdmins, int nrOfManagers, int nrOfDepot, int nrOfEmpl)
        {

        }
    }
}
