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
        [HttpGet]
        public dynamic Get([FromQuery] string order = "")
        {
            //TODO: TASK - ACTION
            //TODO: fazer um  try e tratamento caso de erro
            var _repo = (IProductRepository)_serviceProvider.GetService(typeof(IProductRepository));
            return _repo.Get(order);
        }

        [HttpGet]
        [Route("search/{text}/{pagina?}")]
        public dynamic GetSearch(string text, int pagina = 1, [FromQuery] string order = "")
        {
            //TODO: TASK - ACTION
            //TODO: Validação para nome do produto.
            //TODO: fazer um  try e tratamento caso de erro
            var _repo = (IProductRepository)_serviceProvider.GetService(typeof(IProductRepository));
            return _repo.Search(text, pagina, order);
        }

        
        [HttpGet]
        [Route("{id}")]
        public dynamic Detail(Guid id)
        {
            var _repo = (IProductRepository)_serviceProvider.GetService(typeof(IProductRepository));
            return _repo.Detail(id);
        }

    }
}
