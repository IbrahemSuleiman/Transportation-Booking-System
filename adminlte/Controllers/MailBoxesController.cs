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
using PagedList;

namespace adminlte.Controllers
{
    public class MailBoxesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MailBoxes
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            var UserID = User.Identity.GetUserId();

            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Message" : "";
            ViewBag.SortingDate = Sorting_Order == "Subject" ? "Date" : "Message";

            var mails = db.MailBoxes.Where(a => a.TargetID == UserID).ToList();

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            if (Search_Data != null)
            {
                if (Search_Data.Length > 0)
                {
                    mails = db.MailBoxes.Where(stu => stu.Subject.ToUpper().Contains(Search_Data.ToUpper())
                            && (stu.TargetID == UserID)
                            || stu.Message.ToUpper().Contains(Search_Data.ToUpper())).ToList();
                }
            }

            if (Sorting_Order == null)
            {
                Sorting_Order = "Message";
            }

            switch (Sorting_Order)
            {
                case "Message":
                    mails = mails.OrderBy(stu => stu.Message).ToList();
                    break;
                case "Subject":
                    mails = mails.OrderBy(stu => stu.Subject).ToList();
                    break;
                case "Date":
                    mails = mails.OrderBy(stu => stu.TimeStamp).ToList();
                    break;
            }
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(mails.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: MailBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailBox mailBox = db.MailBoxes.Find(id);
            if (mailBox == null)
            {
                return HttpNotFound();
            }
            return View(mailBox);
        }

        // GET: MailBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,Subject,TimeStamp,Sender,SenderID,TargetID")] MailBox mailBox)
        {
            if (ModelState.IsValid)
            {
                db.MailBoxes.Add(mailBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mailBox);
        }

        // GET: MailBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailBox mailBox = db.MailBoxes.Find(id);
            if (mailBox == null)
            {
                return HttpNotFound();
            }
            return View(mailBox);
        }

        // POST: MailBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,Subject,TimeStamp,Sender,SenderID,TargetID")] MailBox mailBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mailBox);
        }

        // GET: MailBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailBox mailBox = db.MailBoxes.Find(id);
            if (mailBox == null)
            {
                return HttpNotFound();
            }
            return View(mailBox);
        }

        // POST: MailBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailBox mailBox = db.MailBoxes.Find(id);
            db.MailBoxes.Remove(mailBox);
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
