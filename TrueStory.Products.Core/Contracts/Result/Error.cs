namespace TrueStory.Products.Core.Contracts.Result
{
    /// <summary>
    /// Error model
    /// Used to return error information in the response.
    /// </summary>
    [Serializable]
    public class Error
    {
        public int Code { get; }

        public string Message { get; }

        public Error(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
