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
    [Authorize(Roles = "admin")]
    public class RoadBarriersController : Controller
    {
        private readonly DataBaseSets db;
        private class DataBaseSets : DataSets
        {
            internal DataBaseSets(IUnitOfWork uow) : base(uow) { }
            public IDbSet<RoadBarriers> RoadBarriers { get { return _uow.Set<RoadBarriers>(); } }
        }

        private readonly IUnitOfWork _unitOfWork;


        public RoadBarriersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            db = new DataBaseSets(_unitOfWork);
        }

        // GET: RoadBarriers
        public ActionResult Index()
        {
            return View(db.RoadBarriers.ToList());
        }

        // GET: RoadBarriers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadBarriers roadBarriers = db.RoadBarriers.Find(id);
            if (roadBarriers == null)
            {
                return HttpNotFound();
            }
            return View(roadBarriers);
        }

        // GET: RoadBarriers/Create
        public ActionResult Create()
        {
            return View(new RoadBarriers());
        }

        // POST: RoadBarriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NumberBarriers,Description,ImageData,ImageMimeType")] RoadBarriers roadBarriers, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    roadBarriers.ImageMimeType = image.ContentType;
                    roadBarriers.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(roadBarriers.ImageData, 0, image.ContentLength);
                }
                db.RoadBarriers.Add(roadBarriers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roadBarriers);
        }

        // GET: RoadBarriers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadBarriers roadBarriers = db.RoadBarriers.Find(id);
            if (roadBarriers == null)
            {
                return HttpNotFound();
            }
            return View(roadBarriers);
        }

        // POST: RoadBarriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NumberBarriers,Description,ImageData,ImageMimeType")] RoadBarriers roadBarriers, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var original_ = db.RoadBarriers.Find(roadBarriers.id);
                if (image != null)
                {
                    original_.ImageMimeType = image.ContentType;
                    original_.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(original_.ImageData, 0, image.ContentLength);
                }
                //db.SetEntryModified(roadBarriers);
                //db.Entry(roadSigns).State = EntityState.Modified;
                original_.NumberBarriers = roadBarriers.NumberBarriers;
                original_.Description = roadBarriers.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roadBarriers);
        }

        // GET: RoadBarriers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadBarriers roadBarriers = db.RoadBarriers.Find(id);
            if (roadBarriers == null)
            {
                return HttpNotFound();
            }
            return View(roadBarriers);
        }

        // POST: RoadBarriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoadBarriers roadBarriers = db.RoadBarriers.Find(id);
            db.RoadBarriers.Remove(roadBarriers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            RoadBarriers roadBarriers = db.RoadBarriers.Find(id);

            if (roadBarriers != null)
            {
                return File(roadBarriers.ImageData, roadBarriers.ImageMimeType);
            }
            else
            {
                return null;
            }
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
