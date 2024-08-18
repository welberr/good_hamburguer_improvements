using GoodHamburguer.Data.InMemoryContext;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;

namespace GoodHamburguer.Data
{
    public class FriesRepository : RepositoryBase<Fries>, IFriesRepository
    {
        private readonly FriesContext _friesContext;

        public FriesRepository(FriesContext friesContext)
        {
            _friesContext = friesContext;
        }

        public override IEnumerable<Fries> GetAll()
        {
            return _friesContext.Fries.ToList();
        }

        public override Fries GetById(long id)
        {
            return _friesContext.Fries.Find((int)id);
        }
    }
}
