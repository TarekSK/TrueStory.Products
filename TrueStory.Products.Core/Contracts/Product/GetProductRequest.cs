namespace TrueStory.Products.Core.Contracts.Product
{
    /// <summary>
    /// Get product request.
    /// </summary>
    public class GetProductRequest
    {
        public string? NameFilter { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
