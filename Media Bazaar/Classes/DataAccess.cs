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
                var output= connection.Query<DBEmployee>($"SELECT * FROM Employee WHERE LastName='{lastName}'").ToList();
                return output;
            }
        }        
    }
}
