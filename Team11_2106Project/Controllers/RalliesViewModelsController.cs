using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team11_2106Project.DBContext;
using Team11_2106Project.ViewModel;
using Team11_2106Project.DomainModel;
namespace Team11_2106Project.Controllers
{
    public class RalliesViewModelsController : Controller
    {
        internal IRallies Irally = new Rallies();
        private ElectionDBContext db = new ElectionDBContext();
        // GET: RalliesViewModels
        public ActionResult Index()
        {

            return View(Irally.ViewAllRallies());
        }

        // GET: RalliesViewModels/Details/5
        public ActionResult Details(int id)
        {
            RalliesViewModel RalliesProfile = Irally.ViewRallies(id);
            if (RalliesProfile == null)
            {
                return HttpNotFound();
            }
            return View(RalliesProfile);
        }

        // GET: RalliesViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RalliesViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RalliesID,CandidateID,CandidateName,Date,Location,Description")] RalliesViewModel ralliesViewModel)
        {
            if (ModelState.IsValid)
            {
                Irally.CreateRallies(ralliesViewModel);

                return RedirectToAction("Index");
            }

            return View(ralliesViewModel);
        }

        // GET: RalliesViewModels/Edit/5
        public ActionResult Edit(int id = 4)
        {
            // TODO HARDCODED ID NEEDS TO BE DYNAMIC
            RalliesViewModel rallyProfile = Irally.ViewRallies(id);
            return View(rallyProfile);
        }

        // POST: RalliesViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RalliesID,CandidateID,CandidateName,Date,Location,Description")] RalliesViewModel ralliesViewModel)
        {

            if (ModelState.IsValid)
            {
                Irally.EditRallies(ralliesViewModel);

                return RedirectToAction("Index");
            }
            return View(ralliesViewModel);
        }

        // GET: RalliesViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            ;
            return View(Irally.ViewRallies(id));
        }

        // POST: RalliesViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Irally.DeleteRallies(id);
            return RedirectToAction("Index");
        }

    }
}
