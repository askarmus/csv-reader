using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore.API.Resources
{
    public class QueryResource
    {
        public string SortBy { get; set; } = string.Empty;
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
