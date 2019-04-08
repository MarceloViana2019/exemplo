using ExemploArquitetura.AppService.Entities;
using ExemploArquitetura.Domain.Interfaces;
using ExemploArquitetura.Infra.Contexts;
using ExemploArquitetura.Infra.Repositories;
using SimpleInjector;

namespace ExemploArquitetura.CrossCutting.Dependency
{
    public static class DependencyRegister
    {

        public static void Register(Container container)
        {
            container.Register<ExampleContext, ExampleContext>(Lifestyle.Singleton);

            container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Scoped);
            container.Register<IAddressRepository, AddressRepository>(Lifestyle.Scoped);
            container.Register<IServiceRepository, ServiceRepository>(Lifestyle.Scoped);
            container.Register<IProviderRepository, ProviderRepository>(Lifestyle.Scoped);
            container.Register<IServiceAddressRepository, ServiceAddressRepository>(Lifestyle.Scoped);

            container.Register<AddressAppService, AddressAppService>(Lifestyle.Scoped);
            container.Register<CustomerAppService, CustomerAppService>(Lifestyle.Scoped);
            container.Register<ServiceAppService, ServiceAppService>(Lifestyle.Scoped);
            container.Register<ProviderAppService, ProviderAppService>(Lifestyle.Scoped);
            container.Register<ServiceAddressAppService, ServiceAddressAppService>(Lifestyle.Scoped);

        }
    }
}
