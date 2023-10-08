namespace Utilities.Commons.Exceptions;

public class ApiErrorException
{
    public ApiErrorException(int statusCode, string message, string errorDateTime)
    {
        this.StatusCode = statusCode;
        this.Message = message;
        this.ErrorDateTime = errorDateTime;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ErrorDateTime { get; set; }
}