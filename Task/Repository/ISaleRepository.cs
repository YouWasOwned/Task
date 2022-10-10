using Task.Models;
using Task.Requests;

namespace Task.Repository
{
    public interface ISaleRepository
    {
        public void RegisterSale(RegisterSaleRequest request);

        public List<Sale> GetFilteredSales(FilterSalesRequest request);
    }
}