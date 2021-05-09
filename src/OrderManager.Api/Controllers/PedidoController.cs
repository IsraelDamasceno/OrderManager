using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace OrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : AppBaseController
    {
        public PedidoController(IServiceProvider serviceProvider): base(serviceProvider)
        {          
        }
        [HttpGet("Nomes")]
        public IEnumerable<string> ListarNomes()
        {
            var nomes = new List<string>();
            nomes.Add("Luiza");
            nomes.Add("Israel");
            nomes.Add("Elaine");
            nomes.Add("Romario");
            return nomes;
        }
    }
}
