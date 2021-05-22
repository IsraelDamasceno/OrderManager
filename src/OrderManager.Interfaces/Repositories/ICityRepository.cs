using OrderManager.Domain.Dtos;
using System;

namespace OrderManager.Interface.Repositories
{
    public interface ICityRepository
    {

        dynamic Get();
        string Create(CityDTO model);
        string Replace(CityDTO model);
        bool Remove(Guid id);
    }
}
