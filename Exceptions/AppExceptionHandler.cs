using EmployeeAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();

            if (exception is EmployeeNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Title = "Employee Not Found";
                response.ExceptionMessage = exception.Message;
            }
            else if (exception is ValidationException validationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Title = "Validation Error";
                response.ExceptionMessage = validationException.Message;
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Title = "Internal Server Error";
                response.ExceptionMessage += exception.Message;
            }

            await context.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
