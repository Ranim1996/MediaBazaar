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
        public List<DBEmployee> GetDBEmployeesByLastName(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE LastName='{lastName}'").ToList();
                return output;
            }
        }
        public List<DBEmployee> GetEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE EmployeeId='{id}'").ToList();
                return output;
            }
        }

        public void InsertEmployee(string fName, string lName, string dateOfBirth, string email, string phoneNr, string nationality, string pos, string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                //List<DBEmployee> employees = new List<DBEmployee>();
                connection.Execute($"INSERT INTO Employee(FirstName, LastName, DateOfBirth, Email, PhoneNumber, Nationality, Position, Username, Password) VALUES ('{ fName }', '{lName}' , '{dateOfBirth}' , '{email}' , '{phoneNr}' , '{nationality}' , '{pos}' , '{username}' , '{password}');");

            }
        }

        public int GetIdOfEmployeeByName(string fName, string lName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT EmployeeID FROM Employee WHERE FirstName = '{fName}' AND LastName = '{lName}';");
            }
        }
        public string GetFirstNameOfEmployeeById(int id)
        {
            using(MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT FirstName FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        public List<DBEmployee> GetAllEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee").ToList();
                return output;
            }
        }



        public void FireEmployeeByID(string reasons, int employeeID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Employee SET ReasonsForRelease ='{reasons}' WHERE EmployeeID = '{employeeID}'; ");
            }
        }

        public List<DBEmployee> GetFiredEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE ReasonsForRelease IS NOT 'NULL;").ToList();
                return output;
            }
        }

        public List<DBEmployee> GetNotFiredEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE ReasonsForRelease IS NULL;").ToList();
                return output;
            }
        }




        //METHODS FOR DEPARTAMENTS

        public void InsertDepartament(string departamentName, int minNumOfEmployees, int maxNumOfEmployees)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"INSERT INTO Departament(DepartamentName, MinNumOfEmployees, MaxNumOfEmployees) VALUES ('{ departamentName }', '{minNumOfEmployees}' , '{maxNumOfEmployees}');");

            }
        }

        public List<DBDepartament> GetAllDepartaments()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBDepartament>($"SELECT * FROM Departament").ToList();
                return output;
            }
        }


        public void AssignEmployeeToDepartament(int employeeID, string departament)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Employee SET Departament ='{departament}' WHERE EmployeeID = '{employeeID}'; ");
            }

        }

        //METHODS FOR RESTOCK

        public List<DBRestockRequest> GetAllRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest").ToList();
                return output;
            }
        }

        public List<DBRestockRequest> GetAllIncomingStockRequests(DateTime dt)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest WHERE DateOfDelivery>='{dt}' AND AdminConfirmation ='CONFIRMED'").ToList();
                return output;
            }
        }

        public void InsertRequest(int idS, int idE, string name, string type, string department, int quantity, string orderDate, string orderDeliver)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"INSERT INTO RestockRequest( RequestID, EmployeeID, NameOfStock, TypeOfStock, Departament, Quantity, DateOfOrder, DateOfDelivery) VALUES ('{ idS }', '{idE}' , '{name}' , '{type}', '{department}', '{quantity}','{orderDate}', '{orderDeliver}');");
            }
        }



        public void ConfirmRequest(int requestID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE RestockRequest SET AdminConfirmation ='CONFIRMED' WHERE RequestID = '{requestID}'; ");
            }
        }

        public void RejectRequest(int requestID)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE RestockRequest SET AdminConfirmation ='REJECTED' WHERE RequestID = '{requestID}'; ");
            }
        }


        //METHODS FOR SCHEDULE--------------

        
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
            using(MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {

                int id = connection.ExecuteScalar<int>($"SELECT e.EmployeeID FROM Employee AS e WHERE e.EmployeeID = '{employeeID}'");
                connection.Execute($"INSERT INTO Schedule (EmployeeID, Date, Shift)  VALUES( '{id}', '{date}', '{shift}')");
            }
        }
        //---------------------------
    }
}
