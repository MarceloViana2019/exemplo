using ExemploArquitetura.Commands.Results;
using ExemploArquitetura.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ExemploArquitetura.AppService.Entities
{
    public class ServiceAddressAppService
    {
        private readonly IServiceAddressRepository _repository;

        public ServiceAddressAppService(IServiceAddressRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CityCommandResult> GetCities(int stateCode)
        {
            return _repository.GetCities(stateCode).Select(city => new CityCommandResult()
            {
                Code = city.Code,
                Name = city.Name,
                StateCode = city.StateCode
            });
        }
        public IEnumerable<StateCommandResult> GetStates()
        {
            return _repository.GetStates().Select(state => new StateCommandResult()
            {
                Code = state.Code,
                Initials = state.Initials,
                Name = state.Name
            });
        }
    }
}
