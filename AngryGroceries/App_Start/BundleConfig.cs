using System.Web.Optimization;

namespace AngryGroceries
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS

            // Bootstrap (responsive), font-awesome and custom
            // Todo:  replace Bundle with StyleBundle
            bundles.Add(new Bundle("~/Stylesheets/default")
                .Include("~/Stylesheets/font-awesome.css")
                .Include("~/Stylesheets/Site.css"));
            
            // Javascript 

            // Modenizr
            // Todo: replace bundle with ScriptBundle
            bundles.Add(new Bundle("~/Scripts/modenizr")
                .Include("~/Scripts/modenizr-{version}.js"));

            // jQuery, Bootstrap, Angular
            // Todo: replace bundle with ScriptBundle
            bundles.Add(new Bundle("~/Scripts/default")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/angular.js"));
        }
    }
}
