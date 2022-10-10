using Task.Requests;
using Task.Responses;

namespace Task.Services
{
    public interface ProductService
    {
        public Response RegisterProduct(RegisterProductRequest request);
    }
}
