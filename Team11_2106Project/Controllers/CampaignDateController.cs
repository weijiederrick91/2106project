using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team11_2106Project.DBContext;
using Team11_2106Project.DomainModel;
using Team11_2106Project.ViewModel;

namespace Team11_2106Project.Controllers
{
    public class CampaignDateController : Controller
    {

        internal ICampaignDate iCampaign = new CampaignDate();

        // GET: Campaign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignDateViewModel campaignViewModel = iCampaign.getCampaignViewModel();
            if (campaignViewModel == null)
            {
                return HttpNotFound();
            }
            return View(campaignViewModel);
        }

        // GET: Campaign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignDateViewModel campaignViewModel = iCampaign.getCampaignViewModel();
            if (campaignViewModel == null)
            {
                return HttpNotFound();
            }
            return View(campaignViewModel);
        }

        // POST: Campaign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampaignID,EndDate,StartDate")] CampaignDateViewModel campaignViewModel)
        {
            if (ModelState.IsValid)
            {
                if (iCampaign.saveDates(campaignViewModel.StartDate, campaignViewModel.EndDate))
                {
                    return RedirectToAction("Details", new { id = 1 });
                }
            }
            return View(campaignViewModel);
        }
    }
}
