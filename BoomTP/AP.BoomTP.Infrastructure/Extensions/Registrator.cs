using AP.BoomTP.Infrastructure.Contexts;
using AP.BoomTP.Infrastructure.Repositories;
using AP.BoomTP.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Application.Interfaces.GrowSiteI;
using AP.BoomTP.Application.Interfaces.TreeSpeciesI;
using AP.BoomTP.Application.Interfaces.ZoneI;
using AP.BoomTP.Application.Interfaces.UserI;
using AP.BoomTP.Application.Interfaces.TaskI;
using AP.BoomTP.Application.Interfaces.ScheduleI;
using AP.BoomTP.Application.Interfaces.ScheduleTaskI;

namespace AP.BoomTP.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
            services.RegisterRepositories();
            return services;
        }
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<BoomTPContext>(options =>
                        options.UseSqlServer("name=ConnectionStrings:BoomTP"));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IScheduleTaskRepository, ScheduleTaskRepository>();
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<ITreeSpeciesRepository, TreeSpeciesRepository>();
            services.AddScoped<IGrowSiteRepository, GrowSiteRepository>();
            services.AddScoped<IZoneRespository, ZoneRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            return services;
        }
    }
}
