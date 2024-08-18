using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Interfaces.Repositories
{
    public interface IOrderDrinkRepository : IRepositoryBase<OrderDrink>
    {
        OrderDrink GetByOrderId(int orderId);
    }
}
