namespace Media_Bazaar
{
    public interface IRestockRequest
    {
        string AdminConfirmation { get; set; }
        string DateOfDelivery { get; set; }
        string DateOfOrder { get; set; }
        string Departament { get; set; }
        int EmployeeID { get; set; }
        string ExtraInfo { get; set; }
        string FullInfo { get; }
        string NameOfStock { get; set; }
        int Quantity { get; set; }
        int RequestID { get; set; }
        string TypeOfStock { get; set; }

        string GetInfo();
    }
}