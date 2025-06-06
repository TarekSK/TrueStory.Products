namespace TrueStory.Products.Core.Contracts.Product
{
    /// <summary>
    /// Get products paged response.
    /// Used in the controller to return a paged list of products.
    /// </summary>
    public class GetProductsPagedResponse
    {
        public PagedResult<ProductDetails> Products { get; set; } = new PagedResult<ProductDetails>();

        public static GetProductsPagedResponse Create(PagedResult<ProductDetails> pagedResponse)
        {
            return new GetProductsPagedResponse
            {
                Products = pagedResponse
            };
        }
    }
}
