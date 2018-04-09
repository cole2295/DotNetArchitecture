using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Solution.Infrastructure.Databases.EntityFrameworkCore
{
	public static class ModelBuilderExtensions
	{
		public static void ApplyConfigurationFromAssembly(this ModelBuilder modelBuilder)
		{
			Assembly.GetCallingAssembly().GetTypes()
				.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
				.ToList().ForEach(x => modelBuilder.ApplyConfiguration((dynamic)Activator.CreateInstance(x)));
		}
	}
}
