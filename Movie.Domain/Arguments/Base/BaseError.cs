namespace Movie.Domain.Arguments.Base;

public class BaseError
{
    public BaseError(string message, string stackTrace, string innerException)
    {
        Message = message;
        StackTrace = stackTrace;
        InnerException = innerException;
    }

    public BaseError(Exception e)
    {
        Message = e.Message;
        StackTrace = e.StackTrace;
        InnerException = e.InnerException?.Message;
    }

    public BaseError()
    {
        Message = string.Empty;
        StackTrace = string.Empty;
        InnerException = string.Empty;
    }

    public string Message { get; set; }
    public string StackTrace { get; set; }
    public string InnerException { get; set; }
}
