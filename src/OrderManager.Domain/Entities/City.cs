namespace OrderManager.Domain
{
    public class City: BaseEntity, IShow
    {
        public string Name { get;  set; }
        public string UF { get;  set; }
        public bool Active { get; set; }
    }
}
