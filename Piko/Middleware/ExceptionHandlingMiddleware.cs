using Piko.Dto;
using Piko.Exceptions;
using System.Net;


namespace Piko.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AlreadyExistException ex)
            {
                await HandleExceptionAsync(httpContext, 
                    ex.Message,
                    HttpStatusCode.Conflict,
                    "This record already exist");
            }
            catch (RecordNotFoundException ex)
            {
                await HandleExceptionAsync(httpContext,
                    ex.Message,
                    HttpStatusCode.NotFound,
                    "Record not found");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext,
                    ex.Message,
                    HttpStatusCode.InternalServerError,
                    "Internal server error");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string exMsg, HttpStatusCode httpStatusCode, string message)
        {

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto;
            if (exMsg != null)
            {
                errorDto = new()
                {
                    DetailMessage = exMsg,
                    Message = message,
                    StatusCode = (int)httpStatusCode
                };

            }
            else
            {
                errorDto = new()
                {
                    Message = message,
                    StatusCode = (int)httpStatusCode
                };
            }
            await response.WriteAsJsonAsync(errorDto);
        }
    }
}