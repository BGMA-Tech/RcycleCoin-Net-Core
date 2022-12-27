﻿namespace Core.Utilities.JsonResults.Concrete
{
    public class ResultDataJson<T>
    {
        public T Data { get; set; }
        public Error ErrorMessage { get; set; }
        public bool Status { get; set; }

    }
}
