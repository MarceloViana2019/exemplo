using ExemploArquitetura.Commands.Results;
using ExemploArquitetura.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ExemploArquitetura.AppService.Entities
{
    public class AddressAppService
    {
        private readonly IAddressRepository _repoistory;

        public AddressAppService(IAddressRepository repoistory)
        {
            _repoistory = repoistory;
        }

        public IEnumerable<CityCommandResult> GetCities(int stateCode)
        {
            return _repoistory.GetCities(stateCode).Select(city => new CityCommandResult()
            {
                Code = city.Code,
                Name = city.Name,
                StateCode = city.StateCode
            });
        }
        public IEnumerable<StateCommandResult> GetStates()
        {
            return _repoistory.GetStates().Select(state => new StateCommandResult()
            {
                Code = state.Code,
                Initials = state.Initials,
                Name = state.Name
            });
        }
    }
}
