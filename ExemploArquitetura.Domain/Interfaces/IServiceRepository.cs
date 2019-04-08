using ExemploArquitetura.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Interfaces
{
    public interface IServiceRepository
    {
        void Save(Service service);
        void Update(Service service);
        IEnumerable<Service> GetAll();
        IEnumerable<Service> GetFilter(string sortOrder, string searchString);
        IEnumerable<Service> GetReport(DateTime dateStart, DateTime dateEnd);
        Service Get(Guid id);
    }
}
