using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore.Model
{
    public class QueryResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public int Count { get; set; }
    }
}
