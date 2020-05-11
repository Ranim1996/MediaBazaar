namespace Media_Bazaar
{
    public class EmployeeBase
    {
        AutoGeneratePassword generatePassword { get; set; }

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string Departament { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PreferedShiftForTheWeek { get; set; }
        public string ReasonsForRelease { get; set; }
        public string Position { get; } 

        public virtual string FullInfo { get { return $"ID:{EmployeeID} {FirstName} {LastName} {DateOfBirth} {Email} {PhoneNumber} {Nationality} {Position} {Departament} {PreferedShiftForTheWeek})"; } }

        
    }
}
