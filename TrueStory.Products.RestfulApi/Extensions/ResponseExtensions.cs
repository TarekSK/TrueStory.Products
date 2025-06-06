using Refit;
using System.Net;
using TrueStory.Products.Core.Contracts.Result;

namespace TrueStory.Products.RestfulApi.Extensions
{
    /// <summary>
    /// Response extensions for converting exceptions to error details.
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Converts an exception to error details.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Error ToErrorDetails(this Exception exception)
        {
            return new Error((int)HttpStatusCode.InternalServerError, exception.Message);
        }

        /// <summary>
        /// Converts an ApiException to error details.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Error ToErrorDetails(this ApiException exception)
        {
            return new Error((int)exception.StatusCode, exception.Content!);
        }
    }
}
