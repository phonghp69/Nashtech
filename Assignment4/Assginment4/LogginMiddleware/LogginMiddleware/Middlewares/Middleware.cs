using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogginMiddleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var headers = new Dictionary<string,string>();
            foreach(var item in httpContext.Request.Headers) {
                headers.Add(item.Key, item.Value.ToString());
                }
            var reader = new StreamReader(httpContext.Request.Body);
            var httpRequest = httpContext.Request;
            var body = await reader.ReadToEndAsync();
            var requestData = new
            {

                schema = httpRequest.Scheme,
                host = httpRequest.Host.ToString(),
                path = httpRequest.Path.ToString(),
                queryString = httpRequest.QueryString.ToString(),
                requestBody = body
            };
            
            using( StreamWriter writer = File.AppendText("./RequestLogInfo/TextFile.txt"))
            {
                var data = JsonSerializer.Serialize(requestData);
                await writer.WriteLineAsync(data);
            }
            await _next(httpContext);
        }
       
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
