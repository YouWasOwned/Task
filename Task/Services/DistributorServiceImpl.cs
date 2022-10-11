using Task.Models;
using Task.Repository;
using Task.Requests;
using Task.Responses;

namespace Task.Services
{
    public class DistributorServiceImpl : DistributorService
    {

        private readonly IDistributorRepository distirbutorRepository;
        private readonly IWebHostEnvironment _hostEnvitonment;

        public DistributorServiceImpl(IDistributorRepository distirbutorRepository, IWebHostEnvironment hostEnvitonment)
        {
            this.distirbutorRepository = distirbutorRepository;
            _hostEnvitonment = hostEnvitonment; 
        }

        public CountDistributorBonusesResponse CountDistributorBonuses(CountDistributorBonusesRequest request)
        {
            var result = distirbutorRepository.CountDistributorBonuses(request);
            var message = result.Count() == 0 ? "Distributor Bonuses Are Already Counted For This Period" : "SUCCESS";
            return new CountDistributorBonusesResponse()
            {
                StatusCode = 200,
                Message = message,
                DistributorBonuses = result
            };
        }

        public Response DeleteDistributor(DeleteDistributorRequest request)
        {
            var result = distirbutorRepository.DeleteDistributorById(request.DistributorID);
            var message = result == 0 ? "Distributor Deleted Successfully" : "Distributor Not Found";
            var statusCode = result == 0 ? 200 : 404;
            return new Response()
            {
                StatusCode = statusCode,
                Message = message
            };
        }

        public FilterDistributorsResponse FilterDistributors(FilterDistributorsRequest request)
        {
            var result = distirbutorRepository.FilterDistributors(request);
            var message = result.Count() == 0 ? "No Results" : "SUCCESS";
            return new FilterDistributorsResponse()
            {
                StatusCode = 200,
                Message = message,
                FilteredDistributors = result
            };
        }

        public GetAllDistributorsResponse GetAllDistributors()
        {
            var distributors = distirbutorRepository.GetAllDistributors();
            return new GetAllDistributorsResponse()
            {
                StatusCode = 200,
                Message = "SUCCESS",
                Distributors = distributors
            };
        }

        public GetDistributorBonusAmountResponse GetDistributorBonusAmount(GetDistributorBonusAmountRequest request)
        {
            var amount = distirbutorRepository.GetDistributorBonus(request.DistributorId);
            return new GetDistributorBonusAmountResponse()
            {
                StatusCode = 200,
                Message = "SUCCESS",
                BonusAmount = amount
            };
        }

        public async Task<Response> RegisterDistributorAsync(RegisterDistributorRequest request)
        {
            var newDistributorLevel = 1;
            var newDistributorRecommendedPeopleCount = 0;
            if (request.RecommenderID != null)
            {
                var recommenderId = (int)request.RecommenderID;
                var recommender = distirbutorRepository.GetRecommenderDistributor(recommenderId);
                if (recommender.RecommendedDistributorsCount == 3)
                {
                    return new Response()
                    {
                        StatusCode = 200,
                        Message = "Recommender Distributor Already Has 3 Recomendations"
                    };
                }
                if (recommender.RecommendedDistributorsCount < 3 && recommender.Level != 5)
                {
                    newDistributorLevel = recommender.Level + 1;
                    var recommendedPeopleCount = recommender.RecommendedDistributorsCount + 1;
                    distirbutorRepository.UpdateDistributorRecommendedDistributorsCount(recommenderId, recommendedPeopleCount);
                }
            }
            var imagePath = "";
            if (request.ImageFile != null)
            {
                string wwwRootPath = _hostEnvitonment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(request.ImageFile.FileName);
                string extension = Path.GetExtension(request.ImageFile.FileName);

                imagePath = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwRootPath, imagePath);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await request.ImageFile.CopyToAsync(fileStream);
                }
            }

            distirbutorRepository.RegisterDistributor(request, imagePath, newDistributorLevel, newDistributorRecommendedPeopleCount);

            return new Response()
            {
                StatusCode = 200,
                Message = "Distributor Registered Successfully"
            };
        }

    }

}
