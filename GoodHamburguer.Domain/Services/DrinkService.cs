using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Domain.Services
{
    public class DrinkService : ServiceBase<Drink>, IDrinkService
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinkService
        (
            IDrinkRepository drinkRepository

        ) : base (drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
    }
}
