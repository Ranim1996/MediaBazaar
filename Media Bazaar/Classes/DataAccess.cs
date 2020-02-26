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

        public List<DBEmployee> GetAllEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("DB")))
            {
                var output = connection.Query<DBEmployee>($"SELECT * FROM Employee").ToList();
                return output;
            }
        }



        public void FireEmployeeByID(string reasons,int employeeID)
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

        public void InsertDepartament(string departamentName,int minNumOfEmployees,int maxNumOfEmployees)
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
    }    
}
