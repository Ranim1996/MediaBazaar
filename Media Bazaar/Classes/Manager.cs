using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public class Manager : Employee
    {
        //Instance variables


        //Constructor
        public Manager(string fName, string sName, string birth, string email, int phoneNr, string nationality, JobPosition pos) 
            : base(fName, sName, birth, email, phoneNr, nationality, pos)
        {

        }

        //Properties
        public override JobPosition GetJobPosition => base.GetJobPosition;
        public override int GetID => base.GetID;

        //Methods
        public override string GetInfo()
        {
            return "MANAGER " + base.GetInfo();
        }
    }
}
