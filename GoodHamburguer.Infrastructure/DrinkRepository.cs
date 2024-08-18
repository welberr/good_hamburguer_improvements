using GoodHamburguer.Data.InMemoryContext;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;

namespace GoodHamburguer.Data
{
    public class DrinkRepository : RepositoryBase<Drink>, IDrinkRepository
    {
        private readonly DrinkContext _drinkContext;

        public DrinkRepository(DrinkContext drinkContext)
        {
            _drinkContext = drinkContext;
        }

        public override IEnumerable<Drink> GetAll()
        {
            return _drinkContext.Drink.ToList();
        }

        public override Drink GetById(long id)
        {
            return _drinkContext.Drink.Find((int)id);
        }
    }
}
