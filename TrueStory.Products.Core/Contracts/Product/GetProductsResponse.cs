namespace TrueStory.Products.Core.Contracts.Product
{
    /// <summary>
    /// Get products response.
    /// Used in product service to return products from the client
    /// </summary>
    public class GetProductsResponse : List<ProductDetails>
    {
    }

    public class ProductDetails : Product
    {
        public string Id { get; set; } = string.Empty;
    }
}
