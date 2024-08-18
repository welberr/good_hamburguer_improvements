using GoodHamburguer.Data;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;
using GoodHamburguer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class DrinkModule
    {
        public DrinkModule(IServiceCollection services)
        {
            services.AddTransient<IDrinkService, DrinkService>();
            services.AddTransient<IDrinkRepository, DrinkRepository>();
        }
    }
}
