using Task.Models;

namespace Task.Responses
{
    public class CountDistributorBonusesResponse: Response
    {
        public List<DistributorBonus> DistributorBonuses { get; set; }
    }
}
