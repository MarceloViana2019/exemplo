using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Domain.Interfaces;
using ExemploArquitetura.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploArquitetura.Infra.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ExampleContext _context;

        public ServiceRepository(ExampleContext context)
        {
            _context = context;
        }

        public Service Get(Guid id)
        {
            return _context.Services.Find(id);
        }
        public IEnumerable<Service> GetAll()
        {
            return _context.Services.ToList();
        }
        public IEnumerable<Service> GetFilter(string sortOrder, string searchString)
        {
            return _context.Services.ToList();
        }
        public IEnumerable<Service> GetReport(DateTime dateStart, DateTime dateEnd)
        {
            return _context.Services.Where(x => x.Date >= dateStart && x.Date <= dateEnd).ToList();
        }
        public void Save(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }
        public void Update(Service service)
        {
            _context.Entry(service).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
