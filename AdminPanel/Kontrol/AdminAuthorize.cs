using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Kontrol
{
    public class AdminAuthorize : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Kadi"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Admin/Giris");
                return false;
            }
        }
    }
}