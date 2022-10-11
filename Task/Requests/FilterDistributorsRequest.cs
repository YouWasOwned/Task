namespace Task.Requests
{
    public class FilterDistributorsRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal MinBonusAmount { get; set; } = -1;
        public decimal MaxBonusAmount { get; set; } = decimal.MaxValue;
    }
}