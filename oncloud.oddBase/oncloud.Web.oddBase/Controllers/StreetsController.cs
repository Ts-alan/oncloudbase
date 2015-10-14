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
using Ninject;
using oncloud.Domain.DAL;
using oncloud.Domain.Abstract;

namespace oncloud.Web.oddBase.Controllers
{
    public class StreetsController : Controller
    {
        private readonly DataBaseSets db;
        private class DataBaseSets
        {
            private IUnitOfWork _uow;
            internal DataBaseSets(IUnitOfWork uow) { _uow = uow; }
            public IDbSet<Street> Streets { get { return _uow.Set<Street>(); } }
            public int SaveChanges()
            {
                return _uow.SubmitChanges();
            }
        }

        private readonly IUnitOfWork _unitOfWork;
        

        public  StreetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            db = new DataBaseSets(_unitOfWork);
        }

        // GET: Streets
        public ActionResult Index()
        {
            var streets = db.Streets.ToList();
            return View(streets);
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Street street = db.Streets.Find(id);
            Street street = _unitOfWork.Set<Street>().Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "StreetId,Caption,StartPointLongitude,StartPointLatitude,EndPointLongitude,EndPointLatitude")] Street street)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        unitOfWork.StreetsRepository.Insert(street);
        //        unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }

        //    return View(street);
        //}

        //// GET: Streets/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Street street = unitOfWork.StreetsRepository.GetByID(id);
        //    if (street == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(street);
        //}

        //// POST: Streets/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "StreetId,Caption,StartPointLongitude,StartPointLatitude,EndPointLongitude,EndPointLatitude")] Street street)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        unitOfWork.StreetsRepository.Update(street);
        //        unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(street);
        //}

        //// GET: Streets/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Street street = unitOfWork.StreetsRepository.GetByID(id);
        //    if (street == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(street);
        //}

        //// POST: Streets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    unitOfWork.StreetsRepository.Delete(id);
        //    unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (_unitOfWork is IDisposable)
            {
                ((IDisposable)_unitOfWork).Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
