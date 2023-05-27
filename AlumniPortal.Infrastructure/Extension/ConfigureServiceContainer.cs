using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AlumniPortal.Infrastructure.Mapping;
using AlumniPortal.Persistence;
using AlumniPortal.Application.Contract;
using AlumniPortal.Application.Implementation;

namespace AlumniPortal.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AlumniEventProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        }

    }
}
