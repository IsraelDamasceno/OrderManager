using OrderManager.Domain;
using OrderManager.Domain.Dtos;
using OrderManager.Interface.Repositories;
using System;
using System.Linq;

namespace OrderManager.Repository
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {

        }
        public string Create(CityDTO model)
        {
            var duplicateName = _context.Cities.Any(x => x.Active && x.Name.ToLower() == model.Name.ToLower() && x.UF.ToLower() == model.Uf.ToLower());
            if (duplicateName)
            {
                return "Duplicate name in the database";
            }

            var entity = new City()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                UF = model.Uf,
                Active = model.Active
            };

            try
            {
                _context.Cities.Add(entity);
                _context.SaveChanges();

                return entity.Name;
            }
            catch (Exception ex)
            {
                return ex.Message.ToLower();
            }

            return "An unexpected error has happened";
        }

        public dynamic Get()
        {
            var list = _context.Cities
                .Where(x => x.Active)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Uf = x.UF,
                    Active = x.Active
                })
                .OrderBy(x => x.Name)
                .ToList();

            return list;
        }

        public bool Remove(Guid id)
        {
            var entity = _context.Cities.Find(id);
            if (entity == null)
            {
                return false;
            }

            try
            {
                _context.Cities.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public string Replace(CityDTO model)
        {
            var entity = _context.Cities.Find(model.Id);
            if (entity == null)
            {
                return "City not found";
            }

            var duplicateName = _context.Cities.Any(x => x.Active && x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
            if (duplicateName)
            {
                return "Duplicate name in the database";
            }

            entity.Name = model.Name;
            entity.UF = model.Uf;
            entity.Active = model.Active;

            try
            {
                _context.Cities.Update(entity);
                _context.SaveChanges();

                return entity.Name;
            }
            catch (Exception ex)
            {
                ex.Message.ToLower();
            }

            return "An unexpected error has happened";
        }
    }
}
