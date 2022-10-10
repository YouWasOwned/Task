using Task.Models;

namespace Task.Responses
{
    public class GetAllDistributorsResponse : Response
    {
        public List<Distributor> Distributors { get; set; }
    }
}
