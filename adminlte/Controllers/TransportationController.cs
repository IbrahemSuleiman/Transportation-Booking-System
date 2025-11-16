using adminlte.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminlte.Controllers
{
    public class TransportationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transportation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PublicTransportation()
        {
            return View();
        }

        public ActionResult TransportationDetails(int? TravelID)
        {
            var travel = db.Travels.Where(a => a.Id == TravelID).SingleOrDefault();
            return View(travel);
        }
         
        public ActionResult Book_Transportaion(int? TravelID)
        {
            var travel = db.Travels.Where(a => a.Id == TravelID).SingleOrDefault();
            ViewBag.TravelData = travel;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book_Transportaion(Passenger passenger,int travelid)
        {
            string userid = User.Identity.GetUserId();
            var Travel = db.Travels.Where(a => a.Id == travelid).SingleOrDefault();
            var company = db.Companies.Where(a => a.Id == Travel.IDCompany).SingleOrDefault();

            var bookcheck = db.Passengers.Where(a => a.IDUser == userid && a.IDTravel == Travel.Id).ToList();

            if (bookcheck.Count>0)
            {
                ViewBag.message = "You have already applied for this travel!";
                ViewBag.TravelData = Travel;
                return View();
            }
            else
            {

                if (int.Parse(passenger.SitNumber)<11)
                {
                    if (int.Parse(passenger.SitNumber) < 46 -Travel.PassengerNumber )
                    {
                        passenger.IDUser = userid;
                        passenger.IDTravel = Travel.Id;
                        passenger.IDCompany = Travel.IDCompany;

                        db.Passengers.Add(passenger);
                        db.SaveChanges();

                        Travel.PassengerNumber += int.Parse(passenger.SitNumber);
                        db.SaveChanges();

                        MailBox mail = new MailBox();
                        string Message = "Your reservation is applied successfully, please don't miss the bus "+ Travel.Location + "/" + Travel.Destination+ " @ " + Travel.Leavetime;
                        mail.Message = Message;
                        mail.Subject = "Book a public transportation";
                        mail.TargetID = userid;
                        mail.Sender = company.CompanyName;
                        mail.SenderID = company.CompanyID;
                        mail.TimeStamp = System.DateTime.Now.ToString();
                        db.MailBoxes.Add(mail);
                        db.SaveChanges();

                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        var n = 45 - @Travel.PassengerNumber;

                        ViewBag.message = "This travel has only (" + n + ") sits available" ;
                        ViewBag.TravelData = Travel;
                        return View();
                    }
                   
                }
                else
                {
                    ViewBag.message = "You are not allowed to book more than 10 sits!";
                    ViewBag.TravelData = Travel;
                    return View();
                }

                
            }

        }
        //--------------------------------------------------------------------------------
    }
}