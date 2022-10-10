using Task.Models;
using Task.Repository;
using Task.Requests;
using Task.Responses;

namespace Task.Services
{
    public class SalesServiceImpl : SalesService
    {
        private readonly ISaleRepository saleRepository;

        public SalesServiceImpl(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public FilterSalesResponse FilterSales(FilterSalesRequest request)
        {
            var result = saleRepository.GetFilteredSales(request);
            var message = result.Count != 0 ? "SUCCESS" : "Sales Not Found";
            return new FilterSalesResponse()
            {
                FilteredSales = result,
                StatusCode = 200,
                Message = message
            };
        }

        public Response RegisterSale(RegisterSaleRequest request)
        {
            saleRepository.RegisterSale(request);
            return new Response()
            {
                StatusCode = 200,
                Message = "Sale Registered Successfully"
            };
        }

    }
}
