﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class DepotWorkerModel:IEmployeeModel
    {
        public AutoGeneratePassword generatePassword { get; set; } = new AutoGeneratePassword();
        private string username;
        private string password;

        private string possition = "DEPOT WORKER";

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string Departament { get; set; }

        public string Username { get { return username; } set { username = $"{FirstName.ToLower()}.{LastName}@mediabazaar"; } }
        public string Password { get { return password; } set { password = generatePassword.autoGeneratePassword(); } }

        public string PreferedShiftForTheWeek { get; set; }
        public string ReasonsForRelease { get; set; }

        public string FullInfo
        {
            get
            {
                return $"ID:{EmployeeID} {FirstName} {LastName} {DateOfBirth} {Email} {PhoneNumber} {Nationality} {Position} {Departament} {PreferedShiftForTheWeek})";
            }
        }

        public string Position { get { return possition; } }

        public IAccounts AccountProcessor { get; set; } = new ManagerAccount();
    }
}
