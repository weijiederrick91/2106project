using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team11_2106Project.DAL;
using Team11_2106Project.Models;
using Team11_2106Project.TableModule;
namespace Team11_2106Project.Controllers
{

    //This class accepts input and converts it into commands and updates the view accordingly.  It is part of the presentation layer.
    public class CandidateProfilesController : Controller
    {
        
        // private ElectionDBContext db = new ElectionDBContext();
        internal CandidateProfileTableModule CandidateProfileTM = new CandidateProfileTableModule();
        // GET: CandidateProfiles

            
        public ActionResult Index()
        {


            return View(CandidateProfileTM.ViewProfiles());

        }
        public ActionResult IndexWithComment()
        {


            return View(CandidateProfileTM.ViewProfiles());

        }

        // GET: CandidateProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateProfile candidateProfile = CandidateProfileTM.ViewSpecificProfile(id);
            if (candidateProfile == null)
            {
                return HttpNotFound();
            }
            return View(candidateProfile);
        }

        // GET: CandidateProfiles/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: CandidateProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CandidateID,Name,StudentYear,UpdatedTime,PositionApplied,Introduction,CCA")] CandidateProfile candidateProfile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CandidateProfiles.Add(candidateProfile);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(candidateProfile);
        //}

        // GET: CandidateProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateProfile candidateProfile = CandidateProfileTM.ViewSpecificProfile(id);
            if (candidateProfile == null)
            {
                return HttpNotFound();
            }
            if (id == 4) //candidates can only edit his/her own profile. 
            {
                return View(candidateProfile);
            }
            return RedirectToAction("IndexWithComment");
        }

        // POST: CandidateProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateID,Name,StudentYear,UpdatedTime,PositionApplied,Introduction,CCA")] CandidateProfile candidateProfile)
        {
            if (ModelState.IsValid)
            {
                CandidateProfileTM.EditProfile(candidateProfile);
            
                return RedirectToAction("Index");
            }
            return View(candidateProfile);
        }

        //// GET: CandidateProfiles/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CandidateProfile candidateProfile = db.CandidateProfiles.Find(id);
        //    if (candidateProfile == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(candidateProfile);
        //}

        //// POST: CandidateProfiles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CandidateProfile candidateProfile = db.CandidateProfiles.Find(id);
        //    db.CandidateProfiles.Remove(candidateProfile);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
