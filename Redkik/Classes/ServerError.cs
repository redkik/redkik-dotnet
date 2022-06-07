namespace Redkik.Classes
{
    public class Error
    {
        public int? statusCode { get; set; }
        public string? name { get; set; }
        public string? message { get; set; }
        public string? code { get; set; }
    }

    public class ServerError
    {
        public Error? error { get; set; }
    }
}
