using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Domain.Interfaces;
using ExemploArquitetura.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploArquitetura.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ExampleContext _context;

        public CustomerRepository(ExampleContext context)
        {
            _context = context;
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Find(id);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void Update(Customer customer)
        {
            _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
