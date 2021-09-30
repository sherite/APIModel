namespace Common
{
    using System;
    using System.Collections.Generic;

    public class ManagerResponse<T>
    {
        public Guid CorrelationId { get; set; }
        public T Object { get; set; }
        public string AdditionalInfo { get; set; }
        public List<Error> ErrorsList { get; set; }
    }
}
