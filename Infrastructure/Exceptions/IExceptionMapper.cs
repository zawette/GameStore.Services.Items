using System;

namespace Infrastructure.Exceptions
{
    public interface IExceptionMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}