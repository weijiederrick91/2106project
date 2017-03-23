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
using System.Web.Security;

namespace Team11_2106Project.Controllers
{
    public class VotersController : Controller
    {
      

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
                using ( ElectionDBContext db = new ElectionDBContext())
                {
                    string username = model.Email;
                    string password = model.Password;

                    // Now if our password was enctypted or hashed we would have done the
                    // same operation on the user entered password here, But for now
                    // since the password is in plain text lets just authenticate directly

                    bool userValid = db.Voters.Any(user => user.Email == username && user.Password == password);


                    // User found in the database
                    if (userValid)
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
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        


















        /* // GET: Voters
         public ActionResult Index()
         {
             return View(db.Voters.ToList());
         }

         // GET: Voters/Details/5
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Voter voter = db.Voters.Find(id);
             if (voter == null)
             {
                 return HttpNotFound();
             }
             return View(voter);
         }

         // GET: Voters/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: Voters/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "VoterID,Email,Password,SingleVote")] Voter voter)
         {
             if (ModelState.IsValid)
             {
                 db.Voters.Add(voter);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             return View(voter);
         }

         // GET: Voters/Edit/5
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Voter voter = db.Voters.Find(id);
             if (voter == null)
             {
                 return HttpNotFound();
             }
             return View(voter);
         }

         // POST: Voters/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "VoterID,Email,Password,SingleVote")] Voter voter)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(voter).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(voter);
         }

         // GET: Voters/Delete/5
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Voter voter = db.Voters.Find(id);
             if (voter == null)
             {
                 return HttpNotFound();
             }
             return View(voter);
         }

         // POST: Voters/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             Voter voter = db.Voters.Find(id);
             db.Voters.Remove(voter);
             db.SaveChanges();
             return RedirectToAction("Index");
         }

         protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         } */
    }
}
