using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using System.Security.Claims;
using Team11_2106Project.ViewModel;
using System.Web;


namespace Team11_2106Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return View();
            else
                //redirection to the action of login in the AccountController
                return RedirectToAction("Login", "Account");
        }

        public ActionResult Admin()
        {
            if (Request.IsAuthenticated)
                return View();
            else
                //redirection to the action of login in the AccountController
                return RedirectToAction("Admin", "Home");
        }
        public ActionResult Voter()
        {
            if (Request.IsAuthenticated)
                return View();
            else
                //redirection to the action of login in the AccountController
                return RedirectToAction("Voter", "Home");
        }

    }
}

