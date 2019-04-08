using ExemploArquitetura.AppService.Entities;
using ExemploArquitetura.Commands.Inputs;
using ExemploArquitetura.Presentation.Models;
using System;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;
using ExemploArquitetura.Commands.Results;

namespace ExemploArquitetura.Presentation.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private readonly ProviderAppService _providerAppService;
        private readonly CustomerAppService _customerAppService;
        private readonly ServiceAppService _serviceAppService;

        public HomeController(ProviderAppService providerAppService
                            , CustomerAppService customerAppService
                            , ServiceAppService serviceAppService)
        {
            _providerAppService = providerAppService;
            _customerAppService = customerAppService;
            _serviceAppService = serviceAppService;
        }

        // GET: Account
        public ActionResult Index()
        {
            var command = new MonitorCommandResult
            {
                Customers = _customerAppService.GetAll(),
                Providers = _providerAppService.GetAll(),
                Services = _serviceAppService.GetAll()
            };

            return View(command);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model.Login == "admin" && model.Password == "1234")
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Email, "admin@email.com"),
                    new Claim(ClaimTypes.Country, "Brasil")
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Usuário ou senha inválidos");
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

    }
}