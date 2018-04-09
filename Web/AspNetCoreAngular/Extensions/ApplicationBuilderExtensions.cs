using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Solution.Web.AspNetCoreAngular.Middlewares;

namespace Solution.Web.AspNetCoreAngular.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void UseCorsCustom(this IApplicationBuilder application)
		{
			void CorsPolicy(CorsPolicyBuilder corsPolicy)
			{
				corsPolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
			}

			application.UseCors(CorsPolicy);
		}

		public static void UseExceptionCustom(this IApplicationBuilder application, IHostingEnvironment environment)
		{
			if (environment.IsDevelopment())
			{
				application.UseDeveloperExceptionPage();
				application.UseDatabaseErrorPage();
			}

			application.UseExceptionMiddleware();
		}

		public static void UseExceptionMiddleware(this IApplicationBuilder application)
		{
			application.UseMiddleware<ExceptionMiddleware>();
		}

		public static void UseMvcCustom(this IApplicationBuilder application)
		{
			void Routes(IRouteBuilder routes)
			{
				routes.MapRoute("default", "{controller}/{action}/{id?}");
			}

			application.UseMvc(Routes);
		}

		public static void UseSpaCustom(this IApplicationBuilder application, IHostingEnvironment environment)
		{
			void Spa(ISpaBuilder spa)
			{
				spa.Options.SourcePath = "ClientApp";

				if (environment.IsDevelopment())
				{
					spa.UseAngularCliServer("development");
					//spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
				}
			}

			application.UseSpa(Spa);
		}
	}
}
