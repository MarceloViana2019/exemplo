using ExemploArquitetura.Commands.Interfaces;
using System;
using System.ComponentModel;

namespace ExemploArquitetura.Commands.Results
{
    public class ProviderCommandResult : ICommandResult
    {
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        public ProviderCommandResult()
        { }

        public ProviderCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
