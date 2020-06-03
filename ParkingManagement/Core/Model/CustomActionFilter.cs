using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;

namespace ParkingManagement.Core.Model
{
    public class CustomActionFilter : ActionFilterAttribute,IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TODO: Add your action filter's tasks here

            // Log Action Filter call
            using (ParkingManagementContext contextdb = new ParkingManagementContext())
            {
                //ActionLog log = new ActionLog()
                //{
                //    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                //    Action = string.Concat(filterContext.ActionDescriptor.ActionName, " (Logged By: Custom Action Filter)"),
                //    IP = filterContext.HttpContext.Request.UserHostAddress,
                //    DateTime = filterContext.HttpContext.Timestamp
                //};
                //contextdb.ActionLogs.Add(log);
                //contextdb.SaveChanges();
                //OnActionExecuting(filterContext);
            }
        }
    }
}