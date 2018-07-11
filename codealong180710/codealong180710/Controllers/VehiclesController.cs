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
        public ActionResult Index()
        {
            List<IndexVehicle> vehicles = new List<IndexVehicle>();
            foreach (var v in db.Vehicles.ToList())
            {
                vehicles.Add(new IndexVehicle()
                {
                    Id = v.Id,
                    Color = v.Color, Name = v.Name, RegNr = v.RegNr, VehicleType = v.VehicleType,
                    CheckInTime = v.CheckInTime
                });
            }

            IndexViewModel model = new IndexViewModel();
            model.Vehicles = vehicles;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "SearchString,SearchField")] IndexViewModel viewModel)
        {
            //IndexViewModel model = new IndexViewModel();
            //model.SearchString = search;
            List<IndexVehicle> vehicles = new List<IndexVehicle>();
            if (String.IsNullOrWhiteSpace(viewModel.SearchString))
            {
                return RedirectToAction("Index");
            }
            List<Vehicle> databaseList = new List<Vehicle>();
            if (viewModel.SearchField == "RegNr")
            {
                databaseList = db.Vehicles.Where(x => x.RegNr.Contains(viewModel.SearchString)).ToList();
            }
            else if (viewModel.SearchField == "VehicleType")
            {
                daatabaseList = db.Vehicles.Where(x => x.VehicleType.ToString().Contains(viewModel.SearchString)).ToList();
            }
            
            foreach(var v in databaseList)
            {
                vehicles.Add(new IndexVehicle()
                {
                    Id = v.Id,
                    Color = v.Color,
                    Name = v.Name,
                    RegNr = v.RegNr,
                    VehicleType = v.VehicleType,
                    CheckInTime = v.CheckInTime
                });

            }               
            viewModel.Vehicles =vehicles;
            return View(viewModel);

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
        public ActionResult Park([Bind(Include = "Id,RegNr,Name,VehicleType,NrOfWheels,Color,Model,Make")] ParkVehicleViewModel fork)
        {
            if(db.Vehicles.Where(x => x.RegNr == fork.RegNr).Count() > 0)
            {
                fork.ErrorMessage = "The registration number must be uniqe";
                return View(fork);
            }


            if (ModelState.IsValid)
            {
                vehicle.CheckInTime = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
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
        public ActionResult Edit([Bind(Include = "Id,RegNr,Name,NrOfWheels,Color,Model,Make")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle v = db.Vehicles.First(x = x.Id == vehicle.Id);
                v.Color = vehicle.Color;
                v.Make = vehicle.Make;
                v.NrOfWheels = vehicle.NrOfWheels;
                v.RegNr = vehicle.RegNr;
                v.vehicleType = vehicle.VehicleType;
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
            db.Vehicles.Remove(vehicle);
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
