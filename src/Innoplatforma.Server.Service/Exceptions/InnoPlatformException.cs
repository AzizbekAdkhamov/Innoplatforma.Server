namespace Innoplatforma.Server.Service.Exceptions;

public class InnoplatformException : Exception
{
    public int StatusCode { get; set; }
    public InnoplatformException(int code, string message) : 
        base(message)
    {
        StatusCode = code;
    }
}