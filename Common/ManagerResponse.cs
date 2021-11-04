namespace Common
{
    using System;
    using System.Collections.Generic;

    public class ManagerResponse<T>
    {
        public Guid ExternalCorrelationId { get; set; }
        public List<ObjectResponse<T>> Object { get; set; }
        public bool HasErrors { get; set; }
    }
}