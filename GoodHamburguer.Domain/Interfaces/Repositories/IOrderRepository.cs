using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Order GetActiveOrder(int id);
        List<Order> GetAllActiveOrders();
    }
}
