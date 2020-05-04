using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Media_Bazaar.Classes;
using MySql.Data.MySqlClient;

namespace Media_Bazaar
{
    public class DataAccess
    {
        //METHODS FOR EMPLOYEES:      
       
        public List<IEmployeeModel> GetNotFiredEmployeesByLastName(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT * FROM Employee WHERE LastName='{lastName}' AND ReasonsForRelease IS NULL").ToList();
                return output;
            }
        }
        public List<IEmployeeModel> GetNotFiredEmployeesByID(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT * FROM Employee WHERE EmployeeID='{id}' AND ReasonsForRelease IS NULL").ToList();
                return output;
            }
        }

        //get all the info of the employee via employee id.
        public List<IEmployeeModel> GetDBNotFiredEmployeeByID(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT * FROM Employee WHERE EmployeeID='{id}' AND ReasonsForRelease IS NULL").ToList();
                return output;
            }
        }
        //get all info of the employee via last name.
        public List<IEmployeeModel> GetDBEmployeesByLastName(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT * FROM Employee WHERE LastName='{lastName}'").ToList();
                return output;
            }
        }
       
        public void InsertEmployee(string fName, string lName, string dateOfBirth, string email, string phoneNr, string nationality, string pos, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"INSERT INTO Employee(FirstName, LastName, DateOfBirth, Email, PhoneNumber, Nationality, Position, Username, Password) VALUES ('{ fName }', '{lName}' , '{dateOfBirth}' , '{email}' , '{phoneNr}' , '{nationality}' , '{pos}' , '{username}' , '{password}');");
            }
        }

        //get the employee id via name.
        public int GetIdOfEmployeeByName(string fName, string lName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT EmployeeID FROM Employee WHERE FirstName ='{fName}' AND LastName ='{lName}';");
            }
        }
       

        //get first name of employee via employee id.
        public string GetFirstNameOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT FirstName FROM Employee WHERE EmployeeID = '{id}';");
            }
        }
        
        //Get All employees
        public List<IEmployeeModel> GetAllEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT * FROM Employee").ToList();
                return output;
            }
        }


        //update and set the info's table in data base where the employee is fired by id.
        public void FireEmployeeByID(string reasons, int employeeID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Employee SET ReasonsForRelease ='{reasons}' WHERE EmployeeID ='{employeeID}'; ");
            }
        }

        //not used till now
        //public List<DBEmployee> GetFiredEmployees()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE ReasonsForRelease IS NOT NULL;").ToList();
        //        return output;
        //    }
        //}

        //get all the info of not fired employees
        public List<IEmployeeModel> GetNotFiredEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT * FROM Employee WHERE ReasonsForRelease IS NULL;").ToList();
                return output;
            }
        }

        public string GetDepotID()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT EmployeeID FROM Employee WHERE Position ='Depot' ;");
            }
        }

        //METHODS FOR DEPARTAMENTS

        //add new department in the deartment table in data base.
        public void InsertDepartament(string departamentName, int minNumOfEmployees, int maxNumOfEmployees)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"INSERT INTO Departament(DepartamentName, MinNumOfEmployees, MaxNumOfEmployees) VALUES ('{ departamentName }', '{minNumOfEmployees}' , '{maxNumOfEmployees}');");

            }
        }

        //get all the departments that are in the data base.
        public List<IDepartmentModel> GetAllDepartaments()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IDepartmentModel>($"SELECT * FROM Departament").ToList();
                return output;
            }
        }

        //update employee table when information are added to the department column.
        public void AssignEmployeeToDepartament(int employeeID, string departament)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Employee SET Departament ='{departament}' WHERE EmployeeID ='{employeeID}'; ");
            }

        }

        // Add data according to stock ID


        //Get all restocks


        //get stock id by the given stock id.
        public string GetDBStockIDById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT RequestID FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get stock name by the given stock id.
        public string GetDBStockNameById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT NameOfStock FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get stock type by the given stock id.
        public string GetDBStockTypeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT TypeOfStock FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get department by the given stock id.
        public string GetDBDepartmentByStockId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Departament FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get stock quantity id by the given stock id.
        public string GetDBStockQuantityById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Quantity FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get stock order date id by the given stock id.
        public string GetDBStockOrderDateById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfOrder FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get stock deliver date id by the given stock id.
        public string GetDBStockDeliverDateById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfDelivery FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get stock status by the given stock id.
        public string GetDBStockStatusById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT AdminConfirmation FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //get employee id by the given stock id.
        public string GetDBEmployeeIdByStockId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT EmployeeID FROM RestockRequest WHERE RequestID ='{id}';");
            }
        }

        //METHODS FOR RESTOCK

        // get info about all requested stock.
        public List<IRestockRequest> GetAllRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IRestockRequest>($"SELECT * FROM RestockRequest").ToList();
                return output;
            }
        }

        //not used till now
        //public List<DBRestockRequest> GetAllIncomingStockRequests(DateTime dt)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest WHERE DateOfDelivery>='{dt}' AND AdminConfirmation ='CONFIRMED'").ToList();
        //        return output;
        //    }
        //}

        // add request to Restock request table in data base.
        public void InsertRequest(int idE, string name, string type, string department, int quantity, string orderDate, string orderDeliver)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"INSERT INTO RestockRequest(EmployeeID, NameOfStock, TypeOfStock, Departament, Quantity, DateOfOrder, DateOfDelivery) VALUES ('{idE}' , '{name}' , '{type}', '{department}', '{quantity}','{orderDate}', '{orderDeliver}');");
            }
        }

        //add request to restock request table in data base. ((Will be used in the next block))
        //public void InsertRequestForAnExistingstock(int idS,int idE,string name, string type, string department,int quantity, string orderDate, string orderDeliver)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        connection.Execute($"INSERT INTO RestockRequest(RequestID, EmployeeID, NameOfStock,TypeOfStock, Departament, Quantity, DateOfOrder, DateOfDelivery) VALUES ('{idS}' , '{idE}' , '{name}', '{type}', '{department}' ,'{quantity}','{orderDate}', '{orderDeliver}');");
        //    }
        //}

        // get all confirmed requests from data base.
        public List<IRestockRequest> GetAllConfirmedRestock()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IRestockRequest>($"SELECT * FROM RestockRequest WHERE AdminConfirmation ='CONFIRMED'").ToList();
                return output;
            }
        }

        // Get all rejected requests.
        public List<IRestockRequest> GetAllRejectedRestock()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IRestockRequest>($"SELECT * FROM RestockRequest WHERE AdminConfirmation='REJECTED'").ToList();
                return output;
            }
        }

        //update restock request when the AdminConfirmation column is modified "CONFIRMED".
        public void ConfirmRequest(int requestID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE RestockRequest SET AdminConfirmation='CONFIRMED' WHERE RequestID='{requestID}'; ");
            }
        }

        //update restock request when the AdminConfirmation column is modified "REJECTED".
        public void RejectRequest(int requestID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE RestockRequest SET AdminConfirmation='REJECTED' WHERE RequestID ='{requestID}'; ");
            }
        }

        //get all available stocks where the quantity is not null
        public List <IRestockRequest> GetAllAvailableStocks ()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IRestockRequest>($"SELECT * FROM RestockRequest WHERE Quantity IS NOT NULL").ToList();
                return output;
            }
        }


        //METHODS FOR SCHEDULE--------------

        //get all the schedule from the data base.
        public List<ISchedule> GetAllSchedules()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<ISchedule>($"SELECT * FROM Schedule").ToList();
                return output;
            }
        }
        public List<ISchedule> GetSchedulesByEmplId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<ISchedule>($"SELECT * FROM schedule WHERE EmployeeID='{id}'").ToList();
                return output;
            }
        }
        //Adding the shift to the database
        public void AddSchedule(int employeeID, string date, string shift)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {

                int id = connection.ExecuteScalar<int>($"SELECT e.EmployeeID FROM Employee AS e WHERE e.EmployeeID='{employeeID}'");
                connection.Execute($"INSERT INTO schedule (EmployeeID, Date, Shift)  VALUES( '{id}', '{date}', '{shift}')");
            }
        }

        //get employee attendance by employee id, shift and date.
        public void AddAttendanceForEmployeeByIdAndShift(int id, string attendance, string shift, string date)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE schedule SET Attendance='{attendance}' WHERE EmployeeID='{id}' AND Shift='{shift}' AND Date='{date}';");
            }
        }

        public void DeleteAttendanceByIdAndShift(int emplId, string shift, string date, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"DELETE FROM schedule WHERE EmployeeID='{emplId}' AND Shift='{shift}' AND Date ='{date}' AND Status='{status}';");
            }
        }
        public void AssignShift(int id, string shift, string date)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE schedule SET Status='Assigned' WHERE EmployeeID='{id}' AND Shift='{shift}' AND Date='{date}';");
            }
        }





        // methods to return int in order to use it in the statistics

        //return number of present employees.
        public int GetNumOfPresentById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='PRESENT' AND EmployeeID='{id}';");
            }
        }
        //return number of absent employees.
        public int GetNumOfAbsentById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='ABSENT' AND EmployeeID ='{id}';");
            }
        }

        //return number of late employees.
        public int GetNumOfLateById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='LATE' AND EmployeeID='{id}';");
            }
        }


        //EMPLOYEE EMAILS
        public List<IEmails> GetEmails()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmails>($"SELECT * FROM email").ToList();
                return output;
            }
        }

        public void EmailStatusRead(int emailId)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE email SET Status='Read' WHERE EmailID='{emailId}'; ");
            }
        }

        public void DeleteEmailById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"DELETE FROM email WHERE EmailID = '{id}';");
            }
        }

        //LOGIN METHODS

        public List<IEmployeeModel> LoginAdministrator(string username,string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT Username, Password FROM Employee WHERE Username = '{username}' AND Password = '{password}' AND Position='ADMINISTRATOR';").ToList();
                return output;
            }
        }

        public List<IEmployeeModel> LoginManager(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT Username, Password FROM Employee WHERE Username = '{username}' AND Password = '{password}' AND Position='MANAGER';").ToList();
                return output;
            }
        }

        public List<IEmployeeModel> LoginDepotWorker(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<IEmployeeModel>($"SELECT Username, Password FROM Employee WHERE Username = '{username}' AND Password = '{password}' AND Position='DEPOT';").ToList();
                return output;
            }
        }

    }
}
