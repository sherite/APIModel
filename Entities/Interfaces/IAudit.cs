namespace Entities.Interfaces
{
    using System;
    public interface IAudit
    {
        public long? AuditID { get; set; }
        public int RowVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
