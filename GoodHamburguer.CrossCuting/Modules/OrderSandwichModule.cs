using GoodHamburguer.Data;
using GoodHamburguer.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class OrderSandwichModule
    {
        public OrderSandwichModule(IServiceCollection services)
        {
            services.AddTransient<IOrderSandwichRepository, OrderSandwichRepository>();
        }
    }
}
