using BallroomDance.API.DAL;
using BallroomDance.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BallroomDance.API.Service.Registeration
{
    public static class RUnitOfWork
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFactory, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services)
                 where TEntity : class
                 where TRepository : class, IBaseRepository<TEntity>
        {
            services.AddScoped<IBaseRepository<TEntity>, TRepository>();

            return services;
        }
    }
}
