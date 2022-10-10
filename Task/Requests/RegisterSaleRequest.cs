namespace Task.Requests
{
    public class RegisterSaleRequest
    {
        public int DistributorID { get; set; }
        public DateTime SaleDate { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}