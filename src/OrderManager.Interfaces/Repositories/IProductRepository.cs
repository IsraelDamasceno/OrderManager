using OrderManager.Domain;
using System.Collections.Generic;

namespace OrderManager.Interface.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product> GetByName(string name);
        List<Product> GetByCode(string code);
        List<Product> Detail(int? id);
        string Error();
    }
}
