
using Team11_2106Project.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Team11_2106Project.DomainModel;

namespace Team11_2106Project.Controllers
{
    public class AccountController : Controller
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

            if (model.StudentRole == StudentRole.Admin)
            {
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
            else if (model.StudentRole == StudentRole.Candidate)
            {
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

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
            //var data = new Data();
            //var users = data.getUsers();

            ////Select the user and check if the name and password is the same and then check if the role that we select is the same.
            //if (users.Any(p => p.user == model.UserName && p.password == model.Password && p.ourRoles == model.StudentRole && model.StudentRole == StudentRole.Admin))
            //{   

            //    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

            //    Authentication.SignIn(new AuthenticationProperties
            //    {
            //        IsPersistent = model.RememberMe
            //    }, identity);

            //    return RedirectToAction("Admin", "Home");
            //}
            //else if (users.Any(p => p.user == model.UserName && p.password == model.Password && p.ourRoles == model.StudentRole && model.StudentRole == StudentRole.Candidate))
            //{   

            //    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

            //    Authentication.SignIn(new AuthenticationProperties
            //    {
            //        IsPersistent = model.RememberMe
            //    }, identity);

            //    return RedirectToAction("Index", "Home");
            //}
            //if (users.Any(p => p.user == model.UserName && p.password == model.Password && p.ourRoles == model.StudentRole && model.StudentRole == StudentRole.Voter))
            //{

            //    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

            //    Authentication.SignIn(new AuthenticationProperties
            //    {
            //        IsPersistent = model.RememberMe
            //    }, identity);

            //    return RedirectToAction("Voter", "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Invalid login attempt.");
            //    return View(model);
            //}
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}