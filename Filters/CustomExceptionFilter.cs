using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LoginDemo.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _logger.LogError(context.Exception, "An error occurred during request execution");

            // Optionally, set a custom response
            context.Result = new ViewResult
            {
                ViewName = "Error"
            };

            context.ExceptionHandled = true;  // Mark exception as handled to prevent further propagation
        }
    }
}
