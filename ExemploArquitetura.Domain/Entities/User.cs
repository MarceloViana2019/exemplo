
using System;

namespace ExemploArquitetura.Domain.Entities
{
    public class User : Entity
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Claim { get; private set; }

        protected User()
        { }

        public User(string login, string password, string claim)
        {
            Login = login;
            Password = password;
            Claim = claim;
        }

        public bool Autenticar(string login, string password)
        {
            return Login == login && Password == password;
        }

    }
}