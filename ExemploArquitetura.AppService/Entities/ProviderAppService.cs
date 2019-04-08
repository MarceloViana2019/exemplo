using ExemploArquitetura.Commands.Inputs;
using ExemploArquitetura.Commands.Results;
using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Domain.Interfaces;
using ExemploArquitetura.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ExemploArquitetura.AppService.Entities
{
    public class ProviderAppService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly ExampleContext _context;

        public ProviderAppService(IAddressRepository addressRepository
            , IProviderRepository providerRepository
            , ExampleContext context)
        {
            _addressRepository = addressRepository;
            _providerRepository = providerRepository;
            _context = context;
        }

        public void Save(ProviderRegisterCommand command)
        {
            var provider = new Provider(command.Name);

            _providerRepository.Save(provider);
        }
        public void Update(ProviderRegisterCommand command)
        {
            var provider = _providerRepository.Get(command.Id);
            provider.Update(command.Name);

            _providerRepository.Update(provider);
        }
        public IEnumerable<ProviderCommandResult> GetAll()
        {
            return _providerRepository.GetAll().Select(provider => new ProviderCommandResult()
            {
                Id = provider.Id,
                Name = provider.Name
            });
        }
        
        public ProviderRegisterCommand Get(Guid id)
        {
            var provider = _providerRepository.Get(id);

            return new ProviderRegisterCommand(provider.Id
                                             , provider.Name);
        }
    }
}
