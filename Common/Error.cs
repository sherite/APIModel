namespace Common
{
    public class Error : IError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}