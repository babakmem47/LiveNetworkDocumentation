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

        public ActionResult Edit(int id)
        {
            var personnel = _db.KhadamatMashiniPersonnels.SingleOrDefault(k => k.Id == id);
            if (personnel == null)
            {
                return HttpNotFound();
            }

            var personnelViewModel = new PersonnelSematMantagheViewModel(personnel)
            {
                Semats = _db.Semats.ToList(),
                Manateghs = _db.Manateghs.ToList()
                
            };

            return View("PersonnelForm", personnelViewModel);

        }


        public ActionResult New()
        {
            var personnelViewModel = new PersonnelSematMantagheViewModel()
            {
                Semats = _db.Semats.ToList(),
                Manateghs = _db.Manateghs.ToList()
            };


            return View("PersonnelForm", personnelViewModel);
        }

        [HttpPost]
        public ActionResult Save(PersonnelSematMantagheViewModel personnel)
        {
            if (!ModelState.IsValid)
            {
                personnel.Semats = _db.Semats.ToList();
                personnel.Manateghs = _db.Manateghs.ToList();
               return View("PersonnelForm", personnel);
            }

            if (personnel.Id == 0)
            {
                var khMashini = new KhadamatMashiniPersonnel();
                khMashini.Id = personnel.Id;
                khMashini.Name = personnel.Name;
                khMashini.SematId = personnel.SematId;
                khMashini.TelDakheli = personnel.TelDakheli;
                khMashini.TelMostaghim = personnel.TelMostaghim;
                khMashini.Mobile = personnel.Mobile;
                khMashini.ManateghId = personnel.ManateghId;

                _db.KhadamatMashiniPersonnels.Add(khMashini);
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

            return RedirectToAction("Index", "Personnel");
        }
    }
}