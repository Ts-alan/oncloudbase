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
    public partial class RoadSignsController : Controller
    {
        private readonly DataBaseSets db;
        private class DataBaseSets : DataSets
        {
            internal DataBaseSets(IUnitOfWork uow) : base(uow) { }
            public IDbSet<RoadSigns> RoadSigns { get { return _uow.Set<RoadSigns>(); } }
        }

        private readonly IUnitOfWork _unitOfWork;


        public RoadSignsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            db = new DataBaseSets(_unitOfWork);
        }

        // GET: RoadSigns
        public virtual ActionResult Index()
        {
            return View(db.RoadSigns.ToList());
        }

        // GET: RoadSigns/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadSigns roadSigns = db.RoadSigns.Find(id);
            if (roadSigns == null)
            {
                return HttpNotFound();
            }
            return View(roadSigns);
        }

        // GET: RoadSigns/Create
        public virtual ActionResult Create()
        {
            return View(new RoadSigns());
        }

        // POST: RoadSigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "id,NumberRoadSigns,Description,ImageData,ImageMimeType")] RoadSigns roadSigns, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //roadSigns.ImageMimeType = image.ContentType;
                    //roadSigns.ImageData = new byte[image.ContentLength];
                    //image.InputStream.Read(roadSigns.ImageData, 0, image.ContentLength);
                }
                db.RoadSigns.Add(roadSigns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roadSigns);
        }

        // GET: RoadSigns/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadSigns roadSigns = db.RoadSigns.Find(id);
            if (roadSigns == null)
            {
                return HttpNotFound();
            }
            return View(roadSigns);
        }

        // POST: RoadSigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "id,NumberRoadSigns,Description,ImageData,ImageMimeType")] RoadSigns roadSigns, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var original_roadSign = db.RoadSigns.Find(roadSigns.id); 
                if (image != null)
                {
                    //original_roadSign.ImageMimeType = image.ContentType;
                    //original_roadSign.ImageData = new byte[image.ContentLength];
                    //image.InputStream.Read(original_roadSign.ImageData, 0, image.ContentLength);
                }
                //db.SetEntryModified(roadSigns);
                //db.Entry(roadSigns).State = EntityState.Modified;
                original_roadSign.NumberRoadSigns = roadSigns.NumberRoadSigns;
                //original_roadSign.Description = roadSigns.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roadSigns);
        }

        // GET: RoadSigns/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadSigns roadSigns = db.RoadSigns.Find(id);
            if (roadSigns == null)
            {
                return HttpNotFound();
            }
            return View(roadSigns);
        }

        // POST: RoadSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            RoadSigns roadSigns = db.RoadSigns.Find(id);
            db.RoadSigns.Remove(roadSigns);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual FileContentResult GetImage(int id)
        {
            RoadSigns roadSigns = db.RoadSigns.Find(id);

            if (roadSigns != null)
            {
                //return File(roadSigns.ImageData, roadSigns.ImageMimeType);
                return null;
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
