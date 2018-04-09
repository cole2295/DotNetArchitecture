using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Solution.Application.Applications;
using Solution.CrossCutting.Logging;
using Solution.CrossCutting.Mapping;
using Solution.CrossCutting.Security;
using Solution.Domain.Domains;
using Solution.Infrastructure.Databases.Database.Repositories;
using Solution.Infrastructure.Databases.Database.UnitOfWork;

namespace Solution.CrossCutting.DependencyInjection
{
	public static class Container
	{
		private static IServiceProvider ServiceProvider { get; set; }

		private static IServiceCollection Services { get; set; }

		public static void AddDbContext<T>(string connectionString) where T : DbContext
		{
			Services.AddDbContext<T>(options => options.UseSqlServer(connectionString));
		}

		public static void AddDbContextInMemoryDatabase<T>() where T : DbContext
		{
			Services.AddDbContext<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
		}

		public static T GetService<T>()
		{
			if (Services == null)
			{
				Services = RegisterServices();
			}

			if (ServiceProvider == null)
			{
				ServiceProvider = Services.BuildServiceProvider();
			}

			return ServiceProvider.GetService<T>();
		}

		public static IServiceCollection RegisterServices(IServiceCollection services = null)
		{
			Services = services ?? new ServiceCollection();

			// Solution.Application.Applications
			Services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
			Services.AddScoped<IUserApplication, UserApplication>();

			// Solution.CrossCutting
			Services.AddScoped<ICriptography, Criptography>();
			Services.AddScoped<IHash, Hash>();
			Services.AddScoped<IJsonWebToken, JsonWebToken>();
			Services.AddScoped<ILogging, Logging.Logging>();
			Services.AddScoped<IMapping, Mapping.Mapping>();

			// Solution.Domain.Domains
			Services.AddScoped<IAuthenticationDomain, AuthenticationDomain>();
			Services.AddScoped<IUserDomain, UserDomain>();
			Services.AddScoped<IUserLogDomain, UserLogDomain>();

			// Solution.Infrastructure.Databases.Database
			Services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();
			Services.AddScoped<IUserLogRepository, UserLogRepository>();
			Services.AddScoped<IUserRepository, UserRepository>();
			Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

			return Services;
		}
	}
}
