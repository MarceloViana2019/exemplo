using ExemploArquitetura.Commands.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Results
{
    public class CityCommandResult : ICommandResult
    {
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int StateCode { get; set; }


        public CityCommandResult()
        { }
        public CityCommandResult(int code, string name, int state)
        {
            Code = code;
            Name = name;
            StateCode = state;
        }
    }
}
