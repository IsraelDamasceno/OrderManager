namespace OrderManager.Domain
{
    public class ImageProduct
    {
            public int IdImage { get; set; }
            public virtual Image Image { get; set; }

            public int IdProduct { get; set; }
            public virtual Product Product { get; set; }

    }
}
