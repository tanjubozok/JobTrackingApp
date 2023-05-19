using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobTracking.WebUI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home", new { area = "Admin" });
    }

    public IActionResult Error()
    {
        var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        var error = errorInfo?.Error;
        var path = errorInfo?.Path;

        ProblemDetails problemDetails = new()
        {
            Title = "Apide bir hata oluştu",
            Detail = "En kısa sürede düzeltilecektir",
            Status = (int)HttpStatusCode.InternalServerError,
            Instance = path,
            Extensions =
            {
                ["message"] = error?.Message,
                //["data"] = error?.Data,
                //["helpLink"] = error?.HelpLink,
                //["hResult"] = error?.HResult,
                //["innerException"] = error?.InnerException,
                //["source"] = error?.Source,
                //["stackTrace"] = error?.StackTrace,
                //["targetSite"] = error?.TargetSite,
                //["displayName"] = errorInfo?.Endpoint?.DisplayName,
                //["metadata"] = errorInfo?.Endpoint?.Metadata,
                //["requestDelegate"] = errorInfo?.Endpoint?.RequestDelegate,
                //["routeValues"] = errorInfo?.RouteValues
            }
        };

        return StatusCode((int)HttpStatusCode.InternalServerError, problemDetails);

    }
}
