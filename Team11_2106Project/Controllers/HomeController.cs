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

        private ICandidateProfile iCandidateProfile = new CandidateProfile();
        private IViewResults iViewResults = new Candidate();
        private IVote iVote;

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

                    TempData["StudentRole"] = "Admin";
                    TempData["AdminID"] = iLogInAdmin.getID();

                    return RedirectToAction("Index", "Home");
                }
            }

            // Check if user selects Candidate role
            else if (model.StudentRole == StudentRole.Candidate)
            {

                // check username and password in Candidate table in DB
                ILogIn<Candidate> iLogInCandidate = new Candidate();
                if (iLogInCandidate.Login(model.UserName, model.Password))
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);

                    TempData["StudentRole"] = "Candidate";
                    TempData["CandidateID"] = iLogInCandidate.getID();

                    return RedirectToAction("Index", "Home");
                }
            }

            // Check if user selects Voter role
            else if (model.StudentRole == StudentRole.Voter)
            {

                // check username and password in Voter table in DB
                ILogIn<Voter> iLogInVoter = new Voter();
                if (iLogInVoter.Login(model.UserName, model.Password))
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);

                    TempData["StudentRole"] = "Voter";
                    TempData["VoterID"] = iLogInVoter.getID();

                    return RedirectToAction("Index", "Home");
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
 
            // Clear temp data
            TempData.Remove("StudentRole");
            TempData.Remove("VoterID");
            TempData.Remove("AdminID");
            TempData.Remove("CandidateID");

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Index()
        {
            if (Authentication.User.Identity.IsAuthenticated)
            {

                // Determine what role is the Student
                if (TempData.ContainsKey("StudentRole"))
                {
                    string studentRole = TempData["StudentRole"].ToString();

                    if (studentRole.Equals("Candidate"))
                    {
                        iVote = new Candidate();
                    }
                    else if (studentRole.Equals("Voter"))
                    {
                        iVote = new Voter();
                    }
                    else if (studentRole.Equals("Admin"))
                    {
                        iVote = new Admin();
                    }
                    TempData["StudentRole"] = studentRole;

                    // if current user has voted, send them to the results page
                    if (iVote.hasCurrentUserVoted())
                    {
                        return RedirectToAction("Stats", "Home");
                    }
                }
                // allow them to see all the candidates to vote
                return View(iCandidateProfile.ViewAllProfiles());
            }
                
            else
                //redirection to the action of login in the AccountController
                return RedirectToAction("Login", "Home");
        }

        /**
         * Allows the Student to select their Candidate to vote and view their profiles
         */ 
        public ActionResult Vote(int id)
        {
            CandidateProfileViewModel candidateProfile = iCandidateProfile.ViewProfile(id);
            if (candidateProfile == null)
            {
                return HttpNotFound();
            }
            return View(candidateProfile);
        }

        /**
         * Alows the Student to place their vote on a Candidate after confirmation
         */ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(Candidate candidate)
        {

            // Determine what role is the Student
            if (TempData.ContainsKey("StudentRole"))
            {
                string studentRole = TempData["StudentRole"].ToString();

                if (studentRole.Equals("Candidate"))
                {
                    iVote = new Candidate();
                }
                else if (studentRole.Equals("Voter"))
                {
                    iVote = new Voter();
                }
                else if (studentRole.Equals("Admin"))
                {
                    iVote = new Admin();
                }
                TempData["StudentRole"] = studentRole;
            }


            return View();
        }

        /**
         * Redirect to statistics page
         */ 
        public ActionResult Stats()
        {

            return View(iViewResults.ViewVotingResults());
        }
    }
}

