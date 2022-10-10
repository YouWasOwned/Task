using Task.Models;

namespace Task.Responses
{
    public class FilterSalesResponse : Response
    {
        public List<Sale> FilteredSales { get; set; }
    }
}
