namespace Entities.Models
{
    using Entities.Interfaces;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : IAudit
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool Enabled { get; set; }
        public string Password { get; set; }
        public long? AuditID { get; set; }
        public int RowVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}