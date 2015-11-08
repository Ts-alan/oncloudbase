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
            //public IDbSet<RoadSignItem> RoadSignItems { get { return _uow.Set<RoadSignItem>(); } }
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
            return View(db.RoadSigns
                //.Include(rs=>rs.RoadSignItems)
                .ToList());
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


        public virtual ActionResult CreateItem(int id)
        {
            RoadSigns roadSign = db.RoadSigns.Find(id);
            return View(new RoadSignItem() { Id = id, RoadSign = roadSign });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreateItem([Bind(Include = "Id, Hallmark, Description,ImageData,ImageMimeType")] RoadSignItem roadSignItem, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    roadSignItem.ImageMimeType = image.ContentType;
                    roadSignItem.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(roadSignItem.ImageData, 0, image.ContentLength);
                }
                //db.RoadSignItems.Add(roadSignItem);
                RoadSigns roadSign = db.RoadSigns.Find(roadSignItem.Id);
                roadSign.RoadSignItems.Add(roadSignItem);
                db.SetEntryModified(roadSign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roadSignItem);
        }

        public virtual ActionResult EditItem(int? id, string hallmark = null)
        {
            if (id == null || string.IsNullOrEmpty(hallmark))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadSigns roadSigns = db.RoadSigns.Find(id);
            if (roadSigns == null)
            {
                return HttpNotFound();
            }

            RoadSignItem roadSignItem = roadSigns.RoadSignItems.SingleOrDefault(i => i.Hallmark == hallmark);
            if (roadSignItem == null)
            {
                return HttpNotFound();
            }
            return View(roadSignItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditItem([Bind(Include = "id,Hallmark,Description,ImageData,ImageMimeType")] RoadSignItem roadSignItem, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var original_roadSignItem = db.RoadSigns.Find(roadSignItem.Id).RoadSignItems.SingleOrDefault(i=>i.Hallmark == roadSignItem.Hallmark);
                if (image != null)
                {
                    original_roadSignItem.ImageMimeType = image.ContentType;
                    original_roadSignItem.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(original_roadSignItem.ImageData, 0, image.ContentLength);
                }
                //db.SetEntryModified(roadSigns);
                //db.Entry(roadSigns).State = EntityState.Modified;
                original_roadSignItem.Description = roadSignItem.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roadSignItem);
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
                    roadSigns.ImageMimeType = image.ContentType;
                    roadSigns.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(roadSigns.ImageData, 0, image.ContentLength);
                }
                db.RoadSigns.Add(roadSigns);
                db.SaveChanges();
                return RedirectToAction(MVC.RoadSigns.Details(roadSigns.id));
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
                    original_roadSign.ImageMimeType = image.ContentType;
                    original_roadSign.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(original_roadSign.ImageData, 0, image.ContentLength);
                }
                //db.SetEntryModified(roadSigns);
                //db.Entry(roadSigns).State = EntityState.Modified;
                original_roadSign.NumberRoadSigns = roadSigns.NumberRoadSigns;
                original_roadSign.Description = roadSigns.Description;
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

        public virtual ActionResult DeleteItem(int? id, string hallmark)
        {
            if (id == null || string.IsNullOrEmpty(hallmark))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoadSigns roadSigns = db.RoadSigns.Find(id);
            if (roadSigns == null)
            {
                return HttpNotFound();
            }

            RoadSignItem roadSignItem = roadSigns.RoadSignItems.SingleOrDefault(i => i.Hallmark == hallmark);
            if (roadSignItem == null)
            {
                return HttpNotFound();
            }
            return View(roadSignItem);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id, string hallmark)
        {
            RoadSigns roadSign = db.RoadSigns.Find(id);
            RoadSignItem roadSignItem = roadSign.RoadSignItems.SingleOrDefault(i => i.Hallmark == hallmark);
            roadSign.RoadSignItems.Remove(roadSignItem);
            db.SetEntryModified(roadSign);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual FileContentResult GetImage(int id)
        {
            //return null;
            RoadSigns roadSigns = db.RoadSigns.Find(id);

            if (roadSigns != null)
            {
                return File(roadSigns.ImageData, roadSigns.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public virtual FileContentResult GetItemImage(int id, string hallmark)
        {
            RoadSigns roadSigns = db.RoadSigns.Find(id);

            if (roadSigns != null)
            {
                RoadSignItem rsi = roadSigns.RoadSignItems.SingleOrDefault(i => i.Hallmark == hallmark);
                if (rsi != null)
                {
                    return File(rsi.ImageData, rsi.ImageMimeType);
                }

            }
            
            return null;
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
