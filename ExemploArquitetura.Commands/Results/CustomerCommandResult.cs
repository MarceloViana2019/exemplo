using ExemploArquitetura.Commands.Interfaces;
using System;
using System.ComponentModel;

namespace ExemploArquitetura.Commands.Results
{
    public class CustomerCommandResult : ICommandResult
    {
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        public CustomerCommandResult()
        { }

        public CustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
