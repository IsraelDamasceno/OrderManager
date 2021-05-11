using System;

namespace OrderManager.Domain
{
    public class Client: BaseEntity, IShow
    {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public Guid IdAddress { get; set; }
        public virtual Address Address  { get; set; }
        public bool Active { get; set; }
    }
}
