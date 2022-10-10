using Task.Requests;
using Task.Responses;

namespace Task.Services
{
    public interface DistributorService
    {
        public Task<Response> RegisterDistributorAsync(RegisterDistributorRequest request);

        public Response DeleteDistributor(DeleteDistributorRequest request);

        public GetAllDistributorsResponse GetAllDistributors();

        public CountDistributorBonusesResponse CountDistributorBonuses(CountDistributorBonusesRequest request);

        public GetDistributorBonusAmountResponse GetDistributorBonusAmount(GetDistributorBonusAmountRequest request);

        public FilterDistributorsResponse FilterDistributors(FilterDistributorsRequest request);
    }
}
