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
using System.IO;

namespace adminlte.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyID,CompanyName,CompanyLocation,CompanyFax,CompanyTelePhone,AboutCompany")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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

        //------------------------------------------------------------------------------------------------------------
        public ActionResult CreateBuses()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBuses(Bus bus)
        {
            if (ModelState.IsValid)
            {

                bus.BusID = User.Identity.GetUserId();
                bus.BusNumber = (db.Buses.Where(a => a.BusID == bus.BusID).ToList().Count() + 1).ToString();
                db.Buses.Add(bus);
                db.SaveChanges();
                return RedirectToAction("ManageBuses");
            }

            return View(bus);
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult ManageBuses()
        {
            string id = User.Identity.GetUserId();
            return View(db.Buses.Where(a=>a.BusID == id).ToList());
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult EditBus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBus(Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageBuses");
            }
            return View(bus);
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult DeleteBus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("DeleteBus")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBus(int id)
        {
            Bus bus = db.Buses.Find(id);
            db.Buses.Remove(bus);
            db.SaveChanges();
            return RedirectToAction("ManageBuses");
        }

        //------------------------------------------------------------------------------------------------------------
        public ActionResult ManageDrivers()
        {
            string id = User.Identity.GetUserId();
            return View(db.PublicDrivers.Where(a => a.PublicDriverID == id).ToList());
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult CreateDrivers()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDrivers(PublicDriver publicdriver, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                publicdriver.PublicDriverID = User.Identity.GetUserId();
                db.PublicDrivers.Add(publicdriver);

                if (upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    publicdriver.DriverImage = upload.FileName;
                }

                db.SaveChanges();
                return RedirectToAction("ManageDrivers");
            }

            return View(publicdriver);
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult EditDriver(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicDriver publicdriver = db.PublicDrivers.Find(id);
            if (publicdriver == null)
            {
                return HttpNotFound();
            }
            return View(publicdriver);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDriver(PublicDriver publicdriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicdriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageDrivers");
            }
            return View(publicdriver);
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult DeleteDriver(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicDriver publicdriver = db.PublicDrivers.Find(id);
            if (publicdriver == null)
            {
                return HttpNotFound();
            }
            return View(publicdriver);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("DeleteDriver")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDriver(int id)
        {
            PublicDriver publicdriver = db.PublicDrivers.Find(id);
            db.PublicDrivers.Remove(publicdriver);
            db.SaveChanges();
            return RedirectToAction("ManageDrivers");
        }

        //------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------
        public ActionResult ManageVehicles()
        {
            string id = User.Identity.GetUserId();
            return View(db.Vehicles.Where(a => a.VehicleID == id).ToList());
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult CreateVehicle()
        {
            string id = User.Identity.GetUserId();
            ViewBag.Buses = db.Buses.Where(a => a.BusID == id && a.IDVehicle == 0).ToList();
            ViewBag.Drivers = db.PublicDrivers.Where(a => a.PublicDriverID == id && a.IDVehicle == 0).ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVehicle(Vehicle vehicgle)
        {
            try
            {
                Vehicle vehicle = new Vehicle();

                string id = User.Identity.GetUserId();
                vehicle.VehicleID = User.Identity.GetUserId();

                var BusData = Request.Form["BusData"].ToString();
                var DriverData = Request.Form["DriverData"].ToString();

                var COMPANY = db.Companies.Where(a => a.CompanyID == id).SingleOrDefault();
                vehicle.IDCompany = COMPANY.Id;

                var bus_data = BusData.Split('/');
                var driver_data = DriverData.Split(' ');
                var Bus_Model = bus_data[0].Trim();
                var Bus_Plate = bus_data[1].Trim();

                var driver_name = driver_data[0].Trim();
                var driver_lastname = driver_data[1].Trim();

                var BUS = db.Buses.Where(a => a.BusModel.Contains(Bus_Model) && a.BusPlate.Contains(Bus_Plate)).SingleOrDefault();
                vehicle.IDBus = BUS.Id;

                var DRIVER = db.PublicDrivers.Where(a => a.DriverName == driver_name && a.DriverLastName == driver_lastname).SingleOrDefault();
                vehicle.IDPublicDriver = DRIVER.Id;

                db.Vehicles.Add(vehicle);

                db.SaveChanges();


                var V = db.Vehicles.Where(a => a.IDBus == BUS.Id && a.IDPublicDriver== DRIVER.Id).SingleOrDefault();
                BUS.IDVehicle = V.Id;
                db.SaveChanges();

                DRIVER.IDVehicle = V.Id;
                db.SaveChanges();

                return RedirectToAction("ManageVehicles");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ManageVehicles");
            }
        }
  
        //------------------------------------------------------------------------------------------------------------
        public ActionResult DeleteVehicle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("DeleteVehicle")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);



            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            var BUS = db.Buses.Where(a => a.Id == vehicle.IDBus).SingleOrDefault();
            BUS.IDVehicle = 0;
            db.SaveChanges();
            var DRIVER = db.PublicDrivers.Where(a => a.Id == vehicle.IDPublicDriver).SingleOrDefault();
            DRIVER.IDVehicle = 0;
            db.SaveChanges();
            return RedirectToAction("ManageVehicles");
        }

        //------------------------------------------------------------------------------------------------------------
        public ActionResult ManageTravels()
        {
            string id = User.Identity.GetUserId();
            return View(db.Travels.Where(a => a.TravelID == id).ToList());
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult CreateTravel()
        {
            string id = User.Identity.GetUserId();

            ViewBag.Vehicle = db.Vehicles.Where(a => a.VehicleID == id && a.IDTravel == 0).ToList();

            ViewBag.Buses = db.Buses.Where(a => a.BusID == id && a.IDVehicle != 0).ToList();
            ViewBag.Drivers = db.PublicDrivers.Where(a => a.PublicDriverID == id && a.IDVehicle != 0).ToList();


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTravel(Travel travel)
        {
            try
            {

                string id = User.Identity.GetUserId();
                travel.TravelID = User.Identity.GetUserId();

                var TravelData = Request.Form["TravelData"].ToString();

                var COMPANY = db.Companies.Where(a => a.CompanyID == id).SingleOrDefault();
                travel.IDCompany = COMPANY.Id;

                var All_data = TravelData.Split('/');

                var Driver_data = All_data[0].Split(' ');

                var bus_data = All_data[1].Split(' ');

                var DriverName = Driver_data[0].Trim();
                var DriverLastname = Driver_data[1].Trim();

                var Bus_Model = bus_data[1].Trim();
                var Bus_Plate = bus_data[2].Trim();

                var BUS = db.Buses.Where(a => a.BusModel.Contains(Bus_Model) && a.BusPlate.Contains(Bus_Plate)).SingleOrDefault();
                var Vehicle = db.Vehicles.Where(a => a.IDBus == BUS.Id).SingleOrDefault();
                travel.IDVehicle = Vehicle.Id;

                db.Travels.Add(travel);

                db.SaveChanges();


                var V = db.Travels.Where(a => a.TravelID == id && a.IDVehicle == Vehicle.Id).SingleOrDefault();
                Vehicle.IDTravel = V.Id;
                db.SaveChanges();

                return RedirectToAction("ManageTravels");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ManageTravels");
            }
        }

        //------------------------------------------------------------------------------------------------------------
        public ActionResult DeleteTravel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("DeleteTravel")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTravel(int id)
        {
            Travel travel = db.Travels.Find(id);
            db.Travels.Remove(travel);
            db.SaveChanges();

            var vehicle = db.Vehicles.Where(a => a.IDTravel == travel.Id).SingleOrDefault();
            vehicle.IDTravel = 0;
            db.SaveChanges();
            return RedirectToAction("ManageTravels");
        }

        //------------------------------------------------------------------------------------------------------------        
        public ActionResult Dashboard()
        {
            string id = User.Identity.GetUserId();
            ViewBag.ComID= id;
            return View();
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult TransportationDetails(int? TravelID)
        {
            var travel = db.Travels.Where(a => a.Id == TravelID).SingleOrDefault();
            return View(travel);
        }
        //------------------------------------------------------------------------------------------------------------
        public ActionResult Cancelreservation(int? passengerID)
        {            
            var passenger = db.Passengers.Where(a => a.Id == passengerID).SingleOrDefault();
            var user = db.Clients.Where(a => a.IDUser == passenger.IDUser).SingleOrDefault();


            var travel = db.Travels.Where(a => a.Id == passenger.IDTravel).SingleOrDefault();
            travel.PassengerNumber = travel.PassengerNumber - int.Parse(passenger.SitNumber);
            db.SaveChanges();

            db.Passengers.Remove(passenger);
            db.SaveChanges();
            string userid = User.Identity.GetUserId();
            var company = db.Companies.Where(a => a.CompanyID == userid).SingleOrDefault();

            MailBox mail = new MailBox();
            string Message = "Sorry "+ user.UserName +" Your reservation is cancelled";
            mail.Message = Message;
            mail.Subject = "Book a public transportation";
            mail.TargetID = passenger.IDUser;
            mail.Sender = company.CompanyName;
            mail.SenderID = company.CompanyID;

            mail.TimeStamp = System.DateTime.Now.ToString();
            db.MailBoxes.Add(mail);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        //------------------------------------------------------------------------------------------------------------
    }
}
