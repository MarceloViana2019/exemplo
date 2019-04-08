using System;

namespace ExemploArquitetura.Domain.Entities
{
    public class Service : Entity
    {
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }
        public string Type { get; private set; }
        public virtual Customer Customer { get; private set; }
        public virtual Provider Provider { get; private set; }
        public virtual ServiceAddress ServiceAddress { get; private set; }

        protected Service()
        { }

        public Service(string description, DateTime date, decimal value, string type, Customer customer, Provider provider, ServiceAddress serviceAddress)
        {
            Description = description;
            Date = date;
            Value = value;
            Type = type;
            Customer = customer;
            Provider = provider;
            ServiceAddress = serviceAddress;
        }

        public void Update(string description, DateTime date, decimal value, string type)
        {
            Description = description;
            Date = date;
            Value = value;
            Type = type;
        }
    }
}