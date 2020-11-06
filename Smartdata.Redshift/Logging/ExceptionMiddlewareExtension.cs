﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Redmap.Data.Access;
using Redmap.Events.Services.Interface;
using System.Net;

namespace Redmap.Events.Logging
{
    /// <summary>
    /// Exception Middleware Extension
    /// </summary>
    public static  class ExceptionMiddlewareExtension
    {
             
       
        /// <summary>
        /// Configure Exception Handler
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public  static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Something went wrong: {contextFeature.Error}");
                        RedmapEvents.saveEvents("http://52.25.96.244:7027/api/Log", "error", ""+ context.Response.StatusCode + "", contextFeature.Error.Message, "redshift server", "source", "summary", "tag1", "tag2", null);
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error != null ? contextFeature.Error.Message : ""
                        }.ToString()) ; ;
                    }
                });
            });
        }
    }
}
