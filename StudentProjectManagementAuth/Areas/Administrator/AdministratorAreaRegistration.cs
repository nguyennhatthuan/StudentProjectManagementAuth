using System.Web.Mvc;

namespace StudentProjectManagementAuth.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name : "Administrator",
                url: "Administrator/{*.}",
                defaults: new {area = "Administrator", controller = "Admin", action = "Index"}
            );
        }
    }
}