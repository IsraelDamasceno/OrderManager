using Microsoft.AspNetCore.Mvc;
using OrderManager.Domain;
using OrderManager.Interface.Repositories;
using System;
using System.Collections.Generic;

namespace OrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : AppBaseController
    {
        public ProductController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        [HttpGet]
        [Route("{GetProdutos}")]
        public IEnumerable<Product> GetProduct()
        {
            //TODO: TASK - ACTION
            //TODO: fazer um  try e tratamento caso de erro
            var _repo = (IProductRepository)_serviceProvider.GetService(typeof(IProductRepository));
            return _repo.GetAll();   
        }

        [HttpGet]
        [Route("{SearchProdutosByName}")]
        public IEnumerable<Product> SearchName(string name)
        {
            //TODO: TASK - ACTION
            //TODO: Validação para nome do produto.
            //TODO: fazer um  try e tratamento caso de erro
            var _repo = (IProductRepository)_serviceProvider.GetService(typeof(IProductRepository));
            return _repo.GetByName(name);
        }

        [HttpGet]
        [Route("{SearchProdutosByCode}")]
        public IEnumerable<Product> SearchCode(string code)
        {
            //TODO: TASK - ACTION
            //TODO: Validação para código do produto.
            //TODO: fazer um  try e tratamento caso de erro
            var _repo = (IProductRepository)_serviceProvider.GetService(typeof(IProductRepository));
            return _repo.GetByCode(code);
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<Product> Detail(int? id)
        {
            if((id ?? 0) > 0)
            {
                var _repo = (IProductRepository)_serviceProvider.GetService(typeof(IProductRepository));
                return _repo.Detail(id.Value);
            }
            else
            {
                return null;
            }
        }

    }
}
