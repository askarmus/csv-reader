using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.DataAccess.Entity.CustomEntities
{
    public class ProductRating
    {
        public int TotalRatings { get; set; }
        public int AverageRating { get; set; }
    }
}
