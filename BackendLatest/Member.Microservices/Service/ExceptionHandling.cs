namespace Member.Microservices.Service
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public sealed class ExceptionHandling
    {
        public RequestDelegate requestDelegate;
        public ExceptionHandling(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context, ILogger<ExceptionHandling> logger)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, logger);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex, ILogger<ExceptionHandling> logger)
        {
            // TODO:
            logger.LogError(ex.ToString());

            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = "TAL-EXCEPTION" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}