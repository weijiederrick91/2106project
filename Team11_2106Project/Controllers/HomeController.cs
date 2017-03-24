using System.Linq;
using System.Web.Mvc;
using Team11_2106Project.Models;
using Team11_2106Project.TableModule;

namespace Team11_2106Project.Controllers
{
    public class HomeController : Controller
    {
        internal HomeTM HomeTM = new HomeTM();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Voter model)
        {
            ViewBag.Sadness = ":(";

            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {

                if (HomeTM.ValidateLogin(model.Email, model.Password))
                {
                    TempData["ResultMessage"] = "True";

                    TempData["NoMoreLogin"] = "NoMore";
                    return RedirectToAction("Index", "CandidateProfiles");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            return View(model);
        }
    }
}
