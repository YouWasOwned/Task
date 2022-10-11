using Microsoft.AspNetCore.Mvc;
using Task.Requests;
using Task.Responses;
using Task.Services;

namespace Task.Controllers
{
    [ApiController]
    public class DistibutorController
    {
        private readonly DistributorService distributorService;

        public DistibutorController(DistributorService distributorService)
        {
            this.distributorService = distributorService;
        }

        [HttpPost("register-distributor")]
        public async Task<Response> RegisterDistributor([FromForm]RegisterDistributorRequest request)
        {
            return await distributorService.RegisterDistributorAsync(request);
        }

        [HttpPost("delete-distributor")]
        public Response DeleteDistributor(DeleteDistributorRequest request)
        {
            return distributorService.DeleteDistributor(request);
        }

        [HttpGet("get-all-distributors")]
        public GetAllDistributorsResponse GetAllDistributors()
        {
            return distributorService.GetAllDistributors();
        }

        [HttpPost("count-distributor-bonuses")]
        public CountDistributorBonusesResponse CountDistributorBonuses(CountDistributorBonusesRequest request)
        {
            return distributorService.CountDistributorBonuses(request);
        }

        [HttpPost("get-distributor-bonus-amount")]
        public GetDistributorBonusAmountResponse GetDistributorBonusAmount(GetDistributorBonusAmountRequest request)
        {
            return distributorService.GetDistributorBonusAmount(request);
        }


        [HttpPost("filter-distributors")]
        public FilterDistributorsResponse FilterDistributors(FilterDistributorsRequest request)
        {
            return distributorService.FilterDistributors(request);
        }


    }
}
