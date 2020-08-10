using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStore.API.Resources
{
    public class QueryResultResource<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public int Count { get; set; }
    }
}
