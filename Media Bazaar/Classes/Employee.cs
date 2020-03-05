using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public abstract class Employee
    {
        //Instance variables
        protected String name;
        protected String surname;
        protected int phoneNr;
        protected String address;
        protected String email;
        protected String nationality;
        protected String dateOfBirth;
        protected static int ID = 1000;
        protected JobPosition position;
        protected int value = 0;


        //Constructors
        public Employee()
        {

        }
        public Employee(string fName, string sName, string birth, string email, int phoneNr, string nationality, JobPosition pos)
        {
            this.name = fName;
            this.surname = sName;
            this.dateOfBirth = birth;
            this.email = email;
            this.phoneNr = phoneNr;
            this.nationality = nationality;
            this.position = pos;
            ID += value + 1;
        }

        //Properties
        public virtual JobPosition GetJobPosition
        {
            get { return this.position; }
        }
        public virtual int GetID
        {
            get { return ID; }
        }

        public virtual string GetFirstName
        {
            get { return name; }
        }


        //Methods
        public virtual String GetInfo()
        {
            return $"{this.name} {this.surname}({ID}): Date of birth- {this.dateOfBirth}; Email- {this.email}; PhoneNr- {this.phoneNr}; Nationality- {this.nationality}.";
        }

       

    }
}
