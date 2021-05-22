using System;

namespace OrderManager.Domain.Dtos
{
    public class CityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
        public bool Active { get; set; }
    }
}
