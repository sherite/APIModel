namespace Common
{
    public interface IError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
