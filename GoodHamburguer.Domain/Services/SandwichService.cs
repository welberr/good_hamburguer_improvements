using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Domain.Services
{
    public class SandwichService : ServiceBase<Sandwich>, ISandwichService
    {
        private readonly ISandwichRepository _sandwichRepository;

        public SandwichService
        (
            ISandwichRepository sandwichRepository

        ) : base (sandwichRepository)
        {
            _sandwichRepository = sandwichRepository;
        }
    }
}
