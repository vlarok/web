using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    /// <summary>
    /// Summary description for Listen
    /// </summary>
    public class Listen : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.QueryString["File"];
            string dir = filename.Substring(0, 4) + "\\" + filename.Substring(4, 2) + "\\" + filename.Substring(6, 2) + "\\" +
                       filename.Substring(8, 2) + "\\";
            //Validate the file name and make sure it is one that the user may access
            context.Response.Buffer = true;
            context.Response.Clear();
            context.Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            context.Response.ContentType = "application/octet-stream";

            context.Response.WriteFile(@"C:\Partcom\CallHandler\" + dir + filename);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}