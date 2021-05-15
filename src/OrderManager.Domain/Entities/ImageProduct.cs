using System;

namespace OrderManager.Domain
{
    public class ImageProduct: BaseEntity
    {
            public Guid IdImage { get; set; }
            public virtual Image Image { get; set; }

            public Guid IdProduct { get; set; }
            public virtual Product Product { get; set; }

    }
}
