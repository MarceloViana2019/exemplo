using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploArquitetura.Commands.Inputs
{
    public class ServiceRegisterCommand
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Valor")]
        public decimal Value { get; set; }
        [Required]
        [DisplayName("Tipo")]
        public string Type { get; set; }

        public Guid CustomerId { get; set; }
        public Guid ProviderId { get; set; }

        public AddressRegisterCommand Address { get; set; }

        public ServiceRegisterCommand()
        { }

        public ServiceRegisterCommand(Guid id, string description, DateTime date, decimal value, string type, Guid customerId, Guid providerId, AddressRegisterCommand address)
        {
            Id = id;
            Description = description;
            Date = date;
            Value = value;
            Type = type;
            CustomerId = customerId;
            ProviderId = providerId;
            Address = address;
        }
    }
}
