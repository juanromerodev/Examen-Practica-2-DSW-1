using System.Net;
//Trayendo las clases de excepciones que creamos y asignados
using BadRequestException = examen_cl2_dsw1.Exceptions.BadRequestException;
using KeyNotFoundException = examen_cl2_dsw1.Exceptions.KeyNotFoundException;
using NotFoundException = examen_cl2_dsw1.Exceptions.NotFoundException;
using UnauthourizedException = examen_cl2_dsw1.Exceptions.UnauthourizedException;
using System.Text.Json;

namespace examen_cl2_dsw1.Exceptions
{
    public class GlobalExceptionHandler
    {
        //next sirve para continuar con el siguiente pipeline si esta satisfecho
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            this._next = next;
        }

        //Realizamos la invocacion y comprobamos si no hay errores
        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Si no los hay prosigue el proceso
                await _next(context);
            }
            catch (Exception ex)
            {
                //Si los hay, trabajara el metodo HandleExceptionAsync()
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //Declaramos las variables del status, la fecha de registro, el registro tecnico del error y el mensaje
            HttpStatusCode statusCode;
            DateTime timeStamp = DateTime.Now;
            string? stackTrace;
            string message;
            //Obtener el tipo de excepcion
            var exType = ex.GetType();

            //Segun el tipo de excepcion elaborada, mandamos un status
            if (exType == typeof(BadRequestException))
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exType == typeof(KeyNotFoundException))
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exType == typeof(UnauthourizedException))
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exType == typeof(NotFoundException))
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                //Si no es, mandamos el status 500
                statusCode = HttpStatusCode.InternalServerError;
            }

            //Asignamos el valor del mensaje y registro tecnico
            message = ex.Message;
            stackTrace = ex.StackTrace;

            //Serializamos a un objeto JSON
            var exceptionResult = JsonSerializer.Serialize(new
            {
                error = timeStamp,
                message,
                stackTrace
            });

            //Configuramos la respuesta
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            //Enviamos la respuesta
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}

