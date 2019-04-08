using System;
using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            return entity != null &&
                   Id.Equals(entity.Id);
        }
        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}
