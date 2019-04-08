using ExemploArquitetura.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Interfaces
{
    public interface IProviderRepository
    {
        void Save(Provider customer);
        void Update(Provider customer);
        IEnumerable<Provider> GetAll();
        Provider Get(Guid id);
    }
}
