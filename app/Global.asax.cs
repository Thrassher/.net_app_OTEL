using System;
using System.Web;

namespace DotNetOtelQA
{
    public class Global : HttpApplication
    {
        protected void Application_Start(
            object sender, EventArgs e)
        {
            // Application startup
        }

        protected void Application_Error(
            object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            System.Diagnostics.Trace.TraceError(
                ex != null ? ex.ToString() :
                "Unknown application error");
        }
    }
}
