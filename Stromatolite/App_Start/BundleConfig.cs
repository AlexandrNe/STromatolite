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

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui-i18n.min.js"));

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
                        "~/Scripts/plugins/jquery.fancybox.js",
                        "~/Scripts/plugins/waves.min.js",
                        "~/Scripts/plugins/masterslider.min.js",
                        "~/Scripts/plugins/jquery.stellar.min.js",
                        "~/Scripts/plugins/jquery.magnific-popup.min.js",
                        "~/Scripts/plugins/owl.carousel.js",
                        "~/Scripts/plugins/isotope.pkgd.min.js",
                        "~/Scripts/plugins/imagesloaded.pkgd.min.js",
                        "~/Scripts/scripts.js",
                        "~/Scripts/scripts2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/magnific-popup.css",
                      "~/Content/styles.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/masterslider/css").Include(
                      "~/Content/masterslider/masterslider.css"));

            bundles.Add(new StyleBundle("~/Content/fancybox/css").Include(
                      "~/Content/fancybox/jquery.fancybox.css"));

            bundles.Add(new StyleBundle("~/Content/revolution").Include(
                      "~/Content/revolution-slider/css/revolution-slider.css"));


            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include("~/Scripts/tinymce/tinymce.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tiny").Include("~/Scripts/tiny.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinyplugins").Include("~/Scripts/tinymce/plugins/advlist/plugin.min.js"
                , "~/Scripts/tinymce/plugins/autolink/plugin.min.js", "~/Scripts/tinymce/plugins/lists/plugin.min.js"
                , "~/Scripts/tinymce/plugins/link/plugin.min.js", "~/Scripts/tinymce/plugins/image/plugin.min.js"
                , "~/Scripts/tinymce/plugins/charmap/plugin.min.js", "~/Scripts/tinymce/plugins/print/plugin.min.js"
                , "~/Scripts/tinymce/plugins/preview/plugin.min.js", "~/Scripts/tinymce/plugins/hr/plugin.min.js"
                , "~/Scripts/tinymce/plugins/anchor/plugin.min.js", "~/Scripts/tinymce/plugins/pagebreak/plugin.min.js"
                , "~/Scripts/tinymce/plugins/searchreplace/plugin.min.js", "~/Scripts/tinymce/plugins/wordcount/plugin.min.js"
                , "~/Scripts/tinymce/plugins/visualblocks/plugin.min.js", "~/Scripts/tinymce/plugins/visualchars/plugin.min.js"
                , "~/Scripts/tinymce/plugins/code/plugin.min.js", "~/Scripts/tinymce/plugins/fullscreen/plugin.min.js"
                , "~/Scripts/tinymce/plugins/insertdatetime/plugin.min.js", "~/Scripts/tinymce/plugins/media/plugin.min.js"
                , "~/Scripts/tinymce/plugins/nonbreaking/plugin.min.js", "~/Scripts/tinymce/plugins/save/plugin.min.js"
                , "~/Scripts/tinymce/plugins/table/plugin.min.js", "~/Scripts/tinymce/plugins/contextmenu/plugin.min.js"
                , "~/Scripts/tinymce/plugins/directionality/plugin.min.js", "~/Scripts/tinymce/plugins/emoticons/plugin.min.js"
                , "~/Scripts/tinymce/plugins/template/plugin.min.js", "~/Scripts/tinymce/plugins/paste/plugin.min.js"
                , "~/Scripts/tinymce/plugins/textcolor/plugin.min.js", "~/Scripts/tinymce/themes/modern/theme.min.js"));

            bundles.Add(new StyleBundle("~/Content/tinycss").Include(
                      "~/Content/skin.min.css",
                      "~/Content/content.min.css"));

            //bundles.Add(new StyleBundle("~/Content/skmn").Include(
            //          "~/Content/skin.min.css"));


        }
    }
}
