using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SunstoneProject.Api.Resources.l18n;
using SunstoneProject.Api.Shared;
using SunstoneProject.Domain.Exceptions;
using System.Net;

namespace SunstoneProject.Api.Filters
{
    ///<inheritdoc/>
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;
        private readonly IMessages _messages;

        ///<inheritdoc/>
        public ExceptionFilter(ILogger<ExceptionFilter> logger, IMessages messages)
        {
            _logger = logger;
            _messages = messages;
        }

        ///<inheritdoc/>
        public void OnException(ExceptionContext context)
        {
            this._logger.LogError(context.Exception, $"ExceptionFilter.OnException");

            if ((context.Exception.InnerException ?? context.Exception) is CustomErrorException exception)
            {
                var objectResult = new ObjectResult(new ErrorResponseModel(exception.Code, _messages.GetResources(exception.Code), exception));
                objectResult.StatusCode = (int)HttpStatusCode.BadRequest;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = objectResult;
            }
            else
            {
                var objectResult = new ObjectResult(new ErrorResponseModel("InternalServerError", _messages.GetResources("internalServerError")));
                objectResult.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = objectResult;
            }
        }
    }
}
