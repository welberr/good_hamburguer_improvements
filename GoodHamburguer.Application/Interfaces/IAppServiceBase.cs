namespace GoodHamburguer.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Int64 id);
        TEntity GetByGuidId(string guidId);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
