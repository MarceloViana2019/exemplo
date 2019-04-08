using ExemploArquitetura.AppService.Entities;
using System.Web.Mvc;

namespace ExemploArquitetura.Presentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly AddressAppService _addressAppService;

        public AddressController(AddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        [HttpPost]
        public ActionResult GetCities(int stateCode)
        {
            return Json(_addressAppService.GetCities(stateCode));
        }
    }
}