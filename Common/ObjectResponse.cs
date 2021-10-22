namespace Common
{
    using System;
    public class ObjectResponse<T> : IObjectResponse<T>
    {
        public Guid InternalCorrelationId { get; set; }
        public T Object { get; set; }
        public Error Error { get; set; }
    }
}
