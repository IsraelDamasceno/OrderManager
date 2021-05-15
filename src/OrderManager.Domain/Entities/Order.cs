using System;
using System.Collections.Generic;

namespace OrderManager.Domain
{
    public class Order :BaseEntity
    {
        public Guid OrderNumber { get; set; }
        public decimal Amount { get; set; }
        public TimeSpan Delivery { get; set; }
        public Guid IdClient { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<OrderProduct> Products { get; set; }
    }
}
