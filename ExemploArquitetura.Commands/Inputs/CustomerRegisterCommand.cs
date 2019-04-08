using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Inputs
{
    public class CustomerRegisterCommand
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        public AddressRegisterCommand Address { get; set; }


        public CustomerRegisterCommand()
        { }

        public CustomerRegisterCommand(Guid id, string name, AddressRegisterCommand address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
