using System;

namespace OrderManager.Domain
{
    public class OrderProduct: BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Guid IdProduct { get; set; }
        public virtual Product Product { get; set; }

        public Guid IdOrder { get; set; }
        public virtual Order Order { get; set; }
    }
}
