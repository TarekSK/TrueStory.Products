using Refit;
using TrueStory.Products.Core.Contracts;
using TrueStory.Products.Core.Contracts.Product;

namespace TrueStory.Products.RestfulApi.Client
{
    /// <summary>
    /// Restful API client interface.
    /// </summary>
    public interface IRestfulApiClient
    {
        /// <summary>
        /// Get list of objects [products]
        /// </summary>
        [Get(RestfulApiRoutes.Objects)]
        Task<ApiResponse<GetProductsResponse>> Get();

        /// <summary>
        /// Add object [product]
        /// </summary>
        [Post(RestfulApiRoutes.Objects)]
        Task<ApiResponse<AddProductResponse>> Add(Product product);

        /// <summary>
        /// Delete object [product]
        /// </summary>
        [Delete(RestfulApiRoutes.Objects + "/{id}")]
        Task<ApiResponse<DeleteProductResponse>> Delete(string id);
    }
}
