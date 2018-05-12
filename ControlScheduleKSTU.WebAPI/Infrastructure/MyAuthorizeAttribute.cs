using ControlScheduleKSTU.DomainCore.Enums;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;


namespace ControlScheduleKSTU.WebAPI.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public RolesEnum RolesEnum { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (RolesEnum != 0)
                Roles = RolesEnum.ToString();
            base.OnAuthorization(actionContext);
        }
    }
}