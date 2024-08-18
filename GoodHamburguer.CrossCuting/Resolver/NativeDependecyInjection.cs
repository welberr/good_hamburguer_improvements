using GoodHamburguer.CrossCuting.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Resolver
{
    public static class NativeDependecyInjection
    {
        public static void BindNativeInjection(IServiceCollection services)
        {
            new MenuModule(services);
            new SandwichModule(services);
            new FriesModule(services);
            new DrinkModule(services);
            new OrderModule(services);
            new OrderSandwichModule(services);
            new OrderFriesModule(services);
            new OrderDrinkModule(services);
        }
    }
}
