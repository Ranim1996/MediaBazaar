using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public class DBDepartament
    {
        //properties
        public string DepartamentName { get; set; }
        public int MinNumOfEmployees { get; set; }
        public int MaxNumOfEmployees { get; set; }
        
        //methods
        public string FullInfo // return full info.
        {
            get
            {
                return $"{DepartamentName} Min: {MinNumOfEmployees}, Max: {MaxNumOfEmployees})";
            }
        }       

        public string GetName() // return department name.
        {
            return DepartamentName;
        }
    }
}
