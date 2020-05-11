namespace Media_Bazaar
{
    public class RestockRequestBase
    {
        public string AdminConfirmation { get; set; }
        public string DateOfDelivery { get; set; }
        public string DateOfOrder { get; set; }
        public string Departament { get; set; }
        public int EmployeeID { get; set; }
        public string ExtraInfo { get; set; }
        //public string FullInfo { get; }
        public string NameOfStock { get; set; }
        public int Quantity { get; set; }
        public int RequestID { get; set; }
        public string TypeOfStock { get; set; }

        public virtual string FullInfo
        {
            get { return $"Stock ID:{RequestID} {EmployeeID} {NameOfStock} {TypeOfStock} {Departament} {Quantity} {DateOfOrder} {DateOfDelivery} {AdminConfirmation} {ExtraInfo})"; }
        }
    }
}