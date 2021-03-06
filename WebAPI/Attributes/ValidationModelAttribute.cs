﻿using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebAPI.Constants;

namespace WebAPI.Attributes
{
    public class ValidationModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
                return;

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessage.INVALID_DATA);
        }
    }
}