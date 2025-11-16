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
    public class PublicDriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PublicDrivers
        public ActionResult Index()
        {
            return View(db.PublicDrivers.ToList());
        }

        // GET: PublicDrivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicDriver publicDriver = db.PublicDrivers.Find(id);
            if (publicDriver == null)
            {
                return HttpNotFound();
            }
            return View(publicDriver);
        }

        // GET: PublicDrivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PublicDriverID,DriverName,DriverLastName,DriverNationalID,DriverPhone,DriverImage,IDVehicle")] PublicDriver publicDriver)
        {
            if (ModelState.IsValid)
            {
                PublicDriver p = new PublicDriver();
                p.DriverName = publicDriver.DriverName;
                p.DriverLastName = publicDriver.DriverLastName;
                p.DriverNationalID = publicDriver.DriverNationalID;
                p.DriverPhone = publicDriver.DriverPhone;
                p.DriverImage = publicDriver.DriverImage;
                

                db.PublicDrivers.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publicDriver);
        }

        // GET: PublicDrivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicDriver publicDriver = db.PublicDrivers.Find(id);
            if (publicDriver == null)
            {
                return HttpNotFound();
            }
            return View(publicDriver);
        }

        // POST: PublicDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PublicDriverID,DriverName,DriverLastName,DriverNationalID,DriverPhone,DriverImage,IDVehicle")] PublicDriver publicDriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicDriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicDriver);
        }

        // GET: PublicDrivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicDriver publicDriver = db.PublicDrivers.Find(id);
            if (publicDriver == null)
            {
                return HttpNotFound();
            }
            return View(publicDriver);
        }

        // POST: PublicDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicDriver publicDriver = db.PublicDrivers.Find(id);
            db.PublicDrivers.Remove(publicDriver);
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
