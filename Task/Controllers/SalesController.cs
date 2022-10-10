using Microsoft.AspNetCore.Mvc;
using Task.Requests;
using Task.Responses;
using Task.Services;

namespace Task.Controllers
{
    [ApiController]
    public class SalesController
    {

        private readonly SalesService salesService;

        public SalesController(SalesService salesService)
        {
            this.salesService = salesService;
        }

        [HttpPost("register-sale")]
        public Response RegisterSale(RegisterSaleRequest request)
        {
            return salesService.RegisterSale(request);  
        }

        [HttpPost("filter-sales")]
        public FilterSalesResponse FilterSales(FilterSalesRequest request)
        {
            return salesService.FilterSales(request);
        }
    }
}
