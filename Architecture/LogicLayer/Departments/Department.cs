using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class Department : IDepartmentModel
    {
        public string DepartamentName { get; set; }
        public int MinNumOfEmployees { get; set; }
        public int MaxNumOfEmployees { get; set; }

        public string GetInfo()
        {
            return $"{DepartamentName} Min: {MinNumOfEmployees}, Max: {MaxNumOfEmployees})";
        }   
    }
}
