namespace ExemploArquitetura.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public virtual Address Address { get; private set; }

        protected Customer()
        { }

        public Customer(string name, Address address)
        {
            Update(name);
            Address = address;
        }

        public void Update(string name)
        {
            Name = name;
        }

    }
}
