using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SunstoneProject.Api.Resources.l18n;
using SunstoneProject.Api.Shared;
using System.Linq;
using System.Net;
using System.Net.Mime;

namespace SunstoneProject.Api.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        private readonly IMessages _messages;
        private readonly ILogger<ValidateModelStateFilter> _logger;

        public ValidateModelStateFilter(ILogger<ValidateModelStateFilter> logger, IMessages messages)
        {
            _logger = logger;
            _messages = messages;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid is false)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(new ErrorResponseModel("BadRequest", _messages.GetResources("ModelValidation"), errors));

                _logger.LogError(string.Join(',', errors));

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            }
        }
    }
}
