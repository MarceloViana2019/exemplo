using ExemploArquitetura.Domain.Entities;
using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Interfaces
{
    public interface IServiceAddressRepository
    {
        IEnumerable<State> GetStates();
        IEnumerable<City> GetCities(int stateCode);
        City GetCity(int code);
        State GetState(int code);
    }
}
