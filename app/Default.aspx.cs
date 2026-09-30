using System;
using System.Threading;

namespace DotNetOtelQA
{
    public partial class DefaultPage :
        System.Web.UI.Page
    {
        protected void Page_Load(
            object sender, EventArgs e)
        {
            string action =
                Request.QueryString["action"];

            if (action == "health")
            {
                Response.ContentType =
                    "application/json";

                Response.Write(
                    "{\"status\":\"healthy\"}");

                return;
            }

            if (action == "error")
            {
                Response.StatusCode = 500;
                Response.TrySkipIisCustomErrors = true;

                Response.Write(
                    "Simulated application error");

                return;
            }

            if (action == "slow")
            {
                Thread.Sleep(5000);

                Response.Write(
                    "Slow request completed");

                return;
            }

            Response.Write(
                "DotNetOtelQA is running");
        }
    }
}
