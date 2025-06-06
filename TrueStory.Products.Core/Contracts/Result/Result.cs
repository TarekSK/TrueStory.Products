using System.Net;

namespace TrueStory.Products.Core.Contracts.Result
{
    /// <summary>
    /// Result, Used to move data and error information between layers.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Result<T> 
    {
        public bool Success { get; set; }
        public T? Value { get; set; }
        public Error? Error { get; set; }

        public static Result<T> Ok(T value)
        {
            return new Result<T>
            {
                Success = true,
                Value = value
            };
        }

        public static Result<T> Fail(Error error)
        {
            return new Result<T>
            {
                Success = false,
                Error = error
            };
        }
    }
}
