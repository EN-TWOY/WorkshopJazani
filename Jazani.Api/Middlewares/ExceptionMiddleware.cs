using System.Net;
using Jazani.Application.Cores.Exceptions;
using Jazani.Api.Exceptions;
using System.Net.Mime;
using Newtonsoft.Json;

namespace Jazani.Api.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var resultError = new ErrorModel();

                HttpStatusCode statusCode;

                switch(exception)
                {
                    case NotFoundCoreException e:
                        _logger.LogWarning("[ExceptionMiddleware] - [NotFoundCoreException] :: {message}", exception.Message);
                        statusCode = HttpStatusCode.NotFound;
                        resultError.Message = e.Message;

                        break;

                    default:
                        _logger.LogError("Error inesperado:: {message}", exception.Message);
                        statusCode = HttpStatusCode.InternalServerError;
                        resultError.Message = "Se ha producido un error inesperado";
                        break;
                }


                var response = context.Response;

                if (!response.HasStarted)
                {
                    response.ContentType = MediaTypeNames.Application.Json;
                    response.StatusCode = (int)statusCode;

                    await response.WriteAsync(JsonConvert.SerializeObject(resultError));
                }

            }
        }
    }
}

