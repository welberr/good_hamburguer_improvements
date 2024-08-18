using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Application.Interfaces
{
    public interface IOrderAppService : IServiceBase<Order>
    {
        Order AddOrderWithItens(Order order);
        Order GetActiveOrderWithItens(int id);
        List<Order> GetAllActiveOrdersWithItens();
        bool UpdateOrderWithItens(Order order, Order newValues);
    }
}
