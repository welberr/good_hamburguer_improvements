using GoodHamburguer.Application;
using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Data;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;
using GoodHamburguer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class OrderModule
    {
        public OrderModule(IServiceCollection services)
        {
            services.AddTransient<IOrderAppService, OrderAppService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
