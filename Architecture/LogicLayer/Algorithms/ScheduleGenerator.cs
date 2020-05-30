using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class ScheduleGenerator
    {
        DataAccess dataAccess = new DataAccess();


        List<EmployeeBase> employeesWithPreferencesForAssigning = new List<EmployeeBase>();


        //all employees with preferences are assigned to these 3 lists
        List<EmployeeBase> firstShift = new List<EmployeeBase>(); 
        List<EmployeeBase> secondShift = new List<EmployeeBase>(); 
        List<EmployeeBase> thirdShift = new List<EmployeeBase>(); 

        string firstShiftPeriod = "";
        string secondShiftPeriod = "";
        string thirdShiftPeriod = "";

        int nrWorkingHoursFirstShift = 0;
        int nrWorkingHoursSecondShift = 0;
        int nrWorkingHoursThirdShift = 0;


        //checks which employees can still work (didn't exceed their hours) for a certain day (by department)
        private void CheckEmployeesWhichCanWork(DateTime date,string department)
        {
            foreach (EmployeeBase employee in dataAccess.GetEmployeesPreferencesForDayByDepartment(date.ToString("dd/MM/yyyy"),department))
            {
                if (dataAccess.GetMaxHoursByID(employee.EmployeeID) > dataAccess.GetCurrentHoursByID(employee.EmployeeID))
                {
                    employeesWithPreferencesForAssigning.Add(employee);
                }
            }
        }

        private void SeparateThePreferredShiftPerDay(DateTime date)
        {
            if (date.DayOfWeek.ToString() == "Saturday")
            {
                firstShiftPeriod = "09:00-15:00";
                secondShiftPeriod = "15:00-18:00";

                nrWorkingHoursFirstShift = 6;
                nrWorkingHoursSecondShift = 3;

                foreach (EmployeeBase employee in employeesWithPreferencesForAssigning)
                {
                    if (dataAccess.GetShiftPreferences(date.ToString("dd/MM/yyyy"), employee.EmployeeID) == firstShiftPeriod)
                    {
                        firstShift.Add(employee);
                    }
                    else if (dataAccess.GetShiftPreferences(date.ToString("dd/MM/yyyy"), employee.EmployeeID) == secondShiftPeriod)
                    {
                        secondShift.Add(employee);
                    }
                }
            }
            else if (date.DayOfWeek.ToString() == "Sunday")
            {
                firstShiftPeriod = "12:00-18:00";

                nrWorkingHoursFirstShift = 6;

                foreach (EmployeeBase employee in employeesWithPreferencesForAssigning)
                {
                    if (dataAccess.GetShiftPreferences(date.ToString("dd/MM/yyyy"), employee.EmployeeID) == firstShiftPeriod)
                    {
                        firstShift.Add(employee);
                    }
                }
            }
            else
            {
                firstShiftPeriod = "07:00-12:00";
                secondShiftPeriod = "12:00-17:00";
                thirdShiftPeriod = "17:00-22:00";

                nrWorkingHoursFirstShift = 5;
                nrWorkingHoursSecondShift = 5;
                nrWorkingHoursThirdShift = 5;

                foreach (EmployeeBase employee in employeesWithPreferencesForAssigning)
                {
                    if (dataAccess.GetShiftPreferences(date.ToString("dd/MM/yyyy"), employee.EmployeeID) == firstShiftPeriod)
                    {
                        firstShift.Add(employee);
                    }
                    else if (dataAccess.GetShiftPreferences(date.ToString("dd/MM/yyyy"), employee.EmployeeID) == secondShiftPeriod)
                    {
                        secondShift.Add(employee);
                    }
                    else if (dataAccess.GetShiftPreferences(date.ToString("dd/MM/yyyy"), employee.EmployeeID) == thirdShiftPeriod)
                    {
                        thirdShift.Add(employee);
                    }
                }
            }
        }



        //separate the employees in lists for shifts depending on their position (for first shift)

        List<EmployeeBase> nrAdmins = new List<EmployeeBase>();
        List<EmployeeBase> nrManagers = new List<EmployeeBase>();
        List<EmployeeBase> nrDepotWorkers = new List<EmployeeBase>();
        List<EmployeeBase> nrEmployees = new List<EmployeeBase>();

        private void SeparateEmployeesByPosition(List<EmployeeBase> employeesForShift)
        {         
            foreach (EmployeeBase employee in employeesForShift)
            {
                if (dataAccess.GetPositionByID(employee.EmployeeID) == "ADMINISTRATOR")
                {
                    nrAdmins.Add(employee);
                }
                else if (dataAccess.GetPositionByID(employee.EmployeeID) == "MANAGER")
                {
                    nrManagers.Add(employee);
                }
                else if (dataAccess.GetPositionByID(employee.EmployeeID) == "DEPOT")
                {
                    nrDepotWorkers.Add(employee);
                }
                else if (dataAccess.GetPositionByID(employee.EmployeeID) == "EMPLOYEE")
                {
                    nrEmployees.Add(employee);
                }
            }
        }

        private void GenerateScheduleForShiftByPosition(DateTime date, List<EmployeeBase> employeesForShift, List<EmployeeBase> Employees, string possition, int nrNeededEmployees, int nrWorkingHours, string department)
        {
            SeparateEmployeesByPosition(employeesForShift);

            //checks the number of employees with preferences and the number of needed employees for the shift
            string shift = "";
            if (Employees.Count == nrNeededEmployees)
            {
                foreach (EmployeeBase employee in Employees)
                {

                    dataAccess.AssignEmployeeWithPreferencesToShift(employee.EmployeeID, date.ToString("dd/MM/yyyy"));
                    dataAccess.AddWorkingHoursToEmployee(employee.EmployeeID, nrWorkingHours);
                }
            }
            else if (Employees.Count > nrNeededEmployees)
            {
                for (int i = 0; i <= nrNeededEmployees; i++)
                {
                    Random random = new Random();
                    int index = random.Next(Employees.Count);
                    dataAccess.AssignEmployeeWithPreferencesToShift(Employees[index].EmployeeID, date.ToString("dd/MM/yyyy"));
                    dataAccess.AddWorkingHoursToEmployee(Employees[index].EmployeeID, nrWorkingHours);
                    Employees.RemoveAt(index);
                }
            }
            else if (Employees.Count < nrNeededEmployees)
            {
                List<string> shifts = new List<string>();
                shifts.Add(firstShiftPeriod);
                shifts.Add(secondShiftPeriod);
                shifts.Add(thirdShiftPeriod);
                foreach (EmployeeBase employee in Employees)
                {
                    dataAccess.AssignEmployeeWithPreferencesToShift(employee.EmployeeID, date.ToString("dd/MM/yyyy"));
                    dataAccess.AddWorkingHoursToEmployee(employee.EmployeeID, nrWorkingHours);
                }

                List<EmployeeBase> allEmployees = dataAccess.GetEmployeesByPossitionsOrderedByWorkedHours(possition, department);
                for (int j = 0; j < shifts.Count; j++)
                {
                    for (int i = 0; i < nrNeededEmployees - Employees.Count; i++)
                    {
                        Random random = new Random();
                        int index = random.Next(allEmployees.Count);

                        dataAccess.AssignEmployeeToShift(allEmployees[index].EmployeeID, date.ToString("dd/MM/yyyy"), shifts[j]);
                        dataAccess.AddWorkingHoursToEmployee(allEmployees[index].EmployeeID, nrWorkingHours);
                    }
                }
                    
            }
        }

        public void GenerateScheduleForDay(DateTime date,string department, int nrAdminsPerShift, int nrManagersPerShift, int nrDepotWorkersPerShift, int nrEmployeesPerShift)
        {
            CheckEmployeesWhichCanWork(date, department);
            SeparateThePreferredShiftPerDay(date);

            //generate fisrt shifts
            GenerateScheduleForShiftByPosition(date, firstShift, nrAdmins, "ADMINISTRATOR", nrAdminsPerShift,nrWorkingHoursFirstShift, department);
            GenerateScheduleForShiftByPosition(date, firstShift, nrManagers, "MANAGER", nrManagersPerShift, nrWorkingHoursFirstShift, department);
            GenerateScheduleForShiftByPosition(date, firstShift, nrDepotWorkers, "DEPOT", nrDepotWorkersPerShift, nrWorkingHoursFirstShift, department);
            GenerateScheduleForShiftByPosition(date, firstShift, nrEmployees, "EMPLOYEE", nrEmployeesPerShift, nrWorkingHoursFirstShift, department);

            //generate second shifts
            GenerateScheduleForShiftByPosition(date, secondShift, nrAdmins, "ADMINISTRATOR", nrAdminsPerShift,nrWorkingHoursSecondShift, department);
            GenerateScheduleForShiftByPosition(date, secondShift, nrManagers, "MANAGER", nrManagersPerShift, nrWorkingHoursSecondShift, department);
            GenerateScheduleForShiftByPosition(date, secondShift, nrDepotWorkers, "DEPOT", nrDepotWorkersPerShift, nrWorkingHoursSecondShift, department);
            GenerateScheduleForShiftByPosition(date, secondShift, nrEmployees, "EMPLOYEE", nrEmployeesPerShift, nrWorkingHoursSecondShift, department);

            //generate third shifts
            GenerateScheduleForShiftByPosition(date, thirdShift, nrAdmins, "ADMINISTRATOR", nrAdminsPerShift,nrWorkingHoursThirdShift, department);
            GenerateScheduleForShiftByPosition(date, thirdShift, nrManagers, "MANAGER", nrManagersPerShift, nrWorkingHoursThirdShift, department);
            GenerateScheduleForShiftByPosition(date, thirdShift, nrDepotWorkers, "DEPOT", nrDepotWorkersPerShift, nrWorkingHoursThirdShift, department);
            GenerateScheduleForShiftByPosition(date, thirdShift, nrEmployees, "EMPLOYEE", nrEmployeesPerShift, nrWorkingHoursThirdShift, department);
        }

        public void GenerateScheduleForWeek(string department,int nrAdminsPerShift, int nrManagersPerShift, int nrDepotWorkersPerShift, int nrEmployeesPerShift)
        {
            DateTime today = DateTime.Today;
            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                //GenerateScheduleForDay(today.Date, department, nrAdminsPerShift, nrManagersPerShift, nrDepotWorkersPerShift, nrEmployeesPerShift);
                for (int i = 0; i < 7; i++)
                {
                    GenerateScheduleForDay(today.AddDays(i).Date, department, nrAdminsPerShift, nrManagersPerShift, nrDepotWorkersPerShift, nrEmployeesPerShift);
                }
            }
            else
            {
                DateTime tomorrow = DateTime.Today.AddDays(1);
                // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
                int daysUntilMonday = ((int)DayOfWeek.Monday - (int)tomorrow.DayOfWeek + 7) % 7;
                DateTime nextMonday = tomorrow.AddDays(daysUntilMonday);

                for (int i = 0; i < 7; i++)
                {
                    GenerateScheduleForDay(nextMonday.AddDays(i).Date, department, nrAdminsPerShift, nrManagersPerShift, nrDepotWorkersPerShift, nrEmployeesPerShift);
                }
            }
        }
    }
}
