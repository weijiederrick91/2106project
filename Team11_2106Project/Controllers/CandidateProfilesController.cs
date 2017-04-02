using System.Net;
using System.Web.Mvc;
using Team11_2106Project.ViewModel;
using Team11_2106Project.DomainModel;

namespace Team11_2106Project.Controllers
{

    //This class accepts input and converts it into commands and updates the view accordingly.  It is part of the presentation layer.
    public class CandidateProfilesController : Controller
    {
        // GET: CandidateProfiles
        internal ICandidateProfile IcanProf = new CandidateProfile();


        public ActionResult Index()
        {
            return View(IcanProf.ViewAllProfiles());
        }
        public ActionResult IndexWithComment()
        {
            return View();
        }

        // GET: CandidateProfiles/Details/5
        public ActionResult Details(int id)
        {

            CandidateProfileViewModel candidateProfile = IcanProf.ViewProfile(id);
            if (candidateProfile == null)
            {
                return HttpNotFound();
            }
            return View(candidateProfile);
        }

        // GET: CandidateProfiles/Edit/5
        public ActionResult Edit(int id = 1)
        {

            // TODO HARDCODED ID NEEDS TO BE DYNAMIC
            CandidateProfileViewModel CandidateProfile = IcanProf.ViewProfile(id);
            return View(CandidateProfile);

        }

        // POST: CandidateProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateID,Name,StudentYear,UpdatedTime,PositionApplied,Introduction,CCA")] CandidateProfileViewModel candidateProfile)
        {
            if (ModelState.IsValid)
            {
                IcanProf.EditProfile(candidateProfile);

                return RedirectToAction("Index");
            }
            return View(candidateProfile);
        }
    }
}
