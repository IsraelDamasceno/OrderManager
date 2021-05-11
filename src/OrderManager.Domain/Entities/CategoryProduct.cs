namespace OrderManager.Domain
{
    public class CategoryProduct : BaseEntity, IShow
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}