using ExemploArquitetura.AppService.Entities;
using System.Web.Mvc;

namespace ExemploArquitetura.Presentation.Controllers
{
    public class ServiceAddressController : Controller
    {
        private readonly ServiceAddressAppService _serviceAddressAppService;

        public ServiceAddressController(ServiceAddressAppService serviceAddressAppService)
        {
            _serviceAddressAppService = serviceAddressAppService;
        }

        [HttpPost]
        public ActionResult GetCities(int stateCode)
        {
            return Json(_serviceAddressAppService.GetCities(stateCode));
        }
    }
}