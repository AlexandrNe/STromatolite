using System.Web;
using System.Web.Optimization;

namespace Stromatolite
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/libs/detectizr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/revolution").Include(
                        "~/Scripts/rs-tools.min.js",
                        "~/Scripts/revolution-slider.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/plugins/waypoints.min.js",
                        "~/Scripts/plugins/waves.min.js",
                        "~/Scripts/plugins/jquery.stellar.min.js",
                        "~/Scripts/plugins/owl.carousel.js",
                        "~/Scripts/plugins/isotope.pkgd.min.js",
                        "~/Scripts/plugins/imagesloaded.pkgd.min.js",
                        "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/magnific-popup.css",
                      "~/Content/styles.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/revolution").Include(
                      "~/Content/revolution-slider/css/revolution-slider.css"));

        }
    }
}
