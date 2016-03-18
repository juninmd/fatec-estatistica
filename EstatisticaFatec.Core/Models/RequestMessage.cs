namespace EstatisticaFatec.Core.Models
{
    public class RequestMessage
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public string DevMessage { get; set; }
    }
    public class RequestMessage<T> : RequestMessage
    {
        public T Content { get; set; }
    }
}
