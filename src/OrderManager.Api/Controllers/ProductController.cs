using Microsoft.AspNetCore.Mvc;
using OrderManager.Domain;
using OrderManager.Domain.Dtos;
using OrderManager.Interface.Repositories;
using System;
using System.Collections.Generic;

namespace OrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : AppBaseController
    {
        public CityController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        public dynamic Get()
        {
            //TODO: TASK - ACTION
            //TODO: fazer um  try e tratamento caso de erro
            var _repo = (ICityRepository)_serviceProvider.GetService(typeof(ICityRepository));
            return _repo.Get();
        }

        [HttpPost]
        public string Create(CityDTO model)
        {
            //TODO: TASK - ACTION
            //TODO: Validação para nome do produto.
            //TODO: fazer um  try e tratamento caso de erro
            var _repo = (ICityRepository)_serviceProvider.GetService(typeof(ICityRepository));
            return _repo.Create(model);
        }


        [HttpPut]
        public string Replace(CityDTO model)
        {
            var _repo = (ICityRepository)_serviceProvider.GetService(typeof(ICityRepository));
            return _repo.Replace(model);
        }
        [HttpDelete]
        [Route("{id}")]
        public bool Excluir(Guid id)
        {
            var _repo = (ICityRepository)_serviceProvider.GetService(typeof(ICityRepository));
            return _repo.Remove(id);
        }

    }
}
