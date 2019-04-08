using ExemploArquitetura.Commands.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExemploArquitetura.Commands.Results
{
    public class StateCommandResult : ICommandResult
    {
        public int Code { get; set; }
        public string Initials { get; set; }

        [Required]
        public string Name { get; set; }

        public StateCommandResult()
        {

        }

        public StateCommandResult(int code, string initials, string name)
        {
            Code = code;
            Initials = initials;
            Name = name;
        }
    }
}
