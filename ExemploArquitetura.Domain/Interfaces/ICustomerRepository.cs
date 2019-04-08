using ExemploArquitetura.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        void Update(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer Get(Guid id);
    }
}
