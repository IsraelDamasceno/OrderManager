namespace OrderManager.Domain
{
    public class City: BaseEntity
    {
        public string Name { get; private set; }
        public string UF { get; private set; }
    }
}
