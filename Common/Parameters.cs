namespace Common
{
    public class Parameters
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string Field { get; set; }
        public string TotalRecords { get; set; }
        public Pagination Pagination { get; set; }
        public Ordination Ordination { get; set; }
    }
}