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
    public class HorizontalRoadMarkingsController : Controller
    {
        private readonly DataBaseSets db;
        private class DataBaseSets : DataSets
        {
            internal DataBaseSets(IUnitOfWork uow) : base(uow) { }
            public IDbSet<TheHorizontalRoadMarking> TheHorizontalRoadMarkings { get { return _uow.Set<TheHorizontalRoadMarking>(); } }
        }

        private readonly IUnitOfWork _unitOfWork;


        public HorizontalRoadMarkingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            db = new DataBaseSets(_unitOfWork);
        }
        // GET: HorizontalRoadMarkings
        public ActionResult Index()
        {
            return View(db.TheHorizontalRoadMarkings.ToList());
        }

        // GET: HorizontalRoadMarkings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheHorizontalRoadMarking theHorizontalRoadMarking = db.TheHorizontalRoadMarkings.Find(id);
            if (theHorizontalRoadMarking == null)
            {
                return HttpNotFound();
            }
            return View(theHorizontalRoadMarking);
        }

        // GET: HorizontalRoadMarkings/Create
        public ActionResult Create()
        {
            return View(new TheHorizontalRoadMarking());
        }

        // POST: HorizontalRoadMarkings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NumberMarking,description")] TheHorizontalRoadMarking theHorizontalRoadMarking, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    theHorizontalRoadMarking.ImageMimeType = image.ContentType;
                    theHorizontalRoadMarking.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(theHorizontalRoadMarking.ImageData, 0, image.ContentLength);
                }
                db.TheHorizontalRoadMarkings.Add(theHorizontalRoadMarking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theHorizontalRoadMarking);
        }

        // GET: HorizontalRoadMarkings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheHorizontalRoadMarking theHorizontalRoadMarking = db.TheHorizontalRoadMarkings.Find(id);
            if (theHorizontalRoadMarking == null)
            {
                return HttpNotFound();
            }
            return View(theHorizontalRoadMarking);
        }

        // POST: HorizontalRoadMarkings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NumberMarking,description")] TheHorizontalRoadMarking theHorizontalRoadMarking, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    theHorizontalRoadMarking.ImageMimeType = image.ContentType;
                    theHorizontalRoadMarking.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(theHorizontalRoadMarking.ImageData, 0, image.ContentLength);
                }
                db.SetEntryModified(theHorizontalRoadMarking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theHorizontalRoadMarking);
        }

        // GET: HorizontalRoadMarkings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheHorizontalRoadMarking theHorizontalRoadMarking = db.TheHorizontalRoadMarkings.Find(id);
            if (theHorizontalRoadMarking == null)
            {
                return HttpNotFound();
            }
            return View(theHorizontalRoadMarking);
        }

        // POST: HorizontalRoadMarkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheHorizontalRoadMarking theHorizontalRoadMarking = db.TheHorizontalRoadMarkings.Find(id);
            db.TheHorizontalRoadMarkings.Remove(theHorizontalRoadMarking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            TheHorizontalRoadMarking theHorizontalRoadMarking = db.TheHorizontalRoadMarkings.Find(id);

            if (theHorizontalRoadMarking != null)
            {
                return File(theHorizontalRoadMarking.ImageData, theHorizontalRoadMarking.ImageMimeType);
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
