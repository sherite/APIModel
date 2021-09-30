namespace Common
{
    public class Error
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ExtendedDescription { get; set; }
        public object ErrorObject { get; set; }
    }
}
