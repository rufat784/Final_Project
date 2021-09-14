using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Filters
{
    public class AdminAuth: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            if (filtercontext.HttpContext.Session.GetString("ValidAdminUser") == null)
            {
                filtercontext.Result = new RedirectResult("~/admin");
                return;
            }
            base.OnActionExecuting(filtercontext);
        }
    }
}
