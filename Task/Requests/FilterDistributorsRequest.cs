using Task.Models.Enums;

namespace Task.Requests
{
    public class FilterDistributorsRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal MinBonusAmount { get; set; }
        public decimal MaxBonusAmount { get; set; }
    }
}