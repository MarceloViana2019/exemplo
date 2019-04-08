using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Entities
{
    public class City
    {
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int StateCode { get; private set; }
        public virtual State State { get; private set; }

        protected City()
        { }

        public City(int code, string name, State state)
        {
            Code = code;
            Name = name;
            State = state;
        }

        public override bool Equals(object obj)
        {
            var city = obj as City;
            return city != null &&
                   Code == city.Code &&
                   Name == city.Name &&
                   EqualityComparer<State>.Default.Equals(State, city.State);
        }
        public override int GetHashCode()
        {
            var hashCode = 1333846752;
            hashCode = hashCode * -1521134295 + Code.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<State>.Default.GetHashCode(State);
            return hashCode;
        }
    }
}
