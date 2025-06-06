namespace TrueStory.Products.Core.Contracts.Product
{
    /// <summary>
    /// Paged result.
    /// Used in the controller to return a filtered and paged list of products.
    /// </summary>
    /// <typeparam name="T">Product details</typeparam>
    public class PagedResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}
