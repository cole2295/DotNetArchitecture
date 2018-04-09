using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Databases.Database.Context;

namespace Solution.Web.AspNetCoreAngular.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddAuthenticationCustom(this IServiceCollection services)
		{
			void JwtBearer(JwtBearerOptions jwtBearer)
			{
				jwtBearer.RequireHttpsMetadata = false;
				jwtBearer.SaveToken = true;
				jwtBearer.TokenValidationParameters = new JsonWebToken().GetTokenValidationParameters();
			}

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
		}

		public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
		{
			Container.RegisterServices(services);
			Container.AddDbContext<DatabaseContext>(configuration.GetConnectionString(nameof(DatabaseContext)));
		}

		public static void AddMvcCustom(this IServiceCollection services)
		{
			void Mvc(MvcOptions mvc)
			{
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				mvc.Filters.Add(new AuthorizeFilter(policy));
			}

			void Json(MvcJsonOptions json)
			{
				json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			}

			services.AddMvc(Mvc).AddJsonOptions(Json);
		}

		public static void AddSpaStaticFilesCustom(this IServiceCollection services)
		{
			services.AddSpaStaticFiles(spa => spa.RootPath = "ClientApp/dist");
		}
	}
}
