using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(Int64 id)
        {
            return _repository.GetById(id);
        }

        public TEntity GetByGuidId(string guidId)
        {
            return _repository.GetByGuidId(guidId);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }
    }
}
