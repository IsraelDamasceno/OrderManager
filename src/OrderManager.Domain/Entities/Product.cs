using System;
using System.Collections.Generic;

namespace OrderManager.Domain
{
    public class Product: BaseEntity, IShow
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid IdCategory { get; set; }
        public virtual CategoryProduct CategoryProduct { get; set; }
        public virtual List<Image> Images { get; set; }
        public bool Active { get; set; }

    }
}
