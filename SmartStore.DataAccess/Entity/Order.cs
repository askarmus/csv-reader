using System;
using System.Collections.Generic;

namespace SmartStore.DataAccess.Entity
{
    public class Order : BaseEntity
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerZipCode { get; set; }

        public string OrderCode { get; set; }
        public int PaymentMethod { get; set; }
        public decimal TotalAmmount { get; set; }
        public decimal Discount { get; set; }
        public decimal DeliveryCharges { get; set; }
        public decimal FinalAmmount { get; set; }
        public DateTime PlacedOn { get; set; }

        public string TransactionID { get; set; }

        public bool IsGuestOrder { get; set; }

        public int? PromoID { get; set; }
        public  Promo Promo { get; set; }

        public  List<OrderItem> OrderItems { get; set; }
        public  List<OrderHistory> OrderHistory { get; set; }
    }
}
