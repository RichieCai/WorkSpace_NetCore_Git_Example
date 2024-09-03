using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkPJEx_EF_Repository.Context;
using UnitOfWorkPJEx_EF_Repository.Interface;
using UnitOfWorkPJEx_EF_Repository.Repository;

namespace UnitOfWorkPJEx_EF_Repository
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<dbTestContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefConnectionStr"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<DbContext, dbTestContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
