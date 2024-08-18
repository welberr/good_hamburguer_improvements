using GoodHamburguer.Application;
using GoodHamburguer.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class MenuModule
    {
        public MenuModule(IServiceCollection services)
        {
            services.AddTransient<IMenuAppService, MenuAppService>();
        }
    }
}
