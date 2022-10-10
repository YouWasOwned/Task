using Task.Models;

namespace Task.Responses
{
    public class FilterDistributorsResponse : Response
    {
        public List<FilteredDistributor> FilteredDistributors{ get; set; }
    }
}