using System;
using System.Collections.Generic;

namespace OrderManager.Domain
{
    public class Combo:BaseEntity
    {
        public string Nome { get; set; }
        public decimal Price { get; set; }
        public Guid IdImage { get; set; }
        public virtual Image Image { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
