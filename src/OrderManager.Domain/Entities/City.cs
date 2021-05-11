namespace OrderManager.Domain
{
    public class City: BaseEntity, IShow
    {
        public string Name { get; private set; }
        public string UF { get; private set; }
        public bool Active { get; set; }
    }
}
