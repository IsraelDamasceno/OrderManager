using System;

namespace OrderManager.Interface.Repositories
{
    public interface IProductRepository
    {
        dynamic Get(string ordem);
        dynamic Search(string text, int pagina, string ordem);
        dynamic Detail(Guid id);
        dynamic Imagens(Guid id);
    }
}
