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
                    Color = v.Color,
                    Name = v.Name,
                    RegNr = v.RegNr,
                    VehicleType = v.VehicleType.TypeName,
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
            //IndexViewModel model = search;
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
                databaseList = db.Vehicles.Where(x => x.VehicleType.ToString().Contains(viewModel.SearchString)).ToList();
            }
            foreach (var v in databaseList)
            {
                vehicles.Add(new IndexVehicle()
                {
                    Id = v.Id,
                    Color = v.Color,
                    Name = v.Name,
                    RegNr = v.RegNr,
                    VehicleType = v.VehicleType.TypeName,
                    CheckInTime = v.CheckInTime
                });
            }
            viewModel.Vehicles = vehicles;
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
            ParkVehicleViewModel viewModel = new ParkVehicleViewModel();
            viewModel.VehicleTypes = new List<SelectListItem>();
            foreach (var v in db.VehicleTypes)
            {
                viewModel.VehicleTypes.Add(new SelectListItem()
                {
                    Text = v.TypeName,
                    Value = v.Id.ToString()
                });
            }
            //viewModel.VehicleTypes = temp;
            return View(viewModel);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,RegNr,Name,VehicleTypeId,NrOfWheels,Color,Model,Make")] ParkVehicleViewModel fork)
        {
            if (db.Vehicles.Where(x => x.RegNr == fork.RegNr).Count() > 0)
            {
                fork.ErrorMessage = "The registration number must be uniqe";
                return View(fork);
            }

            if (ModelState.IsValid)
            {
                Vehicle vehicle = new Vehicle()
                {
                    RegNr = fork.RegNr,
                    Color = fork.Color,
                    Make = fork.Make,
                    Model = fork.Model,
                    Name = fork.Name,
                    NrOfWheels = fork.NrOfWheels,
                    VehicleTypeId = fork.VehicleTypeId,
                    CheckInTime = DateTime.Now
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

            EditVehicleViewModel viewModel = new EditVehicleViewModel()
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                NrOfWheels = vehicle.NrOfWheels,
                Color = vehicle.Color,
                Make = vehicle.Make,
                Model = vehicle.Model,
                CheckInTime = vehicle.CheckInTime
            };
            viewModel.VehicleTypes = new List<SelectListItem>();

            viewModel.VehicleTypeId = vehicle.VehicleTypeId;

            foreach (var v in db.VehicleTypes)
            {
                viewModel.VehicleTypes.Add(new SelectListItem()
                {
                    Text = v.TypeName,
                    Value = v.Id.ToString()
                });
            }

            return View(viewModel);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,VehicleTypeId,NrOfWheels,Color,Model,Make")] EditVehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                Vehicle v = db.Vehicles.First(x => x.Id == vehicle.Id);
                v.Color = vehicle.Color;
                v.Make = vehicle.Make;
                v.Model = vehicle.Model;
                v.Name = vehicle.Name;
                v.NrOfWheels = vehicle.NrOfWheels;
                v.VehicleTypeId = vehicle.VehicleTypeId;
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
            receipt.VehicleType = vehicle.VehicleType.TypeName;
            receipt.CheckInTime = vehicle.CheckInTime;
            receipt.CheckOutTime = DateTime.Now;

            int totalMin = Convert.ToInt32((DateTime.Now - receipt.CheckInTime).TotalMinutes);

            receipt.TotalTime = totalMin + " min";
            receipt.TotalPrice = ((totalMin / 30) * 100) + " kr";

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
