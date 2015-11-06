﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using oncloud.Domain.Concrete;
using oncloud.Domain.Entities;
using oncloud.Web.oddBase.Models;
using oncloud.Web.oddBase.Models.Home;
using OddBasyBY.Models;

namespace oncloud.Web.oddBase.Controllers
{
    [Authorize(Roles = "user")]
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

        public virtual ActionResult SaveSuccess(City city, Street street,
            [ModelBinder(typeof (CustomModelBinderForSegment))] ICollection<Segment> segment,
            [ModelBinder(typeof (CustomModelBinderForRM))] ICollection<SpecificationofRM> SpecificationofRM,
            [ModelBinder(typeof (CustomModelBinderForRS))] ICollection<SpecificationofRS> SpecificationofRS,
            [ModelBinder(typeof (CustomModelBinderForRB))] ICollection<SpecificationOfRb> SpecificationofRB,
            HttpPostedFileBase layoutScheme = null, IEnumerable<HttpPostedFileBase> layoutDislocation = null)
        {

            int LastIndexSegment = db.Segment.AsEnumerable().Last().id;

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
            segment.GroupBy(a => a.Name).ForEach(a => a.ForEach(b => b.id = ++LastIndexSegment));
            streetInfo.Segment = segment;
            streetInfo.SpecificationofRM = SpecificationofRM;
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
            if (layoutDislocation != null)
            {
                List<layoutDislocation> imageDislocations = new List<layoutDislocation>();
                layoutDislocation imageDislocation;
                layoutDislocation.ForEach(a =>
                {
                    imageDislocation = new layoutDislocation();
                    imageDislocation.ImageMimeType = a.ContentType;
                    imageDislocation.ImageData = new byte[a.ContentLength];
                    a.InputStream.Read(imageDislocation.ImageData, 0, a.ContentLength);
                    imageDislocation.StreetId = streetInfo.id;
                    imageDislocation.SegmentId = LastIndexSegment;
                    imageDislocations.Add(imageDislocation);
                }
                    );
                db.layoutDislocations.AddRange(imageDislocations);
            }
            SpecificationofRS.ForEach(a =>
            {
                a.RoadSigns_id =
                    db.RoadSigns.Single(b => b.NumberRoadSigns == a.RoadSignsIdModel).id;
                a.SegmentId = segment.Single(c => c.Name == a.SegmentIdModel).id;
                a.Street_id = streetInfo.id;

            });
            SpecificationofRB.ForEach(a =>
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

        public virtual ActionResult DeleteStreet(int id)
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
            db.Street.Remove(street);


            db.SaveChanges();
            return RedirectToAction("Table");
        }
        public ActionResult EditStreets(int id)
        {
            ViewBag.City = db.City.First();
            Street street = db.Street.Find(id);
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
    }
}