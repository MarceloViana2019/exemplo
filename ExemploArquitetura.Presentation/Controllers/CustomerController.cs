using ExemploArquitetura.AppService.Entities;
using ExemploArquitetura.Commands.Inputs;
using System;
using System.Web.Mvc;

namespace ExemploArquitetura.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AddressAppService _addressAppService;
        private readonly CustomerAppService _customerAppService;

        public CustomerController(AddressAppService addressAppService, CustomerAppService customerAppService)
        {
            _addressAppService = addressAppService;
            _customerAppService = customerAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_customerAppService.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.States = _addressAppService.GetStates();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerRegisterCommand command)
        {
            try
            {
                _customerAppService.Save(command);


                return View("Index", _customerAppService.GetAll());
            }
            
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var command = _customerAppService.Get(id);
            ViewBag.States = _addressAppService.GetStates();
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Edit(CustomerRegisterCommand command)
        {
            try
            {
                _customerAppService.Update(command);
                return RedirectToAction("Index", _customerAppService.GetAll());
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