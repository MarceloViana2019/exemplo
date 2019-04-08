using ExemploArquitetura.Commands.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Results
{
    public class AddressCommandResult : ICommandResult
    {
        [Required]
        public string Street { get;  set; }
        [Required]
        public string Number { get;  set; }
        [Required]
        public string ZipCode { get;  set; }
        public CityCommandResult City { get; set; }
    }
}
