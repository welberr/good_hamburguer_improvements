using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Application.Interfaces
{
    public interface IOrderAppService : IServiceBase<Order>
    {
        void AddOrderWithItens(Order order);
        Order GetActiveOrderWithItens(int id);
        List<Order> GetAllActiveOrdersWithItens();
        void UpdateOrderWithItens(Order order, Order newValues);
    }
}
