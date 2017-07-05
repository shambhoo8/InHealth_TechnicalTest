using System.Web;
using System.Web.Optimization;

namespace InHealth_Assignment
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {////These css files for the Main page.
            bundles.Add(new StyleBundle("~/Content/CSSBundles").Include(
                    "~/Content/Style/bootstrap.css",
                    "~/Content/Style/bootstrap.min.css",
                    "~/Content/Style/Custom.css",
                    "~/Content/Style/font-awesome.min.css",
                    "~/Content/Style/jquery.steps.css",
                    "~/Content/Style/trNgGrid.css",
                    "~/Content/Style/toastr.min.css"
                ));

            // These js files are for the common usage.
            bundles.Add(new Bundle("~/Content/JSBundles").Include(
                    "~/Content/Script/Plugins/angular.js",
                    "~/Content/Script/Plugins/jquery-1.9.1.min.js",
                    "~/Content/Script/Plugins/jquery-ui.js",
                    "~/Content/Script/Plugins/jquery.steps.js",
                    "~/Content/Script/Plugins/angular-resource.js",
                    "~/Content/Script/Plugins/angular-route.js",
                    "~/Content/Script/Plugins/ui-bootstrap-tpls-0.12.0.js",
                    "~/Content/Script/Plugins/toastr.min.js",
                    "~/Content/Script/Plugins/trNgGrid.js",

                    "~/Content/Script/Application/app.js",
                    "~/Content/Script/Application/config.js",
                    "~/Content/Script/Services/Services.js",
                    "~/Content/Script/Controller/Controller.js",

                    "~/Content/Script/Services/BlogPostServices.js",
                    "~/Content/Script/Services/LoginServices.js",
                    "~/Content/Script/Services/NewPostServices.js",
                    "~/Content/Script/Services/PostDetailServices.js",
                    "~/Content/Script/Services/UserListServices.js",
                    "~/Content/Script/Services/UserRegistrationServices.js",
                    "~/Content/Script/Services/BlogPostUserServices.js",
                    "~/Content/Script/Services/BlogPostListServices.js",

                    "~/Content/Script/Controller/BlogPostController.js",
                    "~/Content/Script/Controller/LoginController.js",
                    "~/Content/Script/Controller/NewPostController.js",
                    "~/Content/Script/Controller/PostDetailController.js",
                    "~/Content/Script/Controller/UserListController.js",
                    "~/Content/Script/Controller/UserRegistrationController.js",
                    "~/Content/Script/Controller/BlogPostUserController.js",
                    "~/Content/Script/Controller/BlogPostListController.js"
                ));
        }
    }
}
