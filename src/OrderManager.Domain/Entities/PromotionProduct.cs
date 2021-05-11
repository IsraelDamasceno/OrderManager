using System;

namespace OrderManager.Domain
{
    public class PromotionProduct:BaseEntity, IShow
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid IdImage { get; set; }
        public virtual Image Image { get; set; }
        public Guid IdProduct { get; set; }
        public virtual Product Product { get; set; }
        public bool Active { get; set; }
    }
}
