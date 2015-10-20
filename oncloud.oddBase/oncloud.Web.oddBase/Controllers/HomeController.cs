﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oncloud.Web.oddBase.Models;
using oncloud.Web.oddBase.Models.Home;
using OddBasyBY.Models;

namespace oncloud.Web.oddBase.Controllers
{
    public class HomeController : Controller
    {
        OddAdbaseDataBase db =new OddAdbaseDataBase();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            Table data=new Table();
            data.Setinitialization(db);
            return View(data.GetDataModel);
        }
        public ActionResult SaveSuccess(City city, Street street, [ModelBinder(typeof(CustomModelBinderForSegment))] ICollection<Segment> segment, [ModelBinder(typeof(CustomModelBinderForModels))]ICollection<SpecificationofRM> models, HttpPostedFileBase layoutscheme)
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
            streetInfo.SpecificationofRM = models;

            db.Segment.AddRange(segment);
            db.SpecificationofRM.AddRange(models);
            //}
            db.SaveChanges();
            return RedirectToAction("Table");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddStreet()
        {
            ViewBag.City = db.City.First();
            
            ViewBag.Model = db.TheHorizontalRoadMarking.ToList().OrderBy(a =>
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

            return View();
        }
        public ActionResult FindStreets(string term)
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