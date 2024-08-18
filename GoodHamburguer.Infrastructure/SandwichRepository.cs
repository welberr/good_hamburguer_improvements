using GoodHamburguer.Data.InMemoryContext;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;

namespace GoodHamburguer.Data
{
    public class SandwichRepository : RepositoryBase<Sandwich>, ISandwichRepository
    {
        private readonly SandwichContext _sandwichContext;

        public SandwichRepository(SandwichContext sandwichContext)
        {
            _sandwichContext = sandwichContext;
        }

        public override IEnumerable<Sandwich> GetAll()
        {
            return _sandwichContext.Sandwiches.ToList();
        }

        public override Sandwich GetById(long id)
        {
            return _sandwichContext.Sandwiches.Find((int)id);
        }
    }
}
