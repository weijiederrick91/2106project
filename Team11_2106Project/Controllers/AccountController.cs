
using Team11_2106Project.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

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
            var data = new Data();
            var users = data.getUsers();
            
            //Select the user and check if the name and password is the same and then check if the role that we select is the same.
            if (users.Any(p => p.user == model.UserName && p.password == model.Password && p.ourRoles == model.StudentGender && model.StudentGender == Gender.Admin))
            {   
        
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);

                return RedirectToAction("Admin", "Home");
            }
            else if (users.Any(p => p.user == model.UserName && p.password == model.Password && p.ourRoles == model.StudentGender && model.StudentGender == Gender.Candidate))
            {   
        
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
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