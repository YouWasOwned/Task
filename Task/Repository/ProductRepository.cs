using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Task.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IDbConnection dbConnection;

        public ProductRepository(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void RegisterProduct(string code, string name, decimal unitPrice)
        {
            var p = new DynamicParameters();
            p.Add("code", code);
            p.Add("name", name);
            p.Add("unitPrice", unitPrice);
            dbConnection.Execute("sp_registerProduct", p, commandType: CommandType.StoredProcedure);
        }
    }
}
