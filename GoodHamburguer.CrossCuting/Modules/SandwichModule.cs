using GoodHamburguer.Data;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;
using GoodHamburguer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.CrossCuting.Modules
{
    public class SandwichModule
    {
        public SandwichModule(IServiceCollection services)
        {
            services.AddTransient<ISandwichService, SandwichService>();
            services.AddTransient<ISandwichRepository, SandwichRepository>();
        }
    }
}
