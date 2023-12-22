namespace Innoplatforma.Server.Service.Extensions
{
    public class InnoPlatformException : Exception
    {
        public int StatusCode { get; set; }

        public InnoPlatformException(int code, string message) : base(message)
        {
            StatusCode = code;
        }
    }
}
