namespace Media_Bazaar
{
    public interface IEmployeeModel
    {
        AutoGeneratePassword generatePassword { get; set; }

        int EmployeeID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string DateOfBirth { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Nationality { get; set; }
        string Departament { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string PreferedShiftForTheWeek { get; set; }
        string ReasonsForRelease { get; set; }

        string FullInfo { get; }

        string Position { get; }
    }
}
