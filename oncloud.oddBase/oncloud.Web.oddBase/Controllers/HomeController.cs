﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oncloud.Domain.Concrete;
using oncloud.Domain.Entities;
using oncloud.Web.oddBase.Models;
using oncloud.Web.oddBase.Models.Home;
using OddBasyBY.Models;

namespace oncloud.Web.oddBase.Controllers
{
    [Authorize(Roles="user")]
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
            [ModelBinder(typeof (CustomModelBinderForModels))] ICollection<SpecificationofRM> SpecificationofRM,
            HttpPostedFileBase layoutScheme,IEnumerable<HttpPostedFileBase> layoutDislocation)
        {
            //if (
            //    db.Street.Any(
            //        a =>
            //            a.BreadthE == street.BreadthE && a.BreadthS == street.BreadthS && a.LengthE == street.LengthE &&
            //            a.LengthS == street.LengthS))
            //{
            //    db.Entry(street).State = EntityState.Modified;
            //}
            //else
            //{


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

            streetInfo.Segment = segment;
            streetInfo.SpecificationofRM = SpecificationofRM;

            db.Segment.AddRange(segment);
            db.SpecificationofRM.AddRange(SpecificationofRM);
            //}
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