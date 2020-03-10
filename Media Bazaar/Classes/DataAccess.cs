﻿using System;
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

        public List<DBEmployee> GetDBEmployeeByID (int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE EmployeeID='{id}'").ToList();
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

        public string GetFirstNameOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT FirstName FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        public string GetLastNameOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT LastName FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        public string GetLastNameOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT LastName FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        public string GetPosOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Position FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        public string GetPosOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Position FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        public string GetEmailOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Email FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        public string GetEmailOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Email FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        public string GetPhoneNumberOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT PhoneNumber FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        public string GetPhoneNumberOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT PhoneNumber FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        public string GetNationalityOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Nationality FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        public string GetNationalityOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Nationality FROM Employee WHERE LastName = '{lastName}';");
            }
        }

        public string GetDateOfBirthOfEmployeeById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfBirth FROM Employee WHERE EmployeeID = '{id}';");
            }
        }

        public string GetDateOfBirthOfEmployeeByLastname(string lastName)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT DateOfBirth FROM Employee WHERE LastName = '{lastName}';");
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
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE ReasonsForRelease IS NOT NULL;").ToList();
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

        public void InsertRequest(int idE, string name, string type, string department, int quantity, string orderDate, string orderDeliver)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"INSERT INTO RestockRequest(EmployeeID, NameOfStock, TypeOfStock, Departament, Quantity, DateOfOrder, DateOfDelivery) VALUES ('{idE}' , '{name}' , '{type}', '{department}', '{quantity}','{orderDate}', '{orderDeliver}');");
            }
        }

        public List<DBRestockRequest> GetAllConfirmedRestock()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest WHERE AdminConfirmation ='CONFIRMED'").ToList();
                return output;
            }
        }

        public List<DBRestockRequest> GetAllRejectedRestock()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBRestockRequest>($"SELECT * FROM RestockRequest WHERE AdminConfirmation ='CONFIRMED'").ToList();
                return output;
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


        public string GetShiftDetailsById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Shift FROM Schedule WHERE EmployeeID = '{id}';");
            }
        }
        public string GetShiftDateById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<string>($"SELECT Date FROM Schedule WHERE EmployeeID = '{id}';");
            }
        }

        public void AddAttendanceForEmployeeByIdAndShift(int id, string attendance, string shift, string date)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                connection.Execute($"UPDATE Schedule SET Attendance = '{attendance}' WHERE EmployeeID = '{id}' AND Shift = '{shift}' AND Date = '{date}';");
            }
        }
        

        public int GetNumOfFired()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(EmployeeID) FROM Employee WHERE ReasonsForRelease IS NOT NULL;");
            }            
        }

        public int GetNumOfnOTFired()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(EmployeeID) FROM Employee WHERE ReasonsForRelease IS NULL;");
            }
        }

        public int GetNumOfPresent()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='PRESENT';");
            }
        }

        public int GetNumOfAbsent()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='ABSENT';");
            }
        }

        public int GetNumOfLate()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM Schedule WHERE Attendance='LATE';");
            }
        }


        public int GetNumOfConfirmedRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM RestockRequest WHERE AdminConfirmation='CONFIRMED';");
            }
        }

        public int GetNumOfRejectedRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM RestockRequest WHERE AdminConfirmation='REJECTED';");
            }
        }

        public int GetNumOfWaitingRequests()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                return connection.ExecuteScalar<int>($"SELECT COUNT(*) FROM RestockRequest WHERE AdminConfirmation IS NULL;");
            }
        }


        //public List<DBShifts> GetAllShifts()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBShifts>($"SELECT * FROM Shifts").ToList();
        //        return output;
        //    }
        //}

        //public List<DBShifts> GetAllMorningShifts()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBShifts>($"SELECT * FROM Shifts WHERE ShiftType = 'Morning'").ToList();
        //        return output;
        //    }
        //}

        //public List<DBShifts> GetAllAfterNoonShifts()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBShifts>($"SELECT * FROM Shifts WHERE ShiftType = 'Afternoon' ").ToList();
        //        return output;
        //    }
        //}

        //public List<DBShifts> GetAllEveningShifts()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
        //    {
        //        var output = connection.Query<DBShifts>($"SELECT * FROM Shifts WHERE ShiftType = 'Evening'").ToList();
        //        return output;
        //    }
        //}
        //---------------------------
    }
}
