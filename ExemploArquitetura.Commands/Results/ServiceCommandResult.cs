using ExemploArquitetura.Commands.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploArquitetura.Commands.Results
{
    public class ServiceCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Data Atendimento")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [DisplayName("Valor")]
        public decimal Value { get; set; }
        [DisplayName("Tipo")]
        public string Type { get; set; }
        [DisplayName("Cliente")]
        public string CustomerName { get; set; }
        [DisplayName("Bairro")]
        public string Street { get; set; }
        [DisplayName("Cidade")]
        public string City { get; set; }
        [DisplayName("Estado")]
        public string State { get; set; }
    }
}
