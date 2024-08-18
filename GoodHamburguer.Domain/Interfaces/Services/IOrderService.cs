using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Interfaces.Services
{
    public interface IOrderService : IServiceBase<Order>
    {
        void AddOrderItens(Order order);
        Order GetActiveOrder(int id);
        List<Order> GetAllActiveOrders();
        void RemoveOrderItens(int id);
        void SetOrderWithNewValues(Order order, Order newValues);
        void SetOrderItens(Order order);
        void SetOrderSandwichItem(Order order);
        void SetOrderFriesItem(Order order);
        void SetOrderDrinkItem(Order order);
        void CalculateAmount(Order order);
        void CalculateDiscount(Order order);
    }
}
