namespace ExemploArquitetura.Domain.Entities
{
    public class ServiceAddress : Entity
    {
        public string Street { get; private set; }
        public virtual City City { get; private set; }

        protected ServiceAddress()
        { }
        public ServiceAddress(string street, City city)
        {
            Update(street, city);
        }

        public void Update(string street, City city)
        {
            Street = street;
            City = city;
        }
    }
}
