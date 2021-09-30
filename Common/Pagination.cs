namespace Common
{
    public class Pagination
    {
        public int? FromPage { get; set; }
        public int? ToPage { get; set; }
        public int? RowsPerPage { get; set; }
        public int? TotalRows { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
    }
}