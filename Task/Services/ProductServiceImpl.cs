using Task.Repository;
using Task.Requests;
using Task.Responses;

namespace Task.Services
{
    public class ProductServiceImpl : ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductServiceImpl(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Response RegisterProduct(RegisterProductRequest request)
        {
            productRepository.RegisterProduct(request.Code, request.Name, request.UnitPrice);
            return new Response()
            {
                StatusCode = 200,
                Message = "Product Added Successfully"
            };
        }
    }
}
