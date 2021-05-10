using System;

namespace OrderManager.Domain
{
    public class Address: BaseEntity
    {
        public ETypeAddress Type { get; set; }
        public string PublicPlace { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string PostalCode { get; set; }
        public Guid IdCity { get; set; }
        public virtual City City { get; set; }
    }
}
