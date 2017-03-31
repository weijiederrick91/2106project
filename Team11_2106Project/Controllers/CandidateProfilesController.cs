using System.Net;
using System.Web.Mvc;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.Controllers
{

    //This class accepts input and converts it into commands and updates the view accordingly.  It is part of the presentation layer.
    public class CandidateProfilesController : Controller
    {
       
        // GET: CandidateProfiles

            
        public ActionResult Index()
        {   
            return View();
        }
        public ActionResult IndexWithComment()
        {
            return View();
        }

        // GET: CandidateProfiles/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: CandidateProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: CandidateProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateID,Name,StudentYear,UpdatedTime,PositionApplied,Introduction,CCA")] CandidateProfileViewModel candidateProfile)
        {
            return View();
        }
    }
}
