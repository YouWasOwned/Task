using Task.Models;
using Task.Models.Enums;
using Task.Requests;

namespace Task.Repository
{
    public interface IDistributorRepository
    {
        public void RegisterDistributor(RegisterDistributorRequest request, string imagePath, int newDistributorLevel, int newDistributorRecommendedPeopleCount);

        public RecommenderDistibutor GetRecommenderDistributor(int distiburotId);

        public void UpdateDistributorRecommendedDistributorsCount(int distiburotId, int recommendedDistributorsCount);

        public int DeleteDistributorById(int distiburotId);

        public List<Distributor> GetAllDistributors();

        public List<DistributorBonus> CountDistributorBonuses(CountDistributorBonusesRequest request);

        public Decimal GetDistributorBonus(int distributorId);

        public List<FilteredDistributor> FilterDistributors(FilterDistributorsRequest request); 
    }
}