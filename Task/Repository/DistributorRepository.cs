using Dapper;
using System.Data;
using System.Data.SqlClient;
using Task.Models;
using Task.Requests;

namespace Task.Repository
{
    public class DistributorRepository : IDistributorRepository
    {
        private IDbConnection dbConnection;

        public DistributorRepository(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public int DeleteDistributorById(int distiburotId)
        {
            var p = new DynamicParameters();
            p.Add("distributorId", distiburotId);
            p.Add("returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            dbConnection.Execute("sp_deleteDistributorById", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("returnvalue");

        }

        public List<Distributor> GetAllDistributors()
        {
            return dbConnection.Query<Distributor>("sp_getAllDistributors", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<DistributorBonus> CountDistributorBonuses(CountDistributorBonusesRequest request)
        {
            var p = new DynamicParameters();
            p.Add("startDate", request.StartDate);
            p.Add("endDate", request.EndDate);
            var result = dbConnection.Query<DistributorBonus>("sp_getDistributorBonuses", p, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }
        public Decimal GetDistributorBonus(int distributorId)
        {
            var p = new DynamicParameters();
            p.Add("distributorId", distributorId);
            p.Add("result", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            dbConnection.Execute("sp_getDistributorBonusAmount", p, commandType: CommandType.StoredProcedure);
            return p.Get<Decimal>("result");
        }

        public RecommenderDistibutor GetRecommenderDistributor(int distiburotId)
        {
            var p = new DynamicParameters();
            p.Add("recommenderId", distiburotId);
            var result = dbConnection.Query<RecommenderDistibutor>("sp_getRecommenderDistributorById", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public void RegisterDistributor(RegisterDistributorRequest request, string imagePath, int newDistributorLevel, int newDistributorRecommendedPeopleCount)
        {
            var p = new DynamicParameters();
            p.Add("name", request.Name);
            p.Add("surname", request.Surname);
            p.Add("birthDate", request.BirthDate);
            p.Add("gender", request.Gender);
            p.Add("imagePath", imagePath);
            p.Add("identificationInformationType", request.IdentificationInformationType);
            p.Add("documentSeries", request.DocumentSeries);
            p.Add("documentNumber", request.DocumentNumber);
            p.Add("releaseDate", request.ReleaseDate);
            p.Add("termDateOfDocument", request.TermDateOfDocument);
            p.Add("personalNumber", request.PersonalNumber);
            p.Add("agency", request.Agency);
            p.Add("contactType", request.ContactType);
            p.Add("contactInformation", request.ContactInformation);
            p.Add("addressType", request.AddressType);
            p.Add("address", request.Address);
            p.Add("recommenderId", request.RecommenderID);
            p.Add("level", newDistributorLevel);
            p.Add("recommendedDistributorsCount", newDistributorRecommendedPeopleCount);
            dbConnection.Execute("sp_registerDistributor", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateDistributorRecommendedDistributorsCount(int distiburotId, int recommendedDistributorsCount)
        {
            var p = new DynamicParameters();
            p.Add("distibutorId", distiburotId);
            p.Add("recommendedDistributorsCount", recommendedDistributorsCount);
            dbConnection.Execute("sp_updateDistributorRecommendedDistributorsCount", p, commandType: CommandType.StoredProcedure);
        }

        public List<FilteredDistributor> FilterDistributors(FilterDistributorsRequest request)
        {
            var p = new DynamicParameters();
            p.Add("name", request.Name);
            p.Add("surname", request.Surname);
            p.Add("minMaxType", request.MinMaxType);
            var result = dbConnection.Query<FilteredDistributor>("sp_getDistributorBonuses", p, commandType: CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}
