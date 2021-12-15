
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace portfolio.Infrastructure.Filters
{

    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var c = (filterContext.Controller as Controller);
            c.TempData["ModelState"] = c.ViewData;
        }
    }

    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var c = (filterContext.Controller as Controller);

            if (c.TempData.ContainsKey("ModelState"))
            {
                c.ViewData.ModelState.Merge(
                    (ModelStateDictionary)c.TempData["ModelState"]);
            }
        }
    }
}