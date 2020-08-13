using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.DataAccess.Entity
{
    public class OrderItem : BaseEntity
    {
        public int OrderID { get; set; }

        [NotMapped]
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public  Product Product { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}
