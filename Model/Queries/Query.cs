using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Query
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
