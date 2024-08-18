using GoodHamburguer.Data;
using GoodHamburguer.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class OrderFriesModule
    {
        public OrderFriesModule(IServiceCollection services)
        {
            services.AddTransient<IOrderFriesRepository, OrderFriesRepository>();
        }
    }
}
