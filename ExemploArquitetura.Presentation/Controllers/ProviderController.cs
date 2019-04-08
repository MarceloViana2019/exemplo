using ExemploArquitetura.AppService.Entities;
using ExemploArquitetura.Commands.Inputs;
using System;
using System.Web.Mvc;

namespace ExemploArquitetura.Presentation.Controllers
{
    public class ProviderController : Controller
    {
        private readonly AddressAppService _addressAppService;
        private readonly ProviderAppService _providerAppService;

        public ProviderController(AddressAppService addressAppService, ProviderAppService providerAppService)
        {
            _addressAppService = addressAppService;
            _providerAppService = providerAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_providerAppService.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProviderRegisterCommand command)
        {
            try
            {
                _providerAppService.Save(command);
                return View("Index", _providerAppService.GetAll());
            }

            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var command = _providerAppService.Get(id);
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Edit(ProviderRegisterCommand command)
        {
            try
            {
                _providerAppService.Update(command);
                return RedirectToAction("Index", _providerAppService.GetAll());
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}