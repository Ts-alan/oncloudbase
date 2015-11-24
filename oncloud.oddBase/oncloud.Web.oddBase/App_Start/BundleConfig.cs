using System.Web;
using System.Web.Optimization;

namespace oncloud.Web.oddBase
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/СorrectionBootstrap.css"));
            //css для Grid
            bundles.Add(new StyleBundle("~/Content/jqCrid").Include(
                      "~/Content/jqGrid/ui.jqgrid.css",
                      "~/Content/jqGrid/searchFilter.css",
                      "~/Content/jqGrid/ui.jqgrid-bootstarp.css",
                      "~/Content/jqGrid/ui.multiselect.css",
                      "~/Content/GridSystemForTable.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/CSSTableGenerator").Include(
            "~/Content/csstablegenerator.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/jquery.form").Include(
                       "~/Scripts/jquery.form/jquery.form.js",
                       "~/Scripts/jquery.form/jquery.form.min.js"
           ));
            //javascript для Grid
            bundles.Add(new ScriptBundle("~/bundles/jqCrid").Include(
            "~/Scripts/jqGrid/i18n/grid.locale-en.js",
            "~/Scripts/jqGrid/jquery.jqGrid.js",
            "~/Scripts/jqGrid/plugins/grid.tbltogrid.js"
            ));
        }
    }
}
