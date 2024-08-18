using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Domain.Services
{
    public class FriesService : ServiceBase<Fries>, IFriesService
    {
        private readonly IFriesRepository _friesRepository;

        public FriesService
        (
            IFriesRepository friesRepository

        ) : base (friesRepository)
        {
            _friesRepository = friesRepository;
        }
    }
}
