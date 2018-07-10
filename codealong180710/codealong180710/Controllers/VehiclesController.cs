using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using codealong180710.DataAccessLayer;
using codealong180710.Models;

namespace codealong180710.Controllers
{
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        [HttpGet]
        public ActionResult Index()
        {
            List<IndexVehicle> Vehicals = new List<IndexVehicle>();
            foreach (var v in db.Vehicles.ToList())
            {
                Vehicals.Add(new IndexVehicle() { Id = v.Id, RegNr = v.RegNr, Color = v.Color, Name = v.Name, VehicleType = v.VehicleType, CheckInTime = v.CheckInTime });
            }
            IndexViewModel model = new IndexViewModel();
            model.Vehicles = Vehicals;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Searchstring, SearchFild")] IndexViewModel viewmodel)
        {
            // IndexViewModel model = new IndexViewModel();
            //model.SearchString = search;

            List<IndexVehicle> Vehicles = new List<IndexVehicle>();
            if (String.IsNullOrWhiteSpace(viewmodel.SearchString))
            {
                return RedirectToAction("Index");
            }

            List<Vehicle> DataBaseList = new List<Vehicle>();
            if(viewmodel.SearchField == "Regnr")
            {
                DataBaseList = db.Vehicles.Where(x => x.RegNr.Contains(viewmodel.SearchString)).ToList();
            }
            if(viewmodel.SearchField == "VehicleType")
            {
                DataBaseList = db.Vehicles.Where(x => x.VehicleType.ToString().Contains(viewmodel.SearchString)).ToList();
            }
            foreach (var v in DataBaseList)
            {
                Vehicles.Add(new IndexVehicle()
                {
                    Id = v.Id,
                    RegNr = v.RegNr,
                    Name = v.Name,
                    Color = v.Color,
                    VehicleType = v.VehicleType,
                    CheckInTime = v.CheckInTime,
                });
            }
            viewmodel.Vehicles = Vehicles;
            return View(viewmodel);


        }



        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
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

        // GET: Vehicles/Create
        public ActionResult Park()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "RegNr,Name,VehicleType,NrOfWheels,Color,Model,Make")] ParkVehicleViewModel fork)
        {
            if (db.Vehicles.Where(x => x.RegNr == fork.RegNr).Count() > 0)
            {
                fork.ErrorMessage = "The registration number must uniqe";
                return View(fork);
            }

            if (ModelState.IsValid)
            {
                Vehicle vehicle = new Vehicle()
                {
                    RegNr = fork.RegNr,
                    Name = fork.Name,
                    Color = fork.Color,
                    Make = fork.Make,
                    Model = fork.Model,
                    NrOfWheels = fork.NrOfWheels,
                    VehicleType = fork.VehicleType,
                    CheckInTime = DateTime.Now,
                };
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fork);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,Name,VehicleType,NrOfWheels,Color,Model,Make")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Vehicle v = db.Vehicles.First(x => x.Id == vehicle.Id);
                v.Color = vehicle.Color;
                v.Name = vehicle.Name;
                v.VehicleType = vehicle.VehicleType;
                v.RegNr = vehicle.RegNr;
                v.NrOfWheels = vehicle.NrOfWheels;
                v.Model = vehicle.Model;
                v.Make = vehicle.Make;
                vehicle.CheckInTime = db.Vehicles.First(x => x.Id == vehicle.Id).CheckInTime;

                //db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult CheckOut(int? id)
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

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("CheckOut")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);

            Receipt receipt = new Receipt();
            receipt.RegNr = vehicle.RegNr;
            receipt.VehicleType = vehicle.VehicleType;
            receipt.CheckInTime = vehicle.CheckInTime;
            receipt.CheckOutTime = DateTime.Now;

            int totalMin = Convert.ToInt32((DateTime.Now - receipt.CheckInTime).TotalMinutes);
            receipt.TotalTime = totalMin + " min";
            receipt.TotalPrice = ((totalMin / 30) * 100 + "min");

            //receipt.TotalTime = (DateTime.Now - receipt.CheckInTime).TotalMinutes.ToString();
            //receipt.TotalPrice = ((DateTime.Now - receipt.CheckInTime).TotalMinutes * 2) + "Kr";
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            return View("Receipt", receipt);
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
