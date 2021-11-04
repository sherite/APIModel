namespace Entities.Models
{
    using Entities.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserGroups
    {
        public long UserID { get; set; }
        public Group GroupID { get; set; }
    }
}
