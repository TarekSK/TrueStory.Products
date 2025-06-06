using System.Text.Json;

namespace TrueStory.Products.Core.Contracts.Product
{
    /// <summary>
    /// Product model.
    /// Main object for the product.
    /// </summary>
    public class Product
    {
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, JsonElement>? Data { get; set; }
    }
}
