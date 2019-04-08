using System;

namespace ExemploArquitetura.Domain.Entities
{
    public class Provider : Entity
    {
        public string Name { get; private set; }

        public Provider(string name)
        {
            Name = name;
        }

        protected Provider()
        { }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
