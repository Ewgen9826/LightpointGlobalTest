using LightpointGlobalTestApp.ViewModels.Error;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace LightpointGlobalTestApp.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            _ = app.UseExceptionHandler(appError =>
              {
                  appError.Run(async context =>
                  {
                      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      context.Response.ContentType = "application/json";
                      context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                      context.Response.Headers.Add("Access-Control-Allow-Methods", "*");

                      var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                      if (contextFeature != null)
                          await context.Response.WriteAsync(new ErrorDetails
                          {
                              StatusCode = context.Response.StatusCode,
                              Error = "Internal Server Error.",
                              Message = $"{contextFeature.Error.Message}"
                          }.ToString());
                  });
              });
        }
    }
}
