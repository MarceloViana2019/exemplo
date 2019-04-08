using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Inputs
{
    public class AddressRegisterCommand
    {
        [Required]
        [DisplayName("Bairro")]
        public string Street { get; set; }
        [Required]
        [DisplayName("Estado")]
        public int StateCode { get; set; }
        [Required]
        [DisplayName("Cidade")]
        public int CityCode { get; set; }

        public AddressRegisterCommand()
        { }

        public AddressRegisterCommand(string street, int stateCode, int cityCode)
        {
            Street = street;
            StateCode = stateCode;
            CityCode = cityCode;
        }
    }
}
