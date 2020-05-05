using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class ManagerManagment
    {
        List<IEmployeeModel> employees = new List<IEmployeeModel>();
        List<IRestockRequest> restocks = null;
        List<IEmployeeModel> allEmployees = null;
        List<Schedule> schedules = null;

        DataAccess dataAccess = new DataAccess();

        public List<IEmployeeModel> GetEmployeesByLName(string lastName)
        {
            return dataAccess.GetDBEmployeesByLastName(lastName);
        }

        public List<IEmployeeModel> GetNotFiredEmployeesByLName(string lastName)
        {
            return dataAccess.GetNotFiredEmployeesByLastName(lastName);
        }

        public List<IEmployeeModel> GetNotFiredEmployeesByID(int id)
        {
            return dataAccess.GetNotFiredEmployeesByID(id);
        }

        public List<ISchedule> GetSchedulesByEmplId(int id)
        {
            return dataAccess.GetSchedulesByEmplId(id);
        }

        public List<IEmployeeModel> GetAllEmployees()
        {
            return dataAccess.GetAllEmployees();
        }

        public List<ISchedule> GetAllSchedules()
        {
            return dataAccess.GetAllSchedules();
        }

        public int GetNumberOfAbsentByID(int id)
        {
            return dataAccess.GetNumOfAbsentById(id);
        }

        public int GetNumberOfPresentByID(int id)
        {
            return dataAccess.GetNumOfPresentById(id);
        }

        public int GetNumberOfLateByID(int id)
        {
            return dataAccess.GetNumOfLateById(id);
        }

        public List<IRestockRequest> GetAllRestockRequests()
        {
            return dataAccess.GetAllRequests();
        }



        //FOR CHARTS
        public int NumberrOfWorking()
        {
            int nrWorking = 0;

            foreach (IEmployeeModel employee in GetAllEmployees())
            {
                if (employee.ReasonsForRelease == null)
                {
                    nrWorking++;
                }
            }
            return nrWorking;
        }

        public int NumberOfFired()
        {
            int nrFired = 0;

            foreach (IEmployeeModel employee in GetAllEmployees())
            {
                if (employee.ReasonsForRelease != null)
                {
                    nrFired++;
                }
            }
            return nrFired;
        }

        public int NumberOfAdministrators()
        {
            int nrAdmins = 0;

            foreach (IEmployeeModel employee in GetAllEmployees())
            {
                if (employee.Position == "ADMINISTRATOR")
                {
                    nrAdmins++;
                }
            }
            return nrAdmins;
        }

        public int NumberOfManagers()
        {
            int nrManagers = 0;

            foreach (IEmployeeModel employee in GetAllEmployees())
            {
                if (employee.Position == "MANAGER")
                {
                    nrManagers++;
                }
            }
            return nrManagers;
        }

        public int NumberOfDepotWorkers()
        {
            int nrDepotWorkers = 0;

            foreach (IEmployeeModel employee in GetAllEmployees())
            {
                if (employee.Position == "DEPOT")
                {
                    nrDepotWorkers++;
                }
            }
            return nrDepotWorkers;
        }

        public int NumberOfPresent()
        {
            int nrOfPresent = 0;

            foreach (Schedule sch in GetAllSchedules())
            {
                if (sch.Attendance == "PRESENT")
                {
                    nrOfPresent++;
                }
            }
            return nrOfPresent;
        }

        public int NumberOfLate()
        {
            int nrOfLate = 0;
            foreach (Schedule sch in GetAllSchedules())
            {
                if (sch.Attendance == "LATE")
                {
                    nrOfLate++;
                }
            }
            return nrOfLate;
        }

        public int NumberOfAbsent()
        {
            int nrOfAbsent = 0;

            foreach (Schedule sch in GetAllSchedules())
            {
                if (sch.Attendance == "ABSENT")
                {
                    nrOfAbsent++;
                }
            }
            return nrOfAbsent;
        }

        public int NumberOfConfirmedRequests()
        {
            int nrOfConfirmed = 0;

            foreach (IRestockRequest req in GetAllRestockRequests())
            {
                if (req.AdminConfirmation == "CONFIRMED")
                {
                    nrOfConfirmed++;
                }
            }
            return nrOfConfirmed;
        }

        public int NumberOfRejectedRequests()
        {
            int nrOfRejected = 0;

            foreach (IRestockRequest req in GetAllRestockRequests())
            {
                if (req.AdminConfirmation == "REJECTED")
                {
                    nrOfRejected++;
                }
            }
            return nrOfRejected;
        }

        public int NumberOfWaitingRequests()
        {
            int nrOfWaiting = 0;

            foreach (IRestockRequest req in GetAllRestockRequests())
            {
                if (req.AdminConfirmation ==null)
                {
                    nrOfWaiting++;
                }
            }
            return nrOfWaiting;
        }


    }
}
