using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Utilities.ControllerFilters
{
    public class ControllerFilter:IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controllername = context.RouteData.Values["controller"].ToString();
            string actionname = context.RouteData.Values["action"].ToString();
            if (controllername == "User")
            {
                if (context.HttpContext.Session.GetString("UserId") == null)
                {
                    if (context.HttpContext.Session.GetString("AdminId") != null)
                    {
                        context.Result = new RedirectResult("~/Admin/Index");
                        return;
                    }
                    else
                    {
                        context.Result = new RedirectResult("~/Home/GirisYap");
                        return;
                    }
                }
            }
        }
    }
}
