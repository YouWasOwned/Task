namespace Task.Repository
{
    public interface IProductRepository
    {
        public void RegisterProduct(string code, string name, decimal unitPrice);
    }
}
