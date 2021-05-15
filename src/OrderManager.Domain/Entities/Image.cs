using System.Collections.Generic;

namespace OrderManager.Domain
{
    public class Image: BaseEntity
    {
        public string Name { get; set; }
        public string NameFile { get; set; }
        public bool Main { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
