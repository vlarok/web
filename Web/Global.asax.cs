using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());
        }

        protected void Application_BeginRequest()
        {
            // modify datetime.tostring formating in estonian locale (remove seconds)
            // default format is: ShortDatePattern + ' ' + LongTimePattern
            //if (CultureInfo.CurrentCulture.Name.StartsWith("et"))
            //{
            //    var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //    culture.DateTimeFormat.LongTimePattern = "HH:mm";
            //    Thread.CurrentThread.CurrentCulture = culture;
            //}
        }
    }


    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);

            return value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
        }
    }

}