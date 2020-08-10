using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore.Model
{
    public abstract class BaseResponseModel<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        protected BaseResponseModel(T resource)
        {
            Success = true;
            Message = string.Empty;
            Data = resource;
        }

        protected BaseResponseModel(string message)
        {
            Success = false;
            Message = message;
            Data = default;
        }
    }
}
