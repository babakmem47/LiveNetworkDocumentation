using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveNetworkDocumentation.Models;

namespace LiveNetworkDocumentation.Controllers
{
    public class ManateghController : Controller
    {
        private readonly LiveNetworkDocumentationEntities _db;

        public ManateghController()
        {
            _db = new LiveNetworkDocumentationEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: Manategh
        public ActionResult Index()
        {
            var manateghs = _db.Manateghs.ToList();

            return View(manateghs);
        }

        public ActionResult Edit(byte id)
        {
            var mantaghe = _db.Manateghs.SingleOrDefault(m => m.Id == id);
            if (mantaghe == null)
            {
                return HttpNotFound();
            }

            return View("MantagheForm", mantaghe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Manategh manategh)
        {
            if (!ModelState.IsValid)
            {
                return View("MantagheForm", manategh);
            }

            if (manategh.Id == 0)        //  Create a new mantaghe
            {
                _db.Manateghs.Add(manategh);
            }
            else                            // update an existing mantaghe
            {
                var mantagheInDb = _db.Manateghs.Single(m => m.Id == manategh.Id);
                mantagheInDb.Name = manategh.Name;
                mantagheInDb.CityCenter = manategh.CityCenter;
                mantagheInDb.Address = manategh.Address;
                mantagheInDb.PreTelCode = manategh.PreTelCode;
            }
            
            _db.SaveChanges();


            return RedirectToAction("Index", "Manategh");
        }
    }
}