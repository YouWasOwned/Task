namespace Task.Requests
{
    public class RegisterProductRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
