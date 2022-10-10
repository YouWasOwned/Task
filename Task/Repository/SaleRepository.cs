using Dapper;
using System.Data;
using System.Data.SqlClient;
using Task.Models;
using Task.Requests;

namespace Task.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private IDbConnection dbConnection;

        public SaleRepository(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Sale> GetFilteredSales(FilterSalesRequest request)
        {
            var p = new DynamicParameters();
            p.Add("distributorId", request.DistributorID);
            p.Add("saleDate", request.SaleDate);
            p.Add("productCode", request.ProductCode);
            p.Add("productName", request.ProductName);
            var result = dbConnection.Query<Sale>("sp_getFilteredSales", p, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }

        public void RegisterSale(RegisterSaleRequest request)
        {
            var p = new DynamicParameters();
            p.Add("distributorId", request.DistributorID);
            p.Add("saleDate", request.SaleDate);
            p.Add("productCode", request.ProductCode);
            p.Add("productName", request.ProductName);
            p.Add("price", request.Price);
            p.Add("unitPrice", request.UnitPrice);
            p.Add("totalPrice", request.TotalPrice);
            dbConnection.Execute("sp_registerSale", p, commandType: CommandType.StoredProcedure);
        }
    }
}