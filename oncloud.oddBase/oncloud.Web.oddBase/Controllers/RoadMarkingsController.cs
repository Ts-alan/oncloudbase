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
using oncloud.Domain.Abstract;
using oncloud.Domain.DAL;

namespace oncloud.Web.oddBase.Controllers
{
    public class RoadMarkingController : Controller
    {
        private readonly DataBaseSets db;
        private class DataBaseSets : DataSets
        {
            internal DataBaseSets(IUnitOfWork uow) : base(uow) { }
            public IDbSet<RoadMarking> RoadMarkings { get { return _uow.Set<RoadMarking>(); } }
        }

        private readonly IUnitOfWork _unitOfWork;


        public RoadMarkingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            db = new DataBaseSets(_unitOfWork);
        }
        // GET: HorizontalRoadMarkings
        public ActionResult Index()
        {
            return View(db.RoadMarkings.ToList());
        }

        // GET: HorizontalRoadMarkings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadMarking RoadMarking = db.RoadMarkings.Find(id);
            if (RoadMarking == null)
            {
                return HttpNotFound();
            }
            return View(RoadMarking);
        }

        // GET: HorizontalRoadMarkings/Create
        public ActionResult Create()
        {
            return View(new RoadMarking());
        }

        // POST: HorizontalRoadMarkings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NumberMarking,description")] RoadMarking RoadMarking, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    RoadMarking.ImageMimeType = image.ContentType;
                    RoadMarking.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(RoadMarking.ImageData, 0, image.ContentLength);
                }
                db.RoadMarkings.Add(RoadMarking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(RoadMarking);
        }

        // GET: HorizontalRoadMarkings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadMarking RoadMarking = db.RoadMarkings.Find(id);
            if (RoadMarking == null)
            {
                return HttpNotFound();
            }
            return View(RoadMarking);
        }

        // POST: HorizontalRoadMarkings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NumberMarking,description")] RoadMarking RoadMarking, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                RoadMarking RoadMarking_original = db.RoadMarkings.Find(RoadMarking.id);
                if (image != null)
                {
                    RoadMarking_original.ImageMimeType = image.ContentType;
                    RoadMarking_original.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(RoadMarking_original.ImageData, 0, image.ContentLength);
                }
                //db.SetEntryModified(RoadMarking);
                RoadMarking_original.NumberMarking = RoadMarking.NumberMarking;
                RoadMarking_original.description = RoadMarking.description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(RoadMarking);
        }

        // GET: HorizontalRoadMarkings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadMarking RoadMarking = db.RoadMarkings.Find(id);
            if (RoadMarking == null)
            {
                return HttpNotFound();
            }
            return View(RoadMarking);
        }

        // POST: HorizontalRoadMarkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoadMarking RoadMarking = db.RoadMarkings.Find(id);
            db.RoadMarkings.Remove(RoadMarking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            RoadMarking RoadMarking = db.RoadMarkings.Find(id);

            if (RoadMarking != null)
            {
                return File(RoadMarking.ImageData, RoadMarking.ImageMimeType);
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
