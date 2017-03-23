using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class RalliesController : Controller
    {
        // GET: Rallies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rallies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rallies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rallies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rallies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rallies/Edit/5
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

        // GET: Rallies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rallies/Delete/5
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
