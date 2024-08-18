using GoodHamburguer.Data;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;
using GoodHamburguer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class FriesModule
    {
        public FriesModule(IServiceCollection services)
        {
            services.AddTransient<IFriesService, FriesService>();
            services.AddTransient<IFriesRepository, FriesRepository>();
        }
    }
}
