using System;
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
using WebGrease.Css.Extensions;

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
            [ModelBinder(typeof (CustomModelBinderForRM))] ICollection<SpecificationofRM> SpecificationofRM,
            [ModelBinder(typeof(CustomModelBinderForRS))] ICollection<SpecificationofRS> SpecificationofRS,
            HttpPostedFileBase layoutScheme=null,IEnumerable<HttpPostedFileBase> layoutDislocation=null)
        {


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
            layoutScheme imageScheme=new layoutScheme();
            if (layoutScheme != null)
            {
                imageScheme.ImageData = new byte[layoutScheme.ContentLength];
                imageScheme.ImageMimeType = layoutScheme.ContentType;
                layoutScheme.InputStream.Read(imageScheme.ImageData, 0, layoutScheme.ContentLength);
                imageScheme.Id = streetInfo.id;
            }
            db.layoutScheme.Add(imageScheme);
            db.Segment.AddRange(segment);

            SpecificationofRM.ForEach(a=>a.TheHorizontalRoadMarking_id = db.TheHorizontalRoadMarking.Single(b=>b.NumberMarking==a.TheHorizontalRoadMarkingIdModel).id);
            SpecificationofRS.ForEach(a => a.RoadSigns_id = db.RoadSigns.Single(b => b.NumberRoadSigns == a.RoadSignsIdModel).id);


            db.SpecificationofRM.AddRange(SpecificationofRM);


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