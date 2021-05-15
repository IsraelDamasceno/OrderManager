using System;

namespace OrderManager.Domain
{
    public class ProductCombo
    {
        public Guid IdProduct { get; set; }
        public virtual Product Product { get; set; }

        public Guid IdCombo { get; set; }
        public virtual Combo Combo { get; set; }
    }
}
