using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public interface IDepartmentModel
    {
        string DepartamentName { get; set; }
        int MinNumOfEmployees { get; set; }
        int MaxNumOfEmployees { get; set; }

        string GetInfo();
    }
}
