﻿using System;
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
    [Authorize(Roles = "admin")]
    public partial class StreetsController : Controller
    {
        private readonly DataBaseSets db;
        private class DataBaseSets : DataSets
        {
            internal DataBaseSets(IUnitOfWork uow) : base(uow) { }
            public IDbSet<IntelliSenseStreet> IntelliSenseStreets { get { return _uow.Set<IntelliSenseStreet>(); } }
            public IDbSet<City> Cities { get { return _uow.Set<City>(); } }
        }

        private readonly IUnitOfWork _unitOfWork;


        public StreetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            db = new DataBaseSets(_unitOfWork);
        }

        // GET: Streets
        public virtual ActionResult Index()
        {
            return View(db.IntelliSenseStreets.Include(a=>a.City).ToList());
        }

        // GET: Streets/Details/5
        public virtual ActionResult Details(int? id, string street)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id, street);
            if (intelliSenseStreet == null)
            {
                return HttpNotFound();
            }
            return View(intelliSenseStreet);
        }

        // GET: Streets/Create
        public virtual ActionResult Create()
        {
            ViewBag.Cities = new SelectList(db.Cities, "id", "Name");
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "id,Street,Type, CityId")] IntelliSenseStreet intelliSenseStreet)
        {
            if (ModelState.IsValid)
            {
                db.IntelliSenseStreets.Add(intelliSenseStreet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cities = new SelectList(db.Cities, "id", "Name");
            return View(intelliSenseStreet);
        }

        // GET: Streets/Edit/5
        public virtual ActionResult Edit(int? id, string street)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id, street);
            if (intelliSenseStreet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cities = new SelectList(db.Cities, "id", "Name");
            return View(intelliSenseStreet);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "id,Street,Type, CityId")] IntelliSenseStreet intelliSenseStreet)
        {
            if (ModelState.IsValid)
            {
                db.SetEntryModified(intelliSenseStreet);
                //db.Entry(intelliSenseStreet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cities = new SelectList(db.Cities, "id", "Name");
            return View(intelliSenseStreet);
        }

        // GET: Streets/Delete/5
        public virtual ActionResult Delete(int? id, string street)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id, street);
            if (intelliSenseStreet == null)
            {
                return HttpNotFound();
            }
            return View(intelliSenseStreet);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id, string street)
        {
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id, street);
            db.IntelliSenseStreets.Remove(intelliSenseStreet);
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
