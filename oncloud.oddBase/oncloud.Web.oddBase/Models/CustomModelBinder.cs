using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oncloud.Domain.Concrete;
using oncloud.Domain.Entities;
using oncloud.Web.oddBase.Models;


namespace OddBasyBY.Models
{
    public class CustomModelBinderForSegment : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            List<Segment> ListSurface = new List<Segment>();

            string[] BreadthS = request.Form.Get("Segment.BreadthS").Split(new Char[] {','});
            string[] BreadthE = request.Form.Get("Segment.BreadthE").Split(new Char[] {','});
            string[] LengthS = request.Form.Get("Segment.LengthS").Split(new Char[] {','});
            string[] LengthE = request.Form.Get("Segment.LengthS").Split(new Char[] {','});

            for (int i = 0; i < BreadthS.Count(); i++)
            {

                ListSurface.Add(new Segment()
                {
                    Name = i + 1,
                    BreadthS = BreadthS[i],
                    LengthS = LengthS[i],
                    BreadthE = BreadthE[i],
                    LengthE = LengthE[i]
                });

            }
            return ListSurface;
        }
    }

    public class CustomModelBinderForRM : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            List<SpecificationofRM> ListSpecificationofRM = new List<SpecificationofRM>();

            List<string> ModelsL = request.Form.AllKeys.Where(a => a.Contains("ModalsL")).ToList();
            List<string> ModalsA = request.Form.AllKeys.Where(a => a.Contains("ModalsA")).ToList();
            for (int i = 0; i < ModelsL.Count; i++)
            {
                string tempValueL = request.Form.Get(ModelsL.ElementAt(i));
                string tempValueA = request.Form.Get(ModalsA.ElementAt(i));

                if (tempValueL != "" && tempValueA != "")
                {

                    ListSpecificationofRM.Add(new SpecificationofRM() {length = tempValueL, area = tempValueA,TheHorizontalRoadMarkingIdModel = ModalsA.ElementAt(i).Substring(7) });
                }
            }
            return ListSpecificationofRM;
        }
    }

    public class CustomModelBinderForRS : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            List<SpecificationofRS> ListSpecificationofRS = new List<SpecificationofRS>();
            var countRSval = request.Form.Get("CountSides");
            if (countRSval != null)
            {
                List<string> ModalC = request.Form.AllKeys.Where(a => a.Contains("ModalC")).ToList();

                for (int i = 0; i < ModalC.Count; i++)
                {
                    string[] tempValueC = request.Form.Get(ModalC.ElementAt(i)).Split(',');
                    foreach (var item in tempValueC)
                    {
                        if (item != "")
                        {

                            ListSpecificationofRS.Add(new SpecificationofRS()
                            {
                                CountRS = int.Parse(item),
                                RoadSignsIdModel = ModalC.ElementAt(i).Substring(ModalC.ElementAt(i).IndexOf("C") + 1),
                                SegmentIdModel =
                                    int.Parse(ModalC.ElementAt(i).Substring(0, ModalC.ElementAt(i).IndexOf("M")))
                            });
                        }
                    }
                }
                return ListSpecificationofRS;
            }
            return null;
        }
    }

    public class CustomModelBinderForRB : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            List<SpecificationOfRb> ListSpecificationofRS = new List<SpecificationOfRb>();
            var countRSval = request.Form.Get("CountSides");
            if (countRSval != null)
            {
                List<string> ModalM = request.Form.AllKeys.Where(a => a.Contains("RoadBarriers")).ToList();

                for (int i = 0; i < ModalM.Count; i++)
                {
                    string tempValueM = request.Form.Get(ModalM.ElementAt(i));

                    if (tempValueM != "")
                    {

                        ListSpecificationofRS.Add(new SpecificationOfRb()
                        {
                            Length = int.Parse(tempValueM),
                            SegmentIdModel = int.Parse(ModalM.ElementAt(i).Substring(0, ModalM.ElementAt(i).IndexOf("R"))),
                            RoadBarriersIdModel = ModalM.ElementAt(i).Substring(ModalM.ElementAt(i).IndexOf("s")+1)
                        });
                    }
                }
                return ListSpecificationofRS;
            }
            return null;
        }
    }
    public class CustomModelBinderForlayoutDislocation : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            List<ModelLayoutDislocation> ModelLayoutDislocation = new List<ModelLayoutDislocation>();

            List<string> Dislocation = request.Files.AllKeys.Where(a => a.Contains("layoutDislocation")).ToList();
           
            for (int i = 0; i < Dislocation.Count; i++)
            {
                HttpPostedFileBase File = request.Files.Get(Dislocation.ElementAt(i));
                if(File.ContentLength!=0)
                ModelLayoutDislocation.Add(new ModelLayoutDislocation() {SegmentId =int.Parse(Dislocation.ElementAt(i).Substring(17)),File = File});

            }


               
            
            return ModelLayoutDislocation;
        }
     }

    public class ModelLayoutDislocation
    {
        public HttpPostedFileBase File { get; set; }
        public int SegmentId { get; set; }
    }
}