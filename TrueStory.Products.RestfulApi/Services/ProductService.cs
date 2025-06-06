using Microsoft.Extensions.Logging;
using TrueStory.Products.Core.Contracts.Product;
using TrueStory.Products.Core.Contracts.Result;
using TrueStory.Products.Core.Extensions;
using TrueStory.Products.RestfulApi.Client;
using TrueStory.Products.RestfulApi.Extensions;
using TrueStory.Products.RestfulApi.Helpers;

namespace TrueStory.Products.RestfulApi.Services
{
    /// <summary>
    /// Product service implementation.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRestfulApiClient _restfulApiClient;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IRestfulApiClient restfulApiClient, 
            ILogger<ProductService> logger)
        {
            _restfulApiClient = restfulApiClient;
            _logger = logger;
        }

        /// <summary>
        /// Get list of objects [products]
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result contains products or error</returns>
        public async Task<Result<GetProductsPagedResponse>> Get(GetProductRequest request)
        {
            try
            {
                var response = await _restfulApiClient.Get();
                if (!response.IsSuccessStatusCode)
                {
                    Logger.Error(_logger, "Failed to get products", response.Error, 
                        ActivityExtensions.GetTraceId(), default);
                    ActivityExtensions.SetError(response.Error.ToErrorDetails());

                    return Result<GetProductsPagedResponse>.Fail(response.Error.ToErrorDetails());
                }

                var result = ProductHelper.FilterAndPaginate(
                    response.Content!,
                    request.NameFilter,
                    request.Page,
                    request.PageSize);

                Logger.Info(_logger, "Products retrieved successfully", result, default);
                return Result<GetProductsPagedResponse>.Ok(GetProductsPagedResponse.Create(result));
            }
            catch (Exception ex)
            {
                Logger.Error(_logger, "Error occurred while getting products", ex.Message,
                    ActivityExtensions.GetTraceId(), ex);
                ActivityExtensions.SetError(ex.ToErrorDetails());

                return Result<GetProductsPagedResponse>.Fail(ex.ToErrorDetails());
            }
        }

        /// <summary>
        /// Add object [product]
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result contains productId and createdAt or error</returns>
        public async Task<Result<AddProductResponse>> Add(AddProductRequest request)
        {
            try
            {
                var response = await _restfulApiClient.Add(request.Product);
                if (!response.IsSuccessStatusCode)
                {
                    Logger.Error(_logger, "Failed to add products", response.Error,
                        ActivityExtensions.GetTraceId(), default);
                    ActivityExtensions.SetError(response.Error.ToErrorDetails());

                    return Result<AddProductResponse>.Fail(response.Error.ToErrorDetails());
                }

                Logger.Info(_logger, "Product added successfully", response.Content!, default);
                return Result<AddProductResponse>.Ok(response.Content!);
            }
            catch (Exception ex)
            {
                Logger.Error(_logger, "Error occurred while getting products", ex.Message,
                    ActivityExtensions.GetTraceId(), ex);
                ActivityExtensions.SetError(ex.ToErrorDetails());

                return Result<AddProductResponse>.Fail(ex.ToErrorDetails());
            }
        }

        /// <summary>
        /// Delete object [product]
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result contains delete product message or error</returns>
        public async Task<Result<DeleteProductResponse>> Delete(DeleteProductRequest request)
        {
            try
            {
                var response = await _restfulApiClient.Delete(request.Id);
                if (!response.IsSuccessStatusCode)
                {
                    Logger.Error(_logger, "Failed to delete products", response.Error,
                        ActivityExtensions.GetTraceId(), default);
                    ActivityExtensions.SetError(response.Error.ToErrorDetails());

                    return Result<DeleteProductResponse>.Fail(response.Error.ToErrorDetails());
                }

                Logger.Info(_logger, "Product with Id {Id} deleted successfully", request.Id, default);
                return Result<DeleteProductResponse>.Ok(response.Content!);
            }
            catch (Exception ex)
            {
                Logger.Error(_logger, "Error occurred while getting products", ex.Message,
                    ActivityExtensions.GetTraceId(), ex);
                ActivityExtensions.SetError(ex.ToErrorDetails());

                return Result<DeleteProductResponse>.Fail(ex.ToErrorDetails());
            }
        }
    }
}
