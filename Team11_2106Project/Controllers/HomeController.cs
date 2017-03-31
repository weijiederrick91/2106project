using System.Web.Mvc;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VoterViewModel model)
        {
            return View();
        }
    }
}
