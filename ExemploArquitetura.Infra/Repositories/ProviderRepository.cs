using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Domain.Interfaces;
using ExemploArquitetura.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploArquitetura.Infra.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ExampleContext _context;

        public ProviderRepository(ExampleContext context)
        {
            _context = context;
        }

        public Provider Get(Guid id)
        {
            return _context.Providers.Find(id);
        }
        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers.ToList();
        }
        public void Save(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }
        public void Update(Provider provider)
        {
            _context.Entry(provider).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
