using Microsoft.EntityFrameworkCore;
using OrderManager.Domain;
using OrderManager.Interface.Repositories;
using System;
using System.Linq;

namespace OrderManager.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(ApplicationDbContext context) : base(context) { }

        private void OrderbyName(IQueryable<Product> query, string order)
        {
            if (string.IsNullOrEmpty(order) || order.ToUpper() == "ASC")
            {
                query = query.OrderBy(x => x.Name);
            }
            else
            {
                query = query.OrderByDescending(x => x.Name);
            }
        }


        public dynamic Get(string order)
        {
            var queryProduto = _context.Products
                .Include(x => x.CategoryProduct)
                .Where(x => x.Active);

            OrderbyName(queryProduto, order);

            var queryRetorno = queryProduto
                .Select(x => new
                {
                    x.Name,
                    x.Price,
                    Categoria = x.CategoryProduct.Name,
                    Imagens = x.Images.Select(i => new
                    {
                        i.Id,
                        i.Name,
                        i.NameFile
                    })
                });

            return queryRetorno.ToList();
        }

        public dynamic Search(string text, int pagina, string order)
        {
            var queryProduto = _context.Products
                .Include(x => x.CategoryProduct)
                .Where(x => x.Active && (x.Name.ToUpper().Contains(text.ToUpper()) || x.Description.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina);

            OrderbyName(queryProduto, order);

            var queryRetorno = queryProduto
                .Select(x => new
                {
                    x.Name,
                    x.Price,
                    Categoria = x.CategoryProduct.Name,
                    Imagens = x.Images.Select(i => new
                    {
                        i.Id,
                        i.Name,
                        i.NameFile
                    })
                });

            var products = queryRetorno.ToList();

            var quantProdutos = _context.Products
                .Where(x => x.Active && (x.Name.ToUpper().Contains(text.ToUpper()) || x.Description.ToUpper().Contains(text.ToUpper())))
                .Count();

            var quantPaginas = (quantProdutos / TamanhoPagina);
            if (quantPaginas < 1)
            {
                quantPaginas = 1;
            }

            return new { products, quantPaginas };
        }

        public dynamic Detail(Guid id)
        {
            return _context.Products
                .Include(x => x.Images)
                .Include(x => x.CategoryProduct)
                .Where(x => x.Active && x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Code,
                    x.Description,
                    x.Price,
                    Categoria = new
                    {
                        x.CategoryProduct.Id,
                        x.CategoryProduct.Name
                    },
                    Imagens = x.Images.Select(i => new
                    {
                        i.Id,
                        i.Name,
                        i.NameFile
                    })
                })
                .FirstOrDefault();
        }

        public dynamic Imagens(Guid id)
        {
            return _context.Products
                .Include(x => x.Images)
                .Where(x => x.Active && x.Id == id)
                .SelectMany(x => x.Images, (product, imagem) => new
                {
                    IdProduto = product.Id,
                    imagem.Id,
                    imagem.Name,
                    imagem.NameFile
                })
                .FirstOrDefault();
        }
    }
}
