using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using adminlte.Models;
using Microsoft.AspNet.Identity;

namespace adminlte.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            return View(db.Tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserID,BusID,State,OpenTime,CloseTime")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserID,BusID,State,OpenTime,CloseTime")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);

            var order = db.Orders.Where(a => a.Id == ticket.OrderID).SingleOrDefault();
            var privatedriver = db.PrivateDrivers.Where(a => a.Id == ticket.DriverID).SingleOrDefault();
            db.Tickets.Remove(ticket);
            db.SaveChanges();

            order.IDTicket = 0;
            db.SaveChanges();
            privatedriver.Availability = true;
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


        public ActionResult CreateTicket()
        {
            string id = User.Identity.GetUserId();
            ViewBag.privateDrivers = db.PrivateDrivers.Where(a => a.Availability == true).ToList();
            ViewBag.Orders = db.Orders.Where(a => a.IDTicket == 0).ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTicket(Ticket ticket)
        {
            try
            {
                Ticket Tic = new Ticket();

                var OrderData = Request.Form["OrderData"].ToString();
                var DriverData = Request.Form["privateDrivers"].ToString();

                var Order_data = OrderData.Split(' ');
                var driver_data = DriverData.Split('/');
                var location = Order_data[0].Trim();
                var distination = Order_data[1].Trim();
                var time = Order_data[2].Trim();

                var driver_name = driver_data[0].Trim();
                var driver_lastname = driver_data[1].Trim();

                var order = db.Orders.Where(a => a.Location == location && a.Distination == distination).SingleOrDefault();
                var privatedriver = db.PrivateDrivers.Where(a => a.DriverName == driver_name && a.DriverLastName == driver_lastname).SingleOrDefault();
 
                Tic.DriverID = privatedriver.Id;
                Tic.OrderID = order.Id;
                Tic.State = true;
                Tic.OpenTime = System.DateTime.Now;
                Tic.CloseTime = System.DateTime.Now;
                db.Tickets.Add(Tic);

                db.SaveChanges();

                order.IDTicket = Tic.id;
                db.SaveChanges();
                privatedriver.Availability = false;
                db.SaveChanges();


                MailBox mail = new MailBox();
                string Message = "Your driver is "+ driver_name +" "+ driver_lastname + ", please don't miss the appointment from " + location + "to " + distination + " @ " + time;
                mail.Message = Message;
                mail.Subject = "Taxi reservation";
                mail.TargetID = order.IDUser;
                mail.Sender = "Admin";
                mail.SenderID = "";
                mail.TimeStamp = System.DateTime.Now.ToString();
                db.MailBoxes.Add(mail);
                db.SaveChanges();

                MailBox mail_driver = new MailBox();
                string Message_driver = "You have an appointment at " + time + " from " + location + " to " + distination +", with Mr. ";
                mail_driver.Message = Message_driver;
                mail_driver.Subject = "Taxi reservation";
                mail_driver.TargetID = privatedriver.PrivateDriverID;
                mail_driver.Sender = "Admin";
                mail_driver.SenderID = "";
                mail_driver.TimeStamp = System.DateTime.Now.ToString();
                db.MailBoxes.Add(mail_driver);
                db.SaveChanges();

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("index");
            }
        }
    }
}
