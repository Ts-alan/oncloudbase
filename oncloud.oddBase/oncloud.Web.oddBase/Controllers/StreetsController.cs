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
            public IDbSet<IntelliSenseStreet> IntelliSenseStreets { get { return _uow.Set<IntelliSenseStreet>(); } }
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
            return View(db.IntelliSenseStreets.ToList());
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id);
            if (intelliSenseStreet == null)
            {
                return HttpNotFound();
            }
            return View(intelliSenseStreet);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Street,Type")] IntelliSenseStreet intelliSenseStreet)
        {
            if (ModelState.IsValid)
            {
                db.IntelliSenseStreets.Add(intelliSenseStreet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(intelliSenseStreet);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id);
            if (intelliSenseStreet == null)
            {
                return HttpNotFound();
            }
            return View(intelliSenseStreet);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Street,Type")] IntelliSenseStreet intelliSenseStreet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intelliSenseStreet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(intelliSenseStreet);
        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id);
            if (intelliSenseStreet == null)
            {
                return HttpNotFound();
            }
            return View(intelliSenseStreet);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IntelliSenseStreet intelliSenseStreet = db.IntelliSenseStreets.Find(id);
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
