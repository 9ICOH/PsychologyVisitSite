
namespace PsychologyVisitSite.WebUI.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string BootstrapCss = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css";
            const string JqueryJs = "https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js";
            const string BootstrapJs = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js";
            const string AngularJs = "https://ajax.googleapis.com/ajax/libs/angularjs/1.4.4/angular.min.js";

            bundles.Add(new ScriptBundle("~/bundles/jquery", JqueryJs).Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/Content/bootstrapCss", BootstrapCss).Include("~/Content/bootstrap.css"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap", BootstrapJs).Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(
                new StyleBundle("~/Content/css").Include(
                "~/Content/ErrorStyle.css",
                "~/Content/HomePageStyle.css"));

            bundles.Add(
                new ScriptBundle("~/bundles/angular", AngularJs).Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/app/app.js",
                    "~/Scripts/app/Home/mainPageController.js",
                    "~/Scripts/app/Home/mainPageEditor.js",
                    "~/Scripts/app/Registrations/registrationsController.js",
                    "~/Scripts/app/Meetings/meetingEventsController.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}