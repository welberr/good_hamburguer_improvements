using GoodHamburguer.Data;
using GoodHamburguer.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class OrderDrinkModule
    {
        public OrderDrinkModule(IServiceCollection services)
        {
            services.AddTransient<IOrderDrinkRepository, OrderDrinkRepository>();
        }
    }
}
