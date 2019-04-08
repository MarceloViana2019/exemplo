using ExemploArquitetura.AppService.Entities;
using ExemploArquitetura.Commands.Inputs;
using System;
using System.Web.Mvc;

namespace ExemploArquitetura.Presentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AddressAppService _addressAppService;
        private readonly ServiceAppService _serviceAppService;
        private readonly CustomerAppService _customerAppService;
        private readonly ProviderAppService _providerAppService;

        public ServiceController(AddressAppService addressAppService
            , ServiceAppService serviceAppService
            , CustomerAppService customerAppService
            , ProviderAppService providerAppService)
        {
            _addressAppService = addressAppService;
            _serviceAppService = serviceAppService;
            _customerAppService = customerAppService;
            _providerAppService = providerAppService;
        }

        public ViewResult Index(string sortOrder, string searchString)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var services = _serviceAppService.GetFilter(sortOrder, searchString);

            return View(services);
        }

        //public ActionResult Index(string sortOrder)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

        //    var services = _serviceAppService.GetFilter(sortOrder);

        //    return View(services);
        //}

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.States = _addressAppService.GetStates();
            ViewBag.Customers = _customerAppService.GetAll();
            ViewBag.Providers = _providerAppService.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Report()
        {
            ViewBag.States = _addressAppService.GetStates();
            ViewBag.Customers = _customerAppService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Report(ReportServiceFilterCommand command)
        {
            try
            {
                //return View("ReportResult", _serviceAppService.GetReport(command.DateStart, command.DateEnd));
                return RedirectToAction("Index", _serviceAppService.GetReport(command.DateStart, command.DateEnd));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(ServiceRegisterCommand command)
        {
            try
            {
                _serviceAppService.Save(command);
                return RedirectToAction("Index", _serviceAppService.GetAll());
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var command = _serviceAppService.Get(id);
            ViewBag.States = _addressAppService.GetStates();
            ViewBag.Customers = _customerAppService.GetAll();
            ViewBag.Providers = _providerAppService.GetAll();
            return View("Create", command);
        }

        [HttpPost]
        public ActionResult Edit(ServiceRegisterCommand command)
        {
            try
            {
                _serviceAppService.Update(command);
                return RedirectToAction("Index", _serviceAppService.GetAll());
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