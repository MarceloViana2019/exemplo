using ExemploArquitetura.Commands.Inputs;
using ExemploArquitetura.Commands.Results;
using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploArquitetura.AppService.Entities
{
    public class CustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CustomerAppService(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public void Save(CustomerRegisterCommand command)
        {
            var customer = new Customer(command.Name
                                      , new Address(command.Address.Street
                                                  , _addressRepository.GetCity(command.Address.CityCode)));

            _customerRepository.Save(customer);
        }
        public void Update(CustomerRegisterCommand command)
        {
            var customer = _customerRepository.Get(command.Id);
            var city = _addressRepository.GetCity(command.Address.CityCode);

            customer.Address.Update(command.Address.Street, city);
            customer.Update(command.Name);

            _customerRepository.Update(customer);
        }
        public IEnumerable<CustomerCommandResult> GetAll()
        {
            return _customerRepository.GetAll().Select(customer => new CustomerCommandResult()
            {
                Id = customer.Id,
                Name = customer.Name
            });
        }
        public CustomerRegisterCommand Get(Guid id)
        {
            var customer = _customerRepository.Get(id);

            return new CustomerRegisterCommand(customer.Id
                                             , customer.Name
                                             , new AddressRegisterCommand(customer.Address.Street
                                                                        , customer.Address.City.StateCode
                                                                        , customer.Address.City.Code));
        }
    }
}
