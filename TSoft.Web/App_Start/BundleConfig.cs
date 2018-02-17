using System.Web.Optimization;

namespace TSoft.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            //JS Global Compulsory
            bundles.Add(new ScriptBundle("~/bundles/globalcompulsory").Include(
                        "~/Plugins/jquery/jquery.min.js",
                        "~/Plugins/jquery-migrate/jquery-migrate.min.js",
                        "~/Scripts/popper.min.js",
                        "~/Plugins/bootstrap/bootstrap.min.js"
                        ));

            //JS Implementing Plugins
            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/appear.js",
                        "~/Plugins/chosen/chosen.jquery.js",
                        "~/Plugins/image-select/src/ImageSelect.jquery.js",
                        "~/Plugins/circles/circles.min.js",
                        "~/Plugins/slick-carousel/slick/slick.js",
                        "~/Plugins/gmaps/gmaps.min.js"
                        ));

            //JS Revolution Slider
            bundles.Add(new ScriptBundle("~/bundles/revolutionslider").Include(
                        "~/Plugins/revolution-slider/revolution/js/jquery.themepunch.tools.min.js",
                        "~/Plugins/revolution-slider/revolution/js/jquery.themepunch.revolution.min.js",
                        "~/Plugins/revolution-slider/revolution-addons/slicey/js/revolution.addon.slicey.min.js",
                        "~/Plugins/revolution-slider/revolution/js/extensions/revolution.extension.actions.min.js",
                        "~/Plugins/revolution-slider/revolution/js/extensions/revolution.extension.carousel.min.js",
                        "~/Plugins/revolution/js/extensions/revolution.extension.kenburn.min.js",
                        "~/Plugins/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                        "~/Plugins/revolution/js/extensions/revolution.extension.migration.min.js",
                        "~/Plugins/revolution/js/extensions/revolution.extension.navigation.min.js",
                        "~/Plugins/revolution/js/extensions/revolution.extension.parallax.min.js",
                        "~/Plugins/revolution/js/extensions/revolution.extension.slideanims.min.js",
                        "~/Plugins/revolution/js/extensions/revolution.extension.video.min.js"                        
                        ));

            //JS Unify
            bundles.Add(new ScriptBundle("~/bundles/unity").Include(
                        "~/Plugins/hs.core.js",
                        "~/Plugins/components/hs.header.js",
                        "~/Plugins/helpers/hs.hamburgers.js",
                        "~/Plugins/components/hs.scroll-nav.js",
                        "~/Plugins/components/hs.select.js",
                        "~/Plugins/components/hs.onscroll-animation.js",
                        "~/Plugins/components/hs.tabs.js",
                        "~/Plugins/components/hs.progress-bar.js",
                        "~/Plugins/components/hs.chart-pie.js",
                        "~/Plugins/components/hs.carousel.js",
                        "~/Plugins/components/gmap/hs.map.js",
                        "~/Plugins/components/hs.go-to.js"
                        ));

            //JS Customization
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Plugins/custom.js"));

            // Either add it to the  existing bundle
            bundles.Add(new StyleBundle("~/Content/css")

            //<!-- CSS Implementing Plugins -->
            .Include("~/Plugins/icon-awesome/font-awesome.min.css",
            "~/Plugins/icon-hs/style.css",
            "~/Plugins/icon-line-pro/style.css",
            "~/Plugins/icon-line/css/simple-line-icons.css",
            "~/Plugins/hamburgers/hamburgers.min.css",
            "~/Plugins/chosen/chosen.css",
            "~/Plugins/animate.css",
            "~/Plugins/slick-carousel/slick/slick.css",

            //<!-- Revolution Slider -->
            "~/Plugins/revolution-slider/revolution/fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
            "~/Plugins/revolution-slider/revolution/css/settings.css",
            "~/Plugins/revolution-slider/revolution/css/layers.css",
            "~/Plugins/revolution-slider/revolution/css/navigation.css",

            //<!-- CSS Template -->
           "~/Content/styles.op-agency.css",

           //<!-- CSS Customization -->
           "~/Content/custom.css"
            ));
        }
    }
}