using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using System.Security.Claims;
using Team11_2106Project.ViewModel;
using System.Web;
using Team11_2106Project.DomainModel;


namespace Team11_2106Project.Controllers
{
    public class HomeController : Controller
    {

        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if user selects Admin role
            if (model.StudentRole == StudentRole.Admin)
            {

                // check username and password in Admin table in DB
                ILogIn<Admin> iLogInAdmin = new Admin();
                if (iLogInAdmin.Login(model.UserName, model.Password))
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);

                    return RedirectToAction("Admin", "Home");
                }
            }

            // Check if user selects Candidate role
            else if (model.StudentRole == StudentRole.Candidate)
            {

                // check username and password in Candidate table in DB
                ILogIn<Candidate> iLogInAdmin = new Candidate();
                if (iLogInAdmin.Login(model.UserName, model.Password))
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);

                    return RedirectToAction("Index", "Home");
                }
            }

            // Check if user selects Voter role
            else if (model.StudentRole == StudentRole.Voter)
            {

                // check username and password in Voter table in DB
                ILogIn<Voter> iLogInAdmin = new Voter();
                if (iLogInAdmin.Login(model.UserName, model.Password))
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);

                    return RedirectToAction("Voter", "Home");
                }
            }

            // eror message if user key in wrong username and password for all StudentRoles
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Authentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return View();
            else
                //redirection to the action of login in the AccountController
                return RedirectToAction("Login", "Home");
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

