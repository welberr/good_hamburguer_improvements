using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Interfaces.Repositories
{
    public interface IOrderSandwichRepository : IRepositoryBase<OrderSandwich>
    {
        OrderSandwich GetByOrderId(int orderId);
    }
}
