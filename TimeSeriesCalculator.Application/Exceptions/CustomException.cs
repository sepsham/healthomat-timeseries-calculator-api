using System.Globalization;

namespace TimeSeriesCalculator.Application.Exceptions;

public class CustomException : Exception
{
    public CustomException() : base()
    {
    }
    public CustomException(string message) : base(message)
    {
    }
    public CustomException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}

public enum StatusCode
{
    Success = 200,
    ServerError = 500,
    BadRequest = 400,
    NotFound = 404,
    UnAuthorized = 403,
    AuthenticationFailed = 401
}
