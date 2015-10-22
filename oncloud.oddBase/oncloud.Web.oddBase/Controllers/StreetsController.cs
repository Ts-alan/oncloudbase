using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using oncloud.Domain.Concrete;
using oncloud.Domain.Entities;
using oncloud.Domain.DAL;
using oncloud.Domain.Abstract;

namespace oncloud.Web.oddBase.Controllers
{
    public class StreetsController : Controller
    {
        private readonly DataBaseSets db;
        private class DataBaseSets : DataSets
        {
            internal DataBaseSets(IUnitOfWork uow) : base(uow) { }
            public IDbSet<Street> Streets { get { return _uow.Set<Street>(); } }
            public IDbSet<City> Cities { get { return _uow.Set<City>(); } }
        }

        private readonly IUnitOfWork _unitOfWork;


        public StreetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            db = new DataBaseSets(_unitOfWork);
        }

        // GET: Streets
        public ActionResult Index()
        {
            var streets = db.Streets.Include(s => s.City);
            return View(streets.ToList());
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            ViewBag.City_id = new SelectList(db.Cities, "id", "Name");
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,BreadthS,LengthS,BreadthE,LengthE,City_id,UniqueNumber")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Streets.Add(street);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City_id = new SelectList(db.Cities, "id", "Name", street.City_id);
            return View(street);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            ViewBag.City_id = new SelectList(db.Cities, "id", "Name", street.City_id);
            return View(street);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,BreadthS,LengthS,BreadthE,LengthE,City_id,UniqueNumber")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.SetEntryModified(street);
                //db.Entry(street).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City_id = new SelectList(db.Cities, "id", "Name", street.City_id);
            return View(street);
        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Street street = db.Streets.Find(id);
            db.Streets.Remove(street);
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
