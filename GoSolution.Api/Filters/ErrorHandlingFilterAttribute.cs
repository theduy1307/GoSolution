using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoSolution.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var traceId = Activity.Current.TraceId.ToString() ?? "N/A";
        var problemDetails = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = context.Exception.Message,
            Status = (int)HttpStatusCode.InternalServerError,
        };
        problemDetails.Extensions["traceId"] = traceId;
        context.HttpContext.Response.Headers.Add("X-Trace-Id", traceId);
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}