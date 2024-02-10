using Jazani.Domain.Admins.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Jazani.Infrastructure.Admins.Persistences;

namespace Jazani.Infrastructure.Cores.Contexts
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
			});


            // Domain - Infrastructure
            services.AddTransient<IAreaTypeRepository, AreaTypeRepository>();


            return services;
		}
	}
}

