using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploArquitetura.Commands.Inputs
{
    public class ReportServiceFilterCommand
    {

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("De")]
        public DateTime DateStart { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Até")]
        public DateTime DateEnd { get; set; }

        //public Guid CustomerId { get; set; }

        //public AddressRegisterCommand Address { get; set; }

        public ReportServiceFilterCommand()
        { }

        public ReportServiceFilterCommand(DateTime dateStart, DateTime dateEnd)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
        }
    }
}
