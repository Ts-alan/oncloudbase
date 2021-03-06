// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace oncloud.Web.oddBase.Controllers
{
    public partial class HomeController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected HomeController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult SaveSuccess()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveSuccess);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteStreet()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteStreet);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditStreets()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditStreets);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Review()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Review);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult FindStreets()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FindStreets);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult FindFilledStreets()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FindFilledStreets);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.FileContentResult GetImageLayoutScheme()
        {
            return new T4MVC_System_Web_Mvc_FileContentResult(Area, Name, ActionNames.GetImageLayoutScheme);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.FileContentResult LayoutDislocation()
        {
            return new T4MVC_System_Web_Mvc_FileContentResult(Area, Name, ActionNames.LayoutDislocation);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ShowOnMap()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ShowOnMap);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController Actions { get { return MVC.Home; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Home";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Home";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Table = "Table";
            public readonly string SaveSuccess = "SaveSuccess";
            public readonly string Contact = "Contact";
            public readonly string AddStreet = "AddStreet";
            public readonly string DeleteStreet = "DeleteStreet";
            public readonly string EditStreets = "EditStreets";
            public readonly string Review = "Review";
            public readonly string FindStreets = "FindStreets";
            public readonly string FindFilledStreets = "FindFilledStreets";
            public readonly string GetImageLayoutScheme = "GetImageLayoutScheme";
            public readonly string LayoutDislocation = "LayoutDislocation";
            public readonly string ShowOnMap = "ShowOnMap";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Table = "Table";
            public const string SaveSuccess = "SaveSuccess";
            public const string Contact = "Contact";
            public const string AddStreet = "AddStreet";
            public const string DeleteStreet = "DeleteStreet";
            public const string EditStreets = "EditStreets";
            public const string Review = "Review";
            public const string FindStreets = "FindStreets";
            public const string FindFilledStreets = "FindFilledStreets";
            public const string GetImageLayoutScheme = "GetImageLayoutScheme";
            public const string LayoutDislocation = "LayoutDislocation";
            public const string ShowOnMap = "ShowOnMap";
        }


        static readonly ActionParamsClass_SaveSuccess s_params_SaveSuccess = new ActionParamsClass_SaveSuccess();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SaveSuccess SaveSuccessParams { get { return s_params_SaveSuccess; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SaveSuccess
        {
            public readonly string city = "city";
            public readonly string street = "street";
            public readonly string LayoutDislocationDelete = "LayoutDislocationDelete";
            public readonly string segment = "segment";
            public readonly string SpecificationofRM = "SpecificationofRM";
            public readonly string SpecificationofRS = "SpecificationofRS";
            public readonly string SpecificationofRB = "SpecificationofRB";
            public readonly string layoutScheme = "layoutScheme";
            public readonly string layoutDislocation = "layoutDislocation";
        }
        static readonly ActionParamsClass_DeleteStreet s_params_DeleteStreet = new ActionParamsClass_DeleteStreet();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteStreet DeleteStreetParams { get { return s_params_DeleteStreet; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteStreet
        {
            public readonly string id = "id";
            public readonly string idPage = "idPage";
        }
        static readonly ActionParamsClass_EditStreets s_params_EditStreets = new ActionParamsClass_EditStreets();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditStreets EditStreetsParams { get { return s_params_EditStreets; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditStreets
        {
            public readonly string id = "id";
            public readonly string city = "city";
            public readonly string street = "street";
            public readonly string LayoutDislocationDelete = "LayoutDislocationDelete";
            public readonly string segment = "segment";
            public readonly string SpecificationofRM = "SpecificationofRM";
            public readonly string SpecificationofRS = "SpecificationofRS";
            public readonly string SpecificationofRB = "SpecificationofRB";
            public readonly string layoutScheme = "layoutScheme";
            public readonly string layoutDislocation = "layoutDislocation";
        }
        static readonly ActionParamsClass_Review s_params_Review = new ActionParamsClass_Review();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Review ReviewParams { get { return s_params_Review; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Review
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_FindStreets s_params_FindStreets = new ActionParamsClass_FindStreets();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_FindStreets FindStreetsParams { get { return s_params_FindStreets; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_FindStreets
        {
            public readonly string term = "term";
        }
        static readonly ActionParamsClass_FindFilledStreets s_params_FindFilledStreets = new ActionParamsClass_FindFilledStreets();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_FindFilledStreets FindFilledStreetsParams { get { return s_params_FindFilledStreets; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_FindFilledStreets
        {
            public readonly string term = "term";
        }
        static readonly ActionParamsClass_GetImageLayoutScheme s_params_GetImageLayoutScheme = new ActionParamsClass_GetImageLayoutScheme();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetImageLayoutScheme GetImageLayoutSchemeParams { get { return s_params_GetImageLayoutScheme; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetImageLayoutScheme
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_LayoutDislocation s_params_LayoutDislocation = new ActionParamsClass_LayoutDislocation();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_LayoutDislocation LayoutDislocationParams { get { return s_params_LayoutDislocation; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_LayoutDislocation
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_ShowOnMap s_params_ShowOnMap = new ActionParamsClass_ShowOnMap();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ShowOnMap ShowOnMapParams { get { return s_params_ShowOnMap; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ShowOnMap
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string About = "About";
                public readonly string AddStreet = "AddStreet";
                public readonly string Contact = "Contact";
                public readonly string EditStreets = "EditStreets";
                public readonly string Index = "Index";
                public readonly string Review = "Review";
                public readonly string ShowOnMap = "ShowOnMap";
                public readonly string Table = "Table";
            }
            public readonly string About = "~/Views/Home/About.cshtml";
            public readonly string AddStreet = "~/Views/Home/AddStreet.cshtml";
            public readonly string Contact = "~/Views/Home/Contact.cshtml";
            public readonly string EditStreets = "~/Views/Home/EditStreets.cshtml";
            public readonly string Index = "~/Views/Home/Index.cshtml";
            public readonly string Review = "~/Views/Home/Review.cshtml";
            public readonly string ShowOnMap = "~/Views/Home/ShowOnMap.cshtml";
            public readonly string Table = "~/Views/Home/Table.cshtml";
            static readonly _PartialsClass s_Partials = new _PartialsClass();
            public _PartialsClass Partials { get { return s_Partials; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialsClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string RoadSingns = "RoadSingns";
                }
                public readonly string RoadSingns = "~/Views/Home/Partials/RoadSingns.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_HomeController : oncloud.Web.oddBase.Controllers.HomeController
    {
        public T4MVC_HomeController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void TableOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Table()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Table);
            TableOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void SaveSuccessOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, oncloud.Domain.Entities.City city, oncloud.Domain.Entities.Street street, System.Collections.Generic.IEnumerable<int> LayoutDislocationDelete, System.Collections.Generic.ICollection<oncloud.Domain.Entities.Segment> segment, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRM> SpecificationofRM, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRS> SpecificationofRS, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationOfRb> SpecificationofRB, System.Web.HttpPostedFileBase layoutScheme, System.Collections.Generic.List<OddBasyBY.Models.ModelLayoutDislocation> layoutDislocation);

        [NonAction]
        public override System.Web.Mvc.ActionResult SaveSuccess(oncloud.Domain.Entities.City city, oncloud.Domain.Entities.Street street, System.Collections.Generic.IEnumerable<int> LayoutDislocationDelete, System.Collections.Generic.ICollection<oncloud.Domain.Entities.Segment> segment, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRM> SpecificationofRM, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRS> SpecificationofRS, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationOfRb> SpecificationofRB, System.Web.HttpPostedFileBase layoutScheme, System.Collections.Generic.List<OddBasyBY.Models.ModelLayoutDislocation> layoutDislocation)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveSuccess);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "city", city);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "street", street);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "LayoutDislocationDelete", LayoutDislocationDelete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "segment", segment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SpecificationofRM", SpecificationofRM);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SpecificationofRS", SpecificationofRS);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SpecificationofRB", SpecificationofRB);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "layoutScheme", layoutScheme);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "layoutDislocation", layoutDislocation);
            SaveSuccessOverride(callInfo, city, street, LayoutDislocationDelete, segment, SpecificationofRM, SpecificationofRS, SpecificationofRB, layoutScheme, layoutDislocation);
            return callInfo;
        }

        [NonAction]
        partial void ContactOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Contact()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Contact);
            ContactOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddStreetOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddStreet()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddStreet);
            AddStreetOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DeleteStreetOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, string idPage);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteStreet(int id, string idPage)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteStreet);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "idPage", idPage);
            DeleteStreetOverride(callInfo, id, idPage);
            return callInfo;
        }

        [NonAction]
        partial void EditStreetsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditStreets(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditStreets);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditStreetsOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditStreetsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, oncloud.Domain.Entities.City city, oncloud.Domain.Entities.Street street, System.Collections.Generic.IEnumerable<int> LayoutDislocationDelete, System.Collections.Generic.ICollection<oncloud.Domain.Entities.Segment> segment, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRM> SpecificationofRM, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRS> SpecificationofRS, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationOfRb> SpecificationofRB, System.Web.HttpPostedFileBase layoutScheme, System.Collections.Generic.List<OddBasyBY.Models.ModelLayoutDislocation> layoutDislocation);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditStreets(oncloud.Domain.Entities.City city, oncloud.Domain.Entities.Street street, System.Collections.Generic.IEnumerable<int> LayoutDislocationDelete, System.Collections.Generic.ICollection<oncloud.Domain.Entities.Segment> segment, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRM> SpecificationofRM, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationofRS> SpecificationofRS, System.Collections.Generic.ICollection<oncloud.Domain.Entities.SpecificationOfRb> SpecificationofRB, System.Web.HttpPostedFileBase layoutScheme, System.Collections.Generic.List<OddBasyBY.Models.ModelLayoutDislocation> layoutDislocation)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditStreets);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "city", city);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "street", street);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "LayoutDislocationDelete", LayoutDislocationDelete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "segment", segment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SpecificationofRM", SpecificationofRM);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SpecificationofRS", SpecificationofRS);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SpecificationofRB", SpecificationofRB);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "layoutScheme", layoutScheme);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "layoutDislocation", layoutDislocation);
            EditStreetsOverride(callInfo, city, street, LayoutDislocationDelete, segment, SpecificationofRM, SpecificationofRS, SpecificationofRB, layoutScheme, layoutDislocation);
            return callInfo;
        }

        [NonAction]
        partial void ReviewOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Review(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Review);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ReviewOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void FindStreetsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string term);

        [NonAction]
        public override System.Web.Mvc.ActionResult FindStreets(string term)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FindStreets);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "term", term);
            FindStreetsOverride(callInfo, term);
            return callInfo;
        }

        [NonAction]
        partial void FindFilledStreetsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string term);

        [NonAction]
        public override System.Web.Mvc.ActionResult FindFilledStreets(string term)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FindFilledStreets);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "term", term);
            FindFilledStreetsOverride(callInfo, term);
            return callInfo;
        }

        [NonAction]
        partial void GetImageLayoutSchemeOverride(T4MVC_System_Web_Mvc_FileContentResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.FileContentResult GetImageLayoutScheme(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_FileContentResult(Area, Name, ActionNames.GetImageLayoutScheme);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            GetImageLayoutSchemeOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void LayoutDislocationOverride(T4MVC_System_Web_Mvc_FileContentResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.FileContentResult LayoutDislocation(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_FileContentResult(Area, Name, ActionNames.LayoutDislocation);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            LayoutDislocationOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void ShowOnMapOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ShowOnMap(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ShowOnMap);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ShowOnMapOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
