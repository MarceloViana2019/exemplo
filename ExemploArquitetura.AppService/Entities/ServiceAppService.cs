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
    public class ServiceAppService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProviderRepository _providerRepository;

        public ServiceAppService(IServiceRepository serviceRepository, IAddressRepository addressRepository, ICustomerRepository customerRepository, IProviderRepository providerRepository)
        {
            _serviceRepository = serviceRepository;
            _addressRepository = addressRepository;
            _customerRepository = customerRepository;
            _providerRepository = providerRepository;
        }

        public void Save(ServiceRegisterCommand command)
        {
            var service = new Service(command.Description
                                     , command.Date
                                     , command.Value
                                     , command.Type
                                     , _customerRepository.Get(command.CustomerId)
                                     , _providerRepository.Get(command.ProviderId)
                                     , new ServiceAddress(command.Address.Street
                                                  , _addressRepository.GetCity(command.Address.CityCode)));

            _serviceRepository.Save(service);
        }

        public void Update(ServiceRegisterCommand command)
        {
            var service = _serviceRepository.Get(command.Id);
            var city = _addressRepository.GetCity(command.Address.CityCode);

            service.ServiceAddress.Update(command.Address.Street, city);
            service.Update(command.Description, command.Date, command.Value, command.Type);

            _serviceRepository.Update(service);
        }

        public IEnumerable<ServiceCommandResult> GetAll()
        {
            return _serviceRepository.GetAll().Select(service => new ServiceCommandResult()
            {
                Id = service.Id,
                Description = service.Description,
                Date = service.Date.ToString("yyyyMMdd"),
                Value = service.Value,
                Type = service.Type,
                CustomerName = service.Customer.Name,
                Street = service.ServiceAddress.Street,
                City = service.ServiceAddress.City.Name,
                State = service.ServiceAddress.City.State.Name
            });
        }

        public IEnumerable<ServiceCommandResult> GetReport(DateTime dateStart, DateTime dateEnd)
        {
            return _serviceRepository.GetReport(dateStart, dateEnd).Select(service => new ServiceCommandResult()
            {
                Id = service.Id,
                Description = service.Description,
                Date = service.Date.ToString("dd/MM/yyyy"),
                Value = service.Value,
                Type = service.Type,
                CustomerName = service.Customer.Name,
                Street = service.ServiceAddress.Street,
                City = service.ServiceAddress.City.Name,
                State = service.ServiceAddress.City.State.Name
            });
        }

        public IEnumerable<ServiceCommandResult> GetFilter(string sortOrder, string searchString)
        {
            var services = _serviceRepository.GetAll().Select(service => new ServiceCommandResult()
            {
                Id = service.Id,
                Description = service.Description,
                Date = service.Date.ToString("dd/MM/yyyy"),
                Value = service.Value,
                Type = service.Type,
                CustomerName = service.Customer.Name,
                Street = service.ServiceAddress.Street,
                City = service.ServiceAddress.City.Name,
                State = service.ServiceAddress.City.State.Name
            });

            if (!String.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Description.Contains(searchString)
                                       || s.Date.Contains(searchString)
                                       || s.Type.Contains(searchString)
                                       || s.Street.Contains(searchString)
                                       || s.City.Contains(searchString)
                                       || s.CustomerName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    services = services.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    services = services.OrderByDescending(s => s.Date);
                    break;
                default:
                    services = services.OrderBy(s => s.CustomerName);
                    break;
            }

            return (services);
        }

        public ServiceRegisterCommand Get(Guid id)
        {
            var service = _serviceRepository.Get(id);

            return new ServiceRegisterCommand(service.Id
                                             , service.Description
                                             , service.Date
                                             , service.Value
                                             , service.Type
                                             , service.Customer.Id
                                             , service.Provider.Id
                                             , new AddressRegisterCommand(service.ServiceAddress.Street
                                                                        , service.ServiceAddress.City.StateCode
                                                                        , service.ServiceAddress.City.Code));
        }

    }
}
