using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class QueryResult<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public  T Item { get; set; }
        public int Count { get; set; }
    }
}
