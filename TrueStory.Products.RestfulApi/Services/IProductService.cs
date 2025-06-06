using TrueStory.Products.Core.Contracts.Product;
using TrueStory.Products.Core.Contracts.Result;

namespace TrueStory.Products.RestfulApi.Services
{
    /// <summary>
    /// Product service interface.
    /// </summary>
    public interface IProductService
    {
        Task<Result<GetProductsPagedResponse>> Get(GetProductRequest request);
        Task<Result<AddProductResponse>> Add(AddProductRequest request);
        Task<Result<DeleteProductResponse>> Delete(DeleteProductRequest request);
    }
}
