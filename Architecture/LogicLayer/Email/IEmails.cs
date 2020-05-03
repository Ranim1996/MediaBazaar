namespace Media_Bazaar
{
    public interface IEmails
    {
        string Date { get; }
        string Email { get; }
        int EmailID { get; }
        int EmployeeID { get; }
        string Status { get; }
    }
}