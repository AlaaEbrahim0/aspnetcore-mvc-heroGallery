﻿namespace HeroGallery.Controllers;

public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> logger;

    public ErrorController(ILogger<ErrorController> logger)
    {

        this.logger = logger;
    }

    [Route("/Error/{statusCode}")]
    public IActionResult HttpStatusCodeErrorHandler(int statusCode)
    {
        var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

        switch (statusCode)
        {
            case 404:
                ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                logger.LogWarning($"{statusCode} Error Occured. Path = {statusCodeResult.OriginalPath}" +
                    $" and QueryString = {statusCodeResult.OriginalQueryString}");
                break;
        }
        return View("StatusCodeError");

    }

    [Route("Error")]
    [AllowAnonymous]
    public IActionResult ExceptionErrorHandler()
    {
        var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        logger.LogError($"The path {exceptionDetails.Path} threw an exception " +
            $"{exceptionDetails.Error}");

        return View("ExceptionError");
    }
}
