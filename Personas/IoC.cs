using Aplication.Interfaces;
using Aplication.Services;
using Core.Repositories;
using Core.Repositories.Base;
using Infraestructure.Repositories;
using Infraestructure.Repositories.Base;

namespace Personas
{
    public static class IoC
    {

        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            
            return services;
        }
    }
}
