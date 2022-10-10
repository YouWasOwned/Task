using Microsoft.AspNetCore.Mvc;
using Task.Requests;
using Task.Responses;
using Task.Services;

namespace Task.Controllers
{
    [ApiController]
    public class ProductController
    {

        private readonly ProductService productService;
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("register-product")]
        public Response RegisterProduct(RegisterProductRequest request)
        {
            return productService.RegisterProduct(request);
        }
    }
}
