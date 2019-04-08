
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace ExemploArquitetura.Presentation.Models
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }

        //
    }
}