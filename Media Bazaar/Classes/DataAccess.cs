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
                List<DBEmployee> employees = new List<DBEmployee>();
                // employees.Add(new DBEmployee { FirstName = fName, LastName = lName, DateOfBirth = dateOfBirth, Email = email, PhoneNumber = phoneNr, Nationality = nationality, Position = pos, Username = username, Password = password });
                connection.Execute(@"INSERT INTO Employee(FirstName,LastName,DateOfBirth,Email,PhoneNumber,Nationality,Position,Username,Password) VALUES (@fName,@lName,@dateOfBirth,@email,@phoneNr,@nationality,@pos,@username,@password)",
                 new { FirstName = fName, LastName = lName, DateOfBirth = dateOfBirth, Email = email, PhoneNumber = phoneNr, Nationality = nationality, Position = pos, Username = username, Password = password });
            }
        }
    }
}
