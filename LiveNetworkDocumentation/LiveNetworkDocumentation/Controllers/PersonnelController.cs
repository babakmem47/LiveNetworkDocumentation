using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LiveNetworkDocumentation.Models;
using LiveNetworkDocumentation.ViewModels;

namespace LiveNetworkDocumentation.Controllers
{
    public class PersonnelController : Controller
    {
        private LiveNetworkDocumentationEntities _db;

        public PersonnelController()
        {
            _db = new LiveNetworkDocumentationEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: Personnel
        public ActionResult Index()
        {
            var personelList = _db.KhadamatMashiniPersonnels.Include(k => k.Semat).Include(k => k.Manategh).ToList();

            return View(personelList);
        }

        public ActionResult Edit(KhadamatMashiniPersonnel personnel)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonnelForm");
            }

            if (personnel.Id == 0)
            {
                _db.KhadamatMashiniPersonnels.Add(personnel);
            }
            else
            {
                var personnelInDb = _db.KhadamatMashiniPersonnels.Single(k => k.Id == personnel.Id);
                personnelInDb.Name = personnel.Name;
                personnelInDb.SematId = personnel.SematId;
                personnelInDb.TelDakheli = personnel.TelDakheli;
                personnelInDb.TelMostaghim = personnel.TelMostaghim;
                personnelInDb.Mobile = personnel.Mobile;
                personnelInDb.ManateghId = personnel.ManateghId;

            }

            _db.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult New()
        {
            var personnelViewModel = new PersonnelSematMantagheViewModel();


            return View("PersonnelForm", personnelViewModel);
        }
    }
}