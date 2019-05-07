using Colegio.Web.Console.WS;
using System;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace Colegio.Web.Console
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebServiceHostFactory factory = new WebServiceHostFactory();

            RouteTable.Routes.Add(new ServiceRoute("alumno", factory, typeof(ServiceAlumno)));
            RouteTable.Routes.Add(new ServiceRoute("matter", factory, typeof(ServiceMatter)));
            RouteTable.Routes.Add(new ServiceRoute("note", factory, typeof(ServiceNote)));
            RouteTable.Routes.Add(new ServiceRoute("teacher", factory, typeof(ServiceTeacher)));
            RouteTable.Routes.Add(new ServiceRoute("term", factory, typeof(ServiceTerm)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}