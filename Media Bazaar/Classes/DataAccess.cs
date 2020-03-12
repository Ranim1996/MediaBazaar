using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace Media_Bazaar.Classes
{
    public class DataAccess
    {

        //METHODS FOR EMPLOYEES:

        //get all info of the employee via last name.
        public List<DBEmployee> GetDBEmployeesByLastName(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE LastName='{lastName}'").ToList();
                return output;
            }
        }

        //get all the info of the employee via employee id.
        public List<DBEmployee> GetDBEmployeeByID(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE EmployeeID='{id}'").ToList();
                return output;
            }
        }

        //insert new employee in the data base table.
        public void InsertEmployee(string fName, string lName, string dateOfBirth, string email, string phoneNr, string nationality, string pos, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                //List<DBEmployee> employees = new List<DBEmployee>();
                connection.Execute($"INSERT INTO Employee(FirstName, LastName, DateOfBirth, Email, PhoneNumber, Nationality, Position, Username, Password) VALUES ('{ fName }', '{lName}' , '{dateOfBirth}' , '{email}' , '{phoneNr}' , '{nationality}' , '{pos}' , '{username}' , '{password}');");

            }
        }

        //get the employee id via name.
        public int GetIdOfEmployeeByName(string fName, string lName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT EmployeeID FROM Employee WHERE FirstName = '{fName}' AND LastName = '{lName}';");
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

        //get first name of employee via employee's last name.
        public string GetFirstNameOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT FirstName FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        //get last name of employee via employee id.
        public string GetLastNameOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT LastName FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        //get last name of employee via employee's last name.
        public string GetLastNameOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT LastName FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        //get position of employee via employee's id.
        public string GetPosOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Position FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        //get position of employee via employee's last name.
        public string GetPosOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Position FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        //get email of employee via employee's id.
        public string GetEmailOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Email FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        //get email of employee via employee's last name.
        public string GetEmailOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Email FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        //get phone number of employee via employee's id.
        public string GetPhoneNumberOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT PhoneNumber FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        //get phone number of employee via employee's last name.
        public string GetPhoneNumberOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT PhoneNumber FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        //get Nationality of employee via employee's id.
        public string GetNationalityOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Nationality FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        //get Nationality of employee via employee's last name.
        public string GetNationalityOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Nationality FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        //get date of birth of employee via employee's id.
        public string GetDateOfBirthOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfBirth FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        //get date of birth of employee via employee's last name.
        public string GetDateOfBirthOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfBirth FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        //not used till now
        //public List<DBEmployee> GetAllEmployees()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBEmployee>($"SELECT * FROM Employee").ToList();
        //        return output;
        //    }
        //}


        //update and set the info's table in data base where the employee is fired by id.
        public void FireEmployeeByID(string reasons, int employeeID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Employee SET ReasonsForRelease ='{reasons}' WHERE EmployeeID = '{employeeID}'; ");
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
        public List<DBEmployee> GetNotFiredEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE ReasonsForRelease IS NULL;").ToList();
                return output;
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
        public List<DBDepartament> GetAllDepartaments()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBDepartament>($"SELECT * FROM Departament").ToList();
                return output;
            }
        }

        //update employee table when information are added to the department column.
        public void AssignEmployeeToDepartament(int employeeID, string departament)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Employee SET Departament ='{departament}' WHERE EmployeeID = '{employeeID}'; ");
            }

        }

        // Add data according to stock ID

        //get stock id by the given stock id.
        public string GetDBStockIDById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT RequestID FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get stock name by the given stock id.
        public string GetDBStockNameById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT NameOfStock FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get stock type by the given stock id.
        public string GetDBStockTypeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT TypeOfStock FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get department by the given stock id.
        public string GetDBDepartmentByStockId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Departament FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get stock quantity id by the given stock id.
        public string GetDBStockQuantityById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Quantity FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get stock order date id by the given stock id.
        public string GetDBStockOrderDateById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfOrder FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get stock deliver date id by the given stock id.
        public string GetDBStockDeliverDateById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfDelivery FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get stock status by the given stock id.
        public string GetDBStockStatusById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT AdminConfirmation FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //get employee id by the given stock id.
        public string GetDBEmployeeIdByStockId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT EmployeeID FROM RestockRequest WHERE RequestID = '{id}';");
            }
        }

        //METHODS FOR RESTOCK

        // get info about all requested stock.
        public List<DBRestockRequest> GetAllRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest").ToList();
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

        // get all confirmed requests from data base.
        public List<DBRestockRequest> GetAllConfirmedRestock()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest WHERE AdminConfirmation ='CONFIRMED'").ToList();
                return output;
            }
        }

        // not used till now.
        //public List<DBRestockRequest> GetAllRejectedRestock()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest WHERE AdminConfirmation ='CONFIRMED'").ToList();
        //        return output;
        //    }
        //}

        //update restock request when the AdminConfirmation column is modified "CONFIRMED".
        public void ConfirmRequest(int requestID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE RestockRequest SET AdminConfirmation ='CONFIRMED' WHERE RequestID = '{requestID}'; ");
            }
        }

        //update restock request when the AdminConfirmation column is modified "REJECTED".
        public void RejectRequest(int requestID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE RestockRequest SET AdminConfirmation ='REJECTED' WHERE RequestID = '{requestID}'; ");
            }
        }


        //METHODS FOR SCHEDULE--------------

        //get all the schedule from the data base.
        public List<DBSchedule> GetAllSchedules()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBSchedule>($"SELECT * FROM Schedule").ToList();
                return output;
            }
        }

        //Adding the shift to the database
        public void AddSchedule(int employeeID, string date, string shift)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {

                int id = connection.ExecuteScalar<int>($"SELECT e.EmployeeID FROM Employee AS e WHERE e.EmployeeID = '{employeeID}'");
                connection.Execute($"INSERT INTO Schedule (EmployeeID, Date, Shift)  VALUES( '{id}', '{date}', '{shift}')");
            }
        }

        // get shift details by employee id.
        public string GetShiftDetailsById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Shift FROM Schedule WHERE EmployeeID = '{id}';");
            }
        }

        //get shift date by employee id.
        public string GetShiftDateById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Date FROM Schedule WHERE EmployeeID = '{id}';");
            }
        }

        //get employee attendance by employee id, shift and date.
        public void AddAttendanceForEmployeeByIdAndShift(int id, string attendance, string shift, string date)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Schedule SET Attendance = '{attendance}' WHERE EmployeeID = '{id}' AND Shift = '{shift}' AND Date = '{date}';");
            }
        }

        // methods to return int in order to use it in the statistics

        //return number of fired employees.
        public int GetNumOfFired()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(EmployeeID) FROM Employee WHERE ReasonsForRelease IS NOT NULL;");
            }
        }

        //return number of not fired employees.
        public int GetNumOfnOTFired()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(EmployeeID) FROM Employee WHERE ReasonsForRelease IS NULL;");
            }
        }

        //return number of present employees.
        public int GetNumOfPresent()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='PRESENT';");
            }
        }

        //return number of absent employees.
        public int GetNumOfAbsent()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='ABSENT';");
            }
        }

        //return number of late employees.
        public int GetNumOfLate()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='LATE';");
            }
        }

        //return number of confirmed requests.
        public int GetNumOfConfirmedRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM RestockRequest WHERE AdminConfirmation='CONFIRMED';");
            }
        }

        //return number of rejected requests.
        public int GetNumOfRejectedRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM RestockRequest WHERE AdminConfirmation='REJECTED';");
            }
        }

        //return number of waiting requests.
        public int GetNumOfWaitingRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM RestockRequest WHERE AdminConfirmation IS NULL;");
            }
        }

        //not used yet
        //public string GetProfileUsername(string pass)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        return connection.ExecuteScalar<string>($"SELECT Usename FROM Employee WHERE Password = '{pass}';");
        //    }
        //}

        //not used yet
        //public string GetProfilePassword(string user)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        return connection.ExecuteScalar<string>($"SELECT Password FROM Employee WHERE Username = '{user}';");
        //    }
        //}

        //not used yet
        //public int GetProfileDetails(string user, string pass)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        return connection.ExecuteScalar<int>($"SELECT Username,Password FROM Employee WHERE Username='{user}' AND CONVERT(Password,VARCHAR)='{pass}' ;");
        //    }
        //}

        // SqlCommand cm = new SqlCommand("SELECT FirstName,Password FROM TenantsInfo WHERE FirstName=  '" + tbName.Text + "' AND CONVERT(VARCHAR, Password)='" + tbPass.Text + " '", sqlcon);
    }
}
