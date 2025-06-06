namespace TrueStory.Products.RestfulApi.Client
{
    /// <summary>
    /// Client options for the Restful API.
    /// </summary>
    public class RestfulApiOptions
    {
        public const string Section = "RestfulApi";
        public required Uri BaseAddress { get; set; }
    }
}
