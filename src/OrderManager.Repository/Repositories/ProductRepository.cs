using OrderManager.Domain;
using OrderManager.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace OrderManager.Repository
{
    public class ProductRepository: BaseRepository, IProductRepository
    {

        public ProductRepository(ApplicationDbContext context): base(context) {        }
        public List<Product> GetAll()
        {
            return _context.Products.Where(x => x.Active).OrderBy(x =>x.Price).Take(1000).ToList();
        }

        public List<Product> GetByCode(string code)
        {
            return _context.Products.Where(x => x.Active && x.Code == code).OrderBy(x => x.Price).Take(1000).ToList();
        }

        public List<Product> GetByName(string name)
        {
            return _context.Products.Where(x => x.Active && x.Name.ToUpper().Contains(name.ToUpper())).OrderBy(x => x.Price).Take(1000).ToList();
        }

        public List<Product> Detail(int? id)
        {

        }
        public string Error()
        {
            return "you need to enter a value!";
        }
    }
}
