using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace DesafioWhois
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css"));
            
            RegistrarAngular(bundles);
            BundleTable.EnableOptimizations = false;
        }

        public static void RegistrarAngular(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/bundles/angular")
                                .Include("~/Scripts/angular.js")
                                .Include("~/Scripts/app/app.js");

            var appBundle = new ScriptBundle("~/bundles/angular-app")
                                .Include("~/Scripts/app/mainController.js")
                                .Include("~/Scripts/app/whoisApiService.js");

            appBundle.Transforms.Clear();

            //Adicionar o diretório de controllers/service se for necessário. Por enquanto só tem um controller

            bundle.Orderer = new AsIsBundleOrderer();
            appBundle.Orderer = new AsIsBundleOrderer();

            bundles.Add(bundle);
            bundles.Add(appBundle);
        }
    }

    class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
