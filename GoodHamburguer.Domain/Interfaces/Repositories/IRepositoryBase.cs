namespace GoodHamburguer.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Int64 id);
        TEntity GetByGuidId(string guidId);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
