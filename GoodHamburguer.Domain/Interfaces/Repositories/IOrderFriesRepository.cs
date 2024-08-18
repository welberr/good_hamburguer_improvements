using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Interfaces.Repositories
{
    public interface IOrderFriesRepository : IRepositoryBase<OrderFries>
    {
        OrderFries GetByOrderId(int orderId);
    }
}
