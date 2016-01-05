using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using oncloud.Domain.Concrete;
using oncloud.Domain.Entities;
using oncloud.Web.oddBase.Models;
using oncloud.Web.oddBase.Models.Home;
using OddBasyBY.Models;
using WebGrease.Css.Extensions;

namespace oncloud.Web.oddBase.Controllers
{
   
    public partial class HomeController : Controller
    {
        private EFDbContext db = new EFDbContext();

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Table()
        {
            Table data = new Table();
            data.Setinitialization(db);
            return View(data.GetDataModel);
        }
        [Authorize(Roles = "admin,SetMembers,EditData")]
        public virtual ActionResult SaveSuccess(City city, Street street,IEnumerable<int> LayoutDislocationDelete,
            [ModelBinder(typeof(CustomModelBinderForSegment))] ICollection<Segment> segment,
            [ModelBinder(typeof(CustomModelBinderForRM))] ICollection<SpecificationofRM> SpecificationofRM,
            [ModelBinder(typeof(CustomModelBinderForRS))] ICollection<SpecificationofRS> SpecificationofRS,
            [ModelBinder(typeof(CustomModelBinderForRB))] ICollection<SpecificationOfRb> SpecificationofRB,
            HttpPostedFileBase layoutScheme = null, [ModelBinder(typeof(CustomModelBinderForlayoutDislocation))] List<ModelLayoutDislocation> layoutDislocation = null)
        {
            int LastIndexSegment;
            if (db.Segment.Any())
            {
                LastIndexSegment = db.Segment.AsEnumerable().Last().id;
            }
            else
            {
                LastIndexSegment = 0;
            }
            var streetInfo = new Street()
            {
                Name = street.Name,
                BreadthS = street.BreadthS,
                BreadthE = street.BreadthE,
                LengthE = street.LengthE,
                LengthS = street.LengthS,
                City_id = city.id,
                UniqueNumber = TableAdapterExtensions.StringSymvol()
            };

            db.Street.Add(streetInfo);
            AjaxMinExtensions.ForEach(segment.GroupBy(a => a.Name), a => AjaxMinExtensions.ForEach(a, b => b.id = ++LastIndexSegment));
            streetInfo.Segment = segment;
            streetInfo.SpecificationofRM = SpecificationofRM;
            foreach (var instance in SpecificationofRM)
            {
                if (db.TheHorizontalRoadMarking.Any(a => a.NumberMarking == instance.TheHorizontalRoadMarkingIdModel))
                {
                    try
                    {
                        instance.TheHorizontalRoadMarkingId =
                            db.TheHorizontalRoadMarking.Single(
                                a => a.NumberMarking == instance.TheHorizontalRoadMarkingIdModel).id;
                    }
                    catch
                    {
                    }
                }
            }

            db.Segment.AddRange(segment);


            if (layoutScheme != null)
            {
                layoutScheme imageScheme = new layoutScheme();
                imageScheme.ImageMimeType = layoutScheme.ContentType;
                imageScheme.ImageData = new byte[layoutScheme.ContentLength];
                imageScheme.Id = streetInfo.id;
                layoutScheme.InputStream.Read(imageScheme.ImageData, 0, layoutScheme.ContentLength);
                db.layoutSchemes.Add(imageScheme);
            }

            AjaxMinExtensions.ForEach(SpecificationofRS, a =>
            {
                a.RoadSignsId =
                    db.RoadSigns.Single(b => b.NumberRoadSigns == a.RoadSignsIdModel).id;
                a.SegmentId = segment.Single(c => c.Name == a.SegmentIdModel).id;
                a.Street_id = streetInfo.id;

            });
            if (layoutDislocation != null)
            {
                List<layoutDislocation> imageDislocations = new List<layoutDislocation>();
                layoutDislocation imageDislocation;
                layoutDislocation.ForEach(a =>
                {
                    imageDislocation = new layoutDislocation();
                    imageDislocation.ImageMimeType = a.File.ContentType;
                    imageDislocation.ImageData = new byte[a.File.ContentLength];
                    a.File.InputStream.Read(imageDislocation.ImageData, 0, a.File.ContentLength);
                    imageDislocation.StreetId = streetInfo.id;
                    imageDislocation.SegmentId = segment.Single(c => c.Name == a.SegmentId).id;
                    imageDislocations.Add(imageDislocation);
                }
                    );
                db.layoutDislocations.AddRange(imageDislocations);
            }
            AjaxMinExtensions.ForEach(SpecificationofRB, a =>
            {
                a.RoadBarriersId =
                    db.RoadBarriers.Single(b => b.NumberBarriers == a.RoadBarriersIdModel).Id;
                a.SegmentId = segment.Single(c => c.Name == a.SegmentIdModel).id;
                a.StreetId = streetInfo.id;

            });
            db.SpecificationOfRb.AddRange(SpecificationofRB);
            db.SpecificationofRM.AddRange(SpecificationofRM);
            db.SpecificationofRS.AddRange(SpecificationofRS);
            db.SaveChanges();
            return RedirectToAction("Table");
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles = "admin,SetMembers,EditData")]
        public virtual ActionResult AddStreet()
        {
            ViewBag.City = db.City.First();

            ViewBag.RoadMarking = db.TheHorizontalRoadMarking.ToList().OrderBy(a =>
            {
                if (a.NumberMarking.Substring(2).LastIndexOf(".") == -1)
                {
                    return int.Parse(a.NumberMarking.Substring(2).Replace(".", ","));
                }
                else
                {
                    return int.Parse(a.NumberMarking.Substring(2, a.NumberMarking.Substring(2).LastIndexOf("."))
                        .Replace(".", ","));
                }
            });
            ViewBag.RoadSigns = db.RoadSigns.ToList();
            ViewBag.RoadBarriers = db.RoadBarriers.ToList();
            return View();
        }
        [Authorize(Roles = "admin,SetMembers,EditData")]
        public void DeleteDataStreet(int id,bool isEdit)
        {
            Street street = db.Street.Find(id);
            if (street.layoutScheme != null)
                db.layoutSchemes.Remove(street.layoutScheme);

            if (street.layoutDislocation != null)
                db.layoutDislocations.RemoveRange(street.layoutDislocation);

            if (street.SpecificationofRM != null)
                db.SpecificationofRM.RemoveRange(street.SpecificationofRM);

            if (street.SpecificationOfRb != null)
                db.SpecificationOfRb.RemoveRange(street.SpecificationOfRb);

            if (street.Segment != null)
                db.Segment.RemoveRange(street.Segment);

            if (street.SpecificationofRS != null)
                db.SpecificationofRS.RemoveRange(street.SpecificationofRS);
            if(isEdit==false)
            db.ListUniqueNumber.Add(new ListUniqueNumber() { UniqueNumber = street.UniqueNumber });
            db.Street.Remove(street);
            db.SaveChanges();
        }
        [Authorize(Roles = "admin,SetMembers,EditData")]
        public virtual ActionResult DeleteStreet(int id)
        {
            DeleteDataStreet(id,false);
            return RedirectToAction("Table");
        }
        [HttpGet]
        [Authorize(Roles = "admin,SetMembers,EditData")]
        public virtual ActionResult EditStreets(int id)
        {
            Street street = db.Street.Find(id);

            Session["idStreet"] = street.id;

            ViewBag.RoadMarking = db.TheHorizontalRoadMarking.ToList().OrderBy(a =>
            {
                if (a.NumberMarking.Substring(2).LastIndexOf(".") == -1)
                {
                    return int.Parse(a.NumberMarking.Substring(2).Replace(".", ","));
                }
                else
                {
                    return int.Parse(a.NumberMarking.Substring(2, a.NumberMarking.Substring(2).LastIndexOf("."))
                        .Replace(".", ","));
                }
            });
            ViewBag.RoadSigns = db.RoadSigns.ToList();

            ViewBag.layoutDislocation = db.layoutDislocations.Where(a => a.StreetId == id).Select(a => a.Segment.Name).ToList();

            ViewBag.layoutScheme = db.layoutSchemes.SingleOrDefault(a => a.Id == id);

            ViewBag.RoadBarriers = db.RoadBarriers.ToList();
            return View(street);
        }
        [HttpPost]
        [Authorize(Roles = "admin,SetMembers,EditData")]
        public virtual ActionResult EditStreets(
            City city, Street street, IEnumerable<int> LayoutDislocationDelete,
            [ModelBinder(typeof(CustomModelBinderForSegment))] ICollection<Segment> segment,
            [ModelBinder(typeof(CustomModelBinderForRM))] ICollection<SpecificationofRM> SpecificationofRM,
            [ModelBinder(typeof(CustomModelBinderForRS))] ICollection<SpecificationofRS> SpecificationofRS,
            [ModelBinder(typeof(CustomModelBinderForRB))] ICollection<SpecificationOfRb> SpecificationofRB,
            HttpPostedFileBase layoutScheme = null, [ModelBinder(typeof(CustomModelBinderForlayoutDislocation))] List<ModelLayoutDislocation> layoutDislocation = null)
        {

            int LastIndexSegment = street.id;
            Street streetForUniqueNumber = db.Street.Find(street.id);
            var streetInfo = new Street()
            {
                Name = street.Name,
                BreadthS = street.BreadthS,
                BreadthE = street.BreadthE,
                LengthE = street.LengthE,
                LengthS = street.LengthS,
                City_id = city.id,
                UniqueNumber = streetForUniqueNumber.UniqueNumber
            };
            List<layoutDislocation> OldLayoutDislocation =
             db.layoutDislocations.Include("Segment").AsEnumerable().Where(a => a.StreetId == streetForUniqueNumber.id).
             Select(a => new layoutDislocation()
             {
                 Id = a.Id,
                 ImageData = a.ImageData,
                 ImageMimeType = a.ImageMimeType,
                 SegmentName = a.Segment.Name
             }).ToList();
            if (LayoutDislocationDelete != null)
            {
                foreach (var item in OldLayoutDislocation.ToList())
                {
                    if (!LayoutDislocationDelete.Contains(item.SegmentName))
                    {
                        OldLayoutDislocation.Remove(item);
                    }
                }
            }
            layoutScheme OdllayoutScheme =
                db.layoutSchemes.Include("Street").AsEnumerable().SingleOrDefault(a => a.Id == streetForUniqueNumber.id);

            DeleteDataStreet(street.id, true);

            if (OdllayoutScheme != null)
            {
                OdllayoutScheme.Id = streetInfo.id;
                OdllayoutScheme.Street = null;
            }
            var newstreet = db.Street.Add(streetInfo);
            db.SaveChanges();

            if (OdllayoutScheme != null)
                OdllayoutScheme.Id = newstreet.id;

            AjaxMinExtensions.ForEach(segment.GroupBy(a => a.Name), a => AjaxMinExtensions.ForEach(a, b =>
            {
                b.id = ++LastIndexSegment;
                b.Street_id = newstreet.id;
            }));

            SpecificationofRM.ToList().ForEach(a => a.StreetId = newstreet.id);
            var newsegment = db.Segment.AddRange(segment);

            foreach (var instance in SpecificationofRM)
            {
                if (db.TheHorizontalRoadMarking.Any(a => a.NumberMarking == instance.TheHorizontalRoadMarkingIdModel))
                {
                    try
                    {
                        instance.TheHorizontalRoadMarkingId =
                            db.TheHorizontalRoadMarking.Single(
                                a => a.NumberMarking == instance.TheHorizontalRoadMarkingIdModel).id;
                    }
                    catch
                    {
                    }
                }
            }


            if (layoutScheme != null)
            {
                layoutScheme imageScheme = new layoutScheme();
                imageScheme.ImageMimeType = layoutScheme.ContentType;
                imageScheme.ImageData = new byte[layoutScheme.ContentLength];
                imageScheme.Id = newstreet.id;
                layoutScheme.InputStream.Read(imageScheme.ImageData, 0, layoutScheme.ContentLength);
                db.layoutSchemes.Add(imageScheme);
            }
            else
            {
                if (OdllayoutScheme != null)
                {
                    db.layoutSchemes.Add(OdllayoutScheme);
                }
            }


            List<layoutDislocation> imageDislocations = new List<layoutDislocation>();
            layoutDislocation imageDislocation;

            if (layoutDislocation.Count != 0 || OldLayoutDislocation.Count != 0)
            {

                if (OldLayoutDislocation.Count != 0)
                {
                    foreach (var item in OldLayoutDislocation)
                    {

                        if (layoutDislocation.Count != 0 && layoutDislocation.Any(a => a.SegmentId != item.SegmentName))
                        {
                            item.StreetId = streetInfo.id;
                            item.SegmentId = segment.Single(c => c.Name == item.SegmentName).id;
                            imageDislocations.Add(item);

                        }

                    }
                }
                if (layoutDislocation.Count != 0)
                {
                    layoutDislocation.ForEach(a =>
                    {
                        imageDislocation = new layoutDislocation();
                        imageDislocation.ImageMimeType = a.File.ContentType;
                        imageDislocation.ImageData = new byte[a.File.ContentLength];
                        a.File.InputStream.Read(imageDislocation.ImageData, 0, a.File.ContentLength);
                        imageDislocation.StreetId = streetInfo.id;
                        imageDislocation.SegmentId = segment.Single(c => c.Name == a.SegmentId).id;
                        imageDislocations.Add(imageDislocation);
                    }
                        );
                }
                else
                {
                    if (OldLayoutDislocation.Count != 0)
                    {
                        foreach (var item in OldLayoutDislocation)
                        {
                            item.StreetId = streetInfo.id;
                            item.SegmentId = segment.Single(c => c.Name == item.SegmentName).id;
                            imageDislocations.Add(item);

                        }
                    }
                }

            }
            db.layoutDislocations.AddRange(imageDislocations);

            AjaxMinExtensions.ForEach(SpecificationofRB, a =>
            {
                a.RoadBarriersId =
                    db.RoadBarriers.Single(b => b.NumberBarriers == a.RoadBarriersIdModel).Id;
                a.SegmentId = segment.Single(c => c.Name == a.SegmentIdModel).id;
                a.StreetId = streetInfo.id;

            });
            AjaxMinExtensions.ForEach(SpecificationofRS, a =>
            {
                a.RoadSignsId =
                    db.RoadSigns.Single(b => b.NumberRoadSigns == a.RoadSignsIdModel).id;
                a.SegmentId = newsegment.Single(c => c.Name == a.SegmentIdModel).id;
                a.Street_id = streetInfo.id;

            });
            db.SpecificationOfRb.AddRange(SpecificationofRB);

            db.SpecificationofRM.AddRange(SpecificationofRM);

            db.SpecificationofRS.AddRange(SpecificationofRS);

            db.SaveChanges();

            return RedirectToAction("Table");
        }

        public virtual ActionResult Review(int id)
        {

            Street street = db.Street.Find(id);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var segments = street.Segment.ToList().Select(s => new
            {
                segmentName = s.Name,
                segmentChange = s.ChangeDislocationTCODD,
                segmentString = s.string120Symbol
            });
            ViewBag.jsonStreet = js.Serialize(segments);
            ViewBag.layoutDislocation = db.layoutDislocations.Where(a => a.StreetId == id).Select(a => a.Segment.Name).ToList();
            return View(street);
        }
        public virtual ActionResult FindStreets(string term)
        {
            var streets = from m in db.IntelliSenseStreet where m.Street.Contains(term) select m;
            var projection = from street in streets
                             select new
                             {
                                 id = street.id,
                                 label = street.Street + " " + street.Type,
                                 value = street.Street + " " + street.Type
                             };
            return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
        }
        public virtual ActionResult FindFilledStreets(string term)
        {
            var streets = from m in db.Street where m.Name.Contains(term) select m;
            var projection = from street in streets
                             select new
                             {
                                 label = street.Name,
                                 value = street.Name
                             };
            return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
        }
        public virtual FileContentResult GetImageLayoutScheme(int id)
        {
            layoutScheme LayoutScheme = db.layoutSchemes.Find(id);

            if (LayoutScheme != null)
            {
                return File(LayoutScheme.ImageData, LayoutScheme.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public virtual FileContentResult LayoutDislocation(int id)
        {
            layoutDislocation layoutDislocation = db.layoutDislocations.Find(id);

            if (layoutDislocation != null)
            {
                return File(layoutDislocation.ImageData, layoutDislocation.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


        public virtual ActionResult ShowOnMap()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            var idQuery = from st in db.Street
                          join se in db.Segment on st.id equals se.Street_id into group1
                          from g1 in group1.DefaultIfEmpty()
                          join ld in db.layoutDislocations on g1.id equals ld.SegmentId into group2
                          from g2 in group2.DefaultIfEmpty()
                          select new
                          {
                              segmentId = g1.id,
                              streetId = st.id,
                              layoutdisId = (int?)g2.Id,
                              streetName = g1.Street.Name
                          };

            ViewBag.streestDislocationsListJSON = js.Serialize(idQuery);

            ViewBag.coordsJson = js.Serialize(db.Street.OrderBy(o=>o.id).ToList().Select(x => new
            {
                name = x.Name,
                breadthE = x.BreadthE,
                breadthS = x.BreadthS,
                lengthE = x.LengthE,
                lengthS = x.LengthS,
                Id = x.id,
                segmentCount = x.Segment.Count,
                cityName = x.City.Name
            }));

            return View();
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