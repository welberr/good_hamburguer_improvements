using GoodHamburguer.CrossCuting.Resolver;

namespace GoodHamburguer.API.Configurations
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new Exception(nameof(services));

            NativeDependecyInjection.BindNativeInjection(services);
        }
    }
}
