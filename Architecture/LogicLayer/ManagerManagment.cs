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

        DataAccess dataAccess=new DataAccess();

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
    }
}
