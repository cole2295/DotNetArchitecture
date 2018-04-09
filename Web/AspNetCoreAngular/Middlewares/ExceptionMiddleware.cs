using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Solution.CrossCutting.Extensions;
using Solution.CrossCutting.Values;

namespace Solution.Web.AspNetCoreAngular.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly IHostingEnvironment _environment;
		private readonly RequestDelegate _requestDelegate;

		public ExceptionMiddleware(IHostingEnvironment environment, RequestDelegate requestDelegate)
		{
			_environment = environment;
			_requestDelegate = requestDelegate;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _requestDelegate(context);
			}
			catch (DomainException exception)
			{
				context.Response.Clear();
				context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(exception.Message);
			}
			catch (Exception exception)
			{
				if (_environment.IsDevelopment()) { throw; }
				context.Response.Clear();
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				context.Response.ContentType = MediaTypeNames.Text.Plain;
				await context.Response.WriteAsync(exception.GetDetail());
			}
		}
	}
}
