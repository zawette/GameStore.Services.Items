using System.Net;

namespace Infrastructure.Exceptions
{
    public class ExceptionResponse
    {
        public readonly string Code;
        public readonly string Message;
        public readonly HttpStatusCode StatusCode;

        public ExceptionResponse(string code, string message, HttpStatusCode statusCode)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }
    }
}