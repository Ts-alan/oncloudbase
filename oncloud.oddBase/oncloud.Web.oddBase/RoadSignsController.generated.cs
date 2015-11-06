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
    public partial class RoadSignsController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RoadSignsController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult Details()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CreateItem()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateItem);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditItem()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditItem);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Edit()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Delete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteConfirmed()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteItem()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteItem);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.FileContentResult GetImage()
        {
            return new T4MVC_System_Web_Mvc_FileContentResult(Area, Name, ActionNames.GetImage);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public RoadSignsController Actions { get { return MVC.RoadSigns; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "RoadSigns";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "RoadSigns";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Details = "Details";
            public readonly string CreateItem = "CreateItem";
            public readonly string EditItem = "EditItem";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
            public readonly string Delete = "Delete";
            public readonly string DeleteConfirmed = "Delete";
            public readonly string DeleteItem = "DeleteItem";
            public readonly string GetImage = "GetImage";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Details = "Details";
            public const string CreateItem = "CreateItem";
            public const string EditItem = "EditItem";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string DeleteConfirmed = "Delete";
            public const string DeleteItem = "DeleteItem";
            public const string GetImage = "GetImage";
        }


        static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Details
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_CreateItem s_params_CreateItem = new ActionParamsClass_CreateItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateItem CreateItemParams { get { return s_params_CreateItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateItem
        {
            public readonly string id = "id";
            public readonly string roadSignItem = "roadSignItem";
            public readonly string image = "image";
        }
        static readonly ActionParamsClass_EditItem s_params_EditItem = new ActionParamsClass_EditItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditItem EditItemParams { get { return s_params_EditItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditItem
        {
            public readonly string id = "id";
            public readonly string hallmark = "hallmark";
            public readonly string roadSignItem = "roadSignItem";
            public readonly string image = "image";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string roadSigns = "roadSigns";
        }
        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string id = "id";
            public readonly string roadSigns = "roadSigns";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_DeleteConfirmed s_params_DeleteConfirmed = new ActionParamsClass_DeleteConfirmed();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteConfirmed DeleteConfirmedParams { get { return s_params_DeleteConfirmed; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteConfirmed
        {
            public readonly string id = "id";
            public readonly string hallmark = "hallmark";
        }
        static readonly ActionParamsClass_DeleteItem s_params_DeleteItem = new ActionParamsClass_DeleteItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteItem DeleteItemParams { get { return s_params_DeleteItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteItem
        {
            public readonly string id = "id";
            public readonly string hallmark = "hallmark";
        }
        static readonly ActionParamsClass_GetImage s_params_GetImage = new ActionParamsClass_GetImage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetImage GetImageParams { get { return s_params_GetImage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetImage
        {
            public readonly string id = "id";
            public readonly string hallmark = "hallmark";
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
                public readonly string Create = "Create";
                public readonly string CreateItem = "CreateItem";
                public readonly string Delete = "Delete";
                public readonly string DeleteItem = "DeleteItem";
                public readonly string Details = "Details";
                public readonly string Edit = "Edit";
                public readonly string EditItem = "EditItem";
                public readonly string Index = "Index";
            }
            public readonly string Create = "~/Views/RoadSigns/Create.cshtml";
            public readonly string CreateItem = "~/Views/RoadSigns/CreateItem.cshtml";
            public readonly string Delete = "~/Views/RoadSigns/Delete.cshtml";
            public readonly string DeleteItem = "~/Views/RoadSigns/DeleteItem.cshtml";
            public readonly string Details = "~/Views/RoadSigns/Details.cshtml";
            public readonly string Edit = "~/Views/RoadSigns/Edit.cshtml";
            public readonly string EditItem = "~/Views/RoadSigns/EditItem.cshtml";
            public readonly string Index = "~/Views/RoadSigns/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_RoadSignsController : oncloud.Web.oddBase.Controllers.RoadSignsController
    {
        public T4MVC_RoadSignsController() : base(Dummy.Instance) { }

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
        partial void DetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Details(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DetailsOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void CreateItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateItem(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            CreateItemOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void CreateItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, oncloud.Domain.Entities.RoadSignItem roadSignItem, System.Web.HttpPostedFileBase image);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateItem(oncloud.Domain.Entities.RoadSignItem roadSignItem, System.Web.HttpPostedFileBase image)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "roadSignItem", roadSignItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "image", image);
            CreateItemOverride(callInfo, roadSignItem, image);
            return callInfo;
        }

        [NonAction]
        partial void EditItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id, string hallmark);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditItem(int? id, string hallmark)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "hallmark", hallmark);
            EditItemOverride(callInfo, id, hallmark);
            return callInfo;
        }

        [NonAction]
        partial void EditItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, oncloud.Domain.Entities.RoadSignItem roadSignItem, System.Web.HttpPostedFileBase image);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditItem(oncloud.Domain.Entities.RoadSignItem roadSignItem, System.Web.HttpPostedFileBase image)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "roadSignItem", roadSignItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "image", image);
            EditItemOverride(callInfo, roadSignItem, image);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, oncloud.Domain.Entities.RoadSigns roadSigns);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(oncloud.Domain.Entities.RoadSigns roadSigns)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "roadSigns", roadSigns);
            CreateOverride(callInfo, roadSigns);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, oncloud.Domain.Entities.RoadSigns roadSigns);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(oncloud.Domain.Entities.RoadSigns roadSigns)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "roadSigns", roadSigns);
            EditOverride(callInfo, roadSigns);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DeleteConfirmedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteConfirmed(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteConfirmedOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DeleteItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id, string hallmark);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteItem(int? id, string hallmark)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "hallmark", hallmark);
            DeleteItemOverride(callInfo, id, hallmark);
            return callInfo;
        }

        [NonAction]
        partial void DeleteConfirmedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, string hallmark);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteConfirmed(int id, string hallmark)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "hallmark", hallmark);
            DeleteConfirmedOverride(callInfo, id, hallmark);
            return callInfo;
        }

        [NonAction]
        partial void GetImageOverride(T4MVC_System_Web_Mvc_FileContentResult callInfo, int id, string hallmark);

        [NonAction]
        public override System.Web.Mvc.FileContentResult GetImage(int id, string hallmark)
        {
            var callInfo = new T4MVC_System_Web_Mvc_FileContentResult(Area, Name, ActionNames.GetImage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "hallmark", hallmark);
            GetImageOverride(callInfo, id, hallmark);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
