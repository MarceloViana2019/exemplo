using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Domain.Interfaces;
using ExemploArquitetura.Infra.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ExemploArquitetura.Infra.Repositories
{
    public class ServiceAddressRepository : IServiceAddressRepository
    {
        private readonly ExampleContext _context;

        public ServiceAddressRepository(ExampleContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities(int stateCode)
        {
            return _context.Cities.Where(x => x.State.Code == stateCode).ToList();
        }
        public City GetCity(int code)
        {
            return _context.Cities.Find(code);
        }
        public State GetState(int code)
        {
            return _context.States.Find(code);
        }
        public IEnumerable<State> GetStates()
        {
            return _context.States.ToList();
        }
    }
}
