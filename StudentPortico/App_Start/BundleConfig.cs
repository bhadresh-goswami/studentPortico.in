using System.Web;
using System.Web.Optimization;

namespace StudentPortico
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region AdminLayout
            //css
            string CSSfolderPath = "~/Content/adminLayout";
            bundles.Add(new StyleBundle("~/adminLayout/css").Include(
                      string.Format("{0}/css/bootstrap.min.css", CSSfolderPath),
                      string.Format("{0}/css/metisMenu.min.css", CSSfolderPath),
                      string.Format("{0}/css/timeline.css", CSSfolderPath),
                      string.Format("{0}/css/startmin.css", CSSfolderPath),
                      string.Format("{0}/css/morris.css", CSSfolderPath),
                      string.Format("{0}/css/font-awesome.min.css", CSSfolderPath)
                      ));

            string JSfolderPath = "~/Scripts/adminLayout/js";
            bundles.Add(new ScriptBundle("~/adminLayout/js").Include(
                string.Format("{0}/jquery.min.js", JSfolderPath),
                string.Format("{0}/bootstrap.min.js", JSfolderPath),
                string.Format("{0}/metisMenu.min.js", JSfolderPath),
                string.Format("{0}/raphael.min.js", JSfolderPath),
                string.Format("{0}/morris.min.js", JSfolderPath),
                string.Format("{0}/morris-data.js", JSfolderPath),
                string.Format("{0}/startmin.js", JSfolderPath)

                ));
            //js
            /*
             <!-- jQuery -->
        <script src="../js/jquery.min.js"></script>

        <!-- Bootstrap Core JavaScript -->
        <script src="../js/bootstrap.min.js"></script>

        <!-- Metis Menu Plugin JavaScript -->
        <script src="../js/metisMenu.min.js"></script>

        <!-- Morris Charts JavaScript -->
        <script src="../js/raphael.min.js"></script>
        <script src="../js/morris.min.js"></script>
        <script src="../js/morris-data.js"></script>

        <!-- Custom Theme JavaScript -->
        <script src="../js/startmin.js"></script>

             
             */
            #endregion


            #region Older
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #endregion
        }
    }
}
