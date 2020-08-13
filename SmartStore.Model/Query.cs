using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore.Model
{
    public class Query
    {
        public string SortBy { get; set; } = string.Empty;
        public int Offset { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}
