using ExploreCalifornia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class CandidateController : Controller
    {
        //create new list to store all the candidate can change it to send it to database
        static List<Candidate> candidateList = new List<Candidate>();
        // GET: Candidate
        public ActionResult Index()
        {

            //create new candidate object and add the cca .. hardcode first. return the objects
         
            return View(candidateList);
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Confirm(int id)

        {

            return View(candidateList.ElementAt(id));


        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        public ActionResult Create(Candidate c1)
        {
            try
            {
                // TODO: Add insert logic here
                candidateList.Add(c1);
                return RedirectToAction("Confirm", new { id = c1.candidateID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
