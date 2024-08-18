using GoodHamburguer.Domain.Interfaces.Repositories;

namespace GoodHamburguer.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(Int64 id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetByGuidId(string guidId)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
