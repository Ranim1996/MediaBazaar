namespace Media_Bazaar
{
    public interface IAccounts
    {
        //EmployeeModel Create(IPersonModel person);
        AutoGeneratePassword generatePassword { get; set; }
    }
}