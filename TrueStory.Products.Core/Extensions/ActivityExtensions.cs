using System.Diagnostics;
using System.Text.Json;
using TrueStory.Products.Core.Contracts.Product;
using Error = TrueStory.Products.Core.Contracts.Result.Error;

namespace TrueStory.Products.Core.Extensions
{
    /// <summary>
    /// Activity extensions for setting tags and getting trace ID.
    /// As a feature of OpenTelemetry, this is used to track the flow of requests and responses in a distributed system.
    /// </summary>
    public static class ActivityExtensions
    {
        public static string GetTraceId()
        {
            return Activity.Current?.TraceId.ToString()!;
        }

        public static void SetGetProductRequest(GetProductRequest request)
        {
            var activity = Activity.Current;
            if (activity == null) return;

            activity.SetTag("request.NameFilter", request.NameFilter);
            activity.SetTag("request.page", request.Page);
            activity.SetTag("request.page_size", request.PageSize);
        }

        public static void SetAddProductRequest(AddProductRequest request)
        {
            var activity = Activity.Current;
            if (activity == null) return;

            SetProduct(request.Product);
        }

        public static void SetDeleteProductRequest(DeleteProductRequest request)
        {
            var activity = Activity.Current;
            if (activity == null) return;
            activity.SetTag("request.id", request.Id);
        }

        public static void SetError(Error error)
        {
            var activity = Activity.Current;
            if (activity == null) return;

            activity.SetTag("error.code", error.Code);
            activity.SetTag("error.message", error.Message);
        }

        private static void SetProduct(Product product)
        {
            var activity = Activity.Current;
            if (activity == null) return;

            activity.SetTag("product.name", product.Name);

            if (product.Data != null)
            {
                foreach (var data in product.Data)
                {
                    activity.SetTag("product." + data.GetKey(), data.GetValue());
                }
            }
        }

        private static string GetKey(this KeyValuePair<string, JsonElement> data)
        {
            return data.Key.ToLowerInvariant().Replace(" ", "_");
        }

        private static string GetValue(this KeyValuePair<string, JsonElement> data)
        {
            return data.Value.ToString();
        }
    }
}
