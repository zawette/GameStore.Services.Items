using Application.Exceptions;
using Domain.Exceptions;
using System;
using System.Net;

namespace Infrastructure.Exceptions
{
    public class ExceptionMapper : IExceptionMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                DomainException e => new ExceptionResponse(e.Code, e.Message, HttpStatusCode.BadRequest),
                AppException e => new ExceptionResponse(e.Code, e.Message, HttpStatusCode.BadRequest),
                _ => new ExceptionResponse("error", "an error occurred", HttpStatusCode.InternalServerError)
            };
    }
}