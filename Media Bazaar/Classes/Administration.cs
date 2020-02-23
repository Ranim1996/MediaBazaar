using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public class Administration
    {
        private List<Employee> employees = new List<Employee>();
       // private List<Department> departments = new List<Department>();

        //Instance variables
        

        //Constructor
        public Administration()
        {

        }

        //Properties


        //Methods
        public void AddEmployee(Employee e)
        {
            employees.Add(e);
        }
        public void RemoveEmployee(Employee e)
        {
            employees.Remove(e);
        }


    }
}
