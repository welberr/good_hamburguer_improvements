using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Application
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public virtual void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public virtual TEntity GetById(Int64 id)
        {
            return _serviceBase.GetById(id);
        }

        public virtual TEntity GetByGuidId(string guidId)
        {
            return _serviceBase.GetByGuidId(guidId);
        }

        public virtual void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }
    }
}
