namespace GoodHamburguer.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        TEntity GetByGuidId(string guidId);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
