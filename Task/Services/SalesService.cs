using Task.Requests;
using Task.Responses;

namespace Task.Services
{
    public interface SalesService
    {
        public Response RegisterSale(RegisterSaleRequest request);

        public FilterSalesResponse FilterSales(FilterSalesRequest request);
    }
}
