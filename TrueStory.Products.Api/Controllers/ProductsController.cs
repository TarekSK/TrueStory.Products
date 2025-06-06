using Microsoft.AspNetCore.Mvc;
using TrueStory.Products.Core.Contracts.Product;
using TrueStory.Products.Core.Contracts.Result;
using TrueStory.Products.Core.Extensions;
using TrueStory.Products.RestfulApi.Services;

namespace TrueStory.Products.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IProductService productService,
            ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Get list of objects [products] filtered by name and paginated.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List of products filtered and paginated or error</returns>
        [ProducesResponseType(typeof(GetProductsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductRequest request)
        {
            Logger.Info(_logger, "Get product request received", request, default);
            ActivityExtensions.SetGetProductRequest(request);

            var getProductResult = await _productService.Get(request);
            if (!getProductResult.Success)
            {
                return StatusCode(getProductResult.Error!.Code, getProductResult);
            }

            return Ok(getProductResult.Value);
        }

        /// <summary>
        /// Add object [product].
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Added product id and createdAt or error</returns>
        [ProducesResponseType(typeof(AddProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add(AddProductRequest request)
        { 
            Logger.Info(_logger, "Add product request received", request, default);
            ActivityExtensions.SetAddProductRequest(request);

            var addProductResult = await _productService.Add(request);
            if (!addProductResult.Success)
            {
                return StatusCode(addProductResult.Error!.Code, addProductResult);
            }

            return Ok(addProductResult.Value);
        }

        /// <summary>
        /// Delete object [product].
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Delete product message or error</returns>
        [ProducesResponseType(typeof(DeleteProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteProductRequest request)
        {
            Logger.Info(_logger, "Delete product request received", request, default);
            ActivityExtensions.SetDeleteProductRequest(request);

            var deleteProductResult = await _productService.Delete(request);
            if (!deleteProductResult.Success)
            {
                return StatusCode(deleteProductResult.Error!.Code, deleteProductResult);
            }

            return Ok(deleteProductResult.Value);
        }
    }
}
