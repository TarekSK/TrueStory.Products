namespace TrueStory.Products.Core.Contracts.Product
{
    /// <summary>
    /// Add product response.
    /// </summary>
    public class AddProductResponse : Product
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
