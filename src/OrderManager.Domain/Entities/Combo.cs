using System;
using System.Collections.Generic;

namespace OrderManager.Domain
{
    public class Combo:BaseEntity, IShow
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid IdImage { get; set; }
        public virtual Image Image { get; set; }
        public virtual List<Product> Products { get; set; }
        public bool Active { get; set; }
    }
}
