using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExploreCalifornia.Models;

namespace ExploreCalifornia.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Tour/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tour/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tour/Create
        [HttpPost]
        public ActionResult Create(Tour tour)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Confirm", tour);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tour/Edit/5
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

        //
        // GET: /Tour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tour/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Confirm");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirm(Tour tour)
        {
            return View(tour);
        }
    }
}
