using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using adminlte.Models;

namespace adminlte.Controllers
{
    public class PrivateDriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PrivateDrivers
        public ActionResult Index()
        {
            return View(db.PrivateDrivers.ToList());
        }

        // GET: PrivateDrivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateDriver privateDriver = db.PrivateDrivers.Find(id);
            if (privateDriver == null)
            {
                return HttpNotFound();
            }
            return View(privateDriver);
        }

        // GET: PrivateDrivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrivateDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrivateDriverID,DriverName,DriverLastName,DriverNationalID,DriverPhone,DriverImage,TaxiModel,TaxiPlate,TaxiColor,TaxiImage,Availability")] PrivateDriver privateDriver)
        {
            if (ModelState.IsValid)
            {
                db.PrivateDrivers.Add(privateDriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(privateDriver);
        }

        // GET: PrivateDrivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateDriver privateDriver = db.PrivateDrivers.Find(id);
            if (privateDriver == null)
            {
                return HttpNotFound();
            }
            return View(privateDriver);
        }

        // POST: PrivateDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrivateDriverID,DriverName,DriverLastName,DriverNationalID,DriverPhone,DriverImage,TaxiModel,TaxiPlate,TaxiColor,TaxiImage,Availability")] PrivateDriver privateDriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privateDriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(privateDriver);
        }

        // GET: PrivateDrivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateDriver privateDriver = db.PrivateDrivers.Find(id);
            if (privateDriver == null)
            {
                return HttpNotFound();
            }
            return View(privateDriver);
        }

        // POST: PrivateDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrivateDriver privateDriver = db.PrivateDrivers.Find(id);
            db.PrivateDrivers.Remove(privateDriver);
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
        }
    }
}
