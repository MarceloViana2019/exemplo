using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Inputs
{
    public class ProviderRegisterCommand
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        public ProviderRegisterCommand()
        { }

        public ProviderRegisterCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
