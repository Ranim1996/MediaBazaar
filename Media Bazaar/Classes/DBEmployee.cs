﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public class DBEmployee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Departament { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PreferedShiftForTheWeek { get; set; }
        public string ReasonsForRelease { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{EmployeeID} {FirstName} {LastName} {DateOfBirth} {Email} {PhoneNumber} {Nationality} {Position} {Departament} {PreferedShiftForTheWeek})"; 
            }
        }

    }
}
