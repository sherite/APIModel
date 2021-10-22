namespace Common
{
    using System;
    using System.Collections.Generic;
    public interface IManagerResponse<T>
    {
        public Guid ExternalCorrelationId { get; set; }
        public ICollection<IObjectResponse<T>> Object { get; set; }
        public bool HasErrors { get; set; }
    }

    public interface IObjectResponse<T>
    {
        public Guid InternalCorrelationId { get; set; }
        public T Object { get; set; }
        public Error Error { get; set; }
    }
}