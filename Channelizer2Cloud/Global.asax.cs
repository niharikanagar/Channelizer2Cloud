using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Channelizer2Cloud.Services;
using Channelizer2Cloud.Models;
using System.Web.SessionState;
using System.Web.Security;

namespace Channelizer2Cloud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        Service _service = new Service();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }
            protected void Session_End(object sender, EventArgs e)
        {
            //try
            //{
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();
            //    //if (this.Context.Handler is IRequiresSessionState || this.Context.Handler is IReadOnlySessionState)
            //    //{
            //    //    FormsAuthentication.SignOut();
            //    //    FormsAuthentication.RedirectToLoginPage();
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    EventLog eventlog = new EventLog();
            //    eventlog.EventLevel = "Error";
            //    eventlog.EventType = "Session End";
            //    //eventlog.ExceptionMessage = ex.InnerException.ToString();
            //    eventlog.Message = ex.Message.ToString();
            //    eventlog.CreatedOn = DateTime.Now;
            //    _service.SaveEventLogError(eventlog);
            //}
        }

    }
}
