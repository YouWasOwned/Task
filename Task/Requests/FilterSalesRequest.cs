namespace Task.Requests
{
    public class FilterSalesRequest
    {
        public int DistributorID { get; set; }
        public DateTime SaleDate { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
