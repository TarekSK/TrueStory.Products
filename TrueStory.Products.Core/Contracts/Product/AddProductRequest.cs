namespace TrueStory.Products.Core.Contracts.Product
{
    /// <summary>
    /// Add product request.
    /// </summary>
    public class AddProductRequest
    {
        public Product Product { get; set; } = new Product();
    }
}
