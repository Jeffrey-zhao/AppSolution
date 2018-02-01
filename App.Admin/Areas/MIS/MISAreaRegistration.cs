using System.Web.Mvc;

namespace App.Admin.Areas.MIS.Controllers
{
    public class MISAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MIS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "MIS_default",
                url: "MIS/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}