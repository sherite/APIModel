﻿namespace Common
{
    using System;
    using System.Collections.Generic;

    public class ManagerResponse<T> : IManagerResponse<T>
    {
        public Guid ExternalCorrelationId { get; set; }
        public ICollection<IObjectResponse<T>> Object { get; set; }
        public bool HasErrors { get; set; }
    }
}