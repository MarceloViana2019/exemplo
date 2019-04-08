using System.Collections.Generic;

namespace ExemploArquitetura.Domain.Entities
{
    public class State
    {
        public int Code { get; private set; }
        public string Initials { get; private set; }
        public string Name { get; private set; }

        protected State()
        { }

        public State(int code, string initials, string name)
        {
            Code = code;
            Initials = initials;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var state = obj as State;
            return state != null &&
                   Code == state.Code &&
                   Initials == state.Initials &&
                   Name == state.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 903596202;
            hashCode = hashCode * -1521134295 + Code.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Initials);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
