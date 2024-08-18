using GoodHamburguer.Data.InMemoryContext;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;

namespace GoodHamburguer.Data
{
    public class OrderDrinkRepository : RepositoryBase<OrderDrink>, IOrderDrinkRepository
    {
        private readonly OrderDrinkContext _orderDrinkContext;

        public OrderDrinkRepository(OrderDrinkContext orderDrinkContext)
        {
            _orderDrinkContext = orderDrinkContext;
        }

        public override void Add(OrderDrink orderDrink)
        {
            _orderDrinkContext.OrdersDrink.Add(orderDrink);
            _orderDrinkContext.SaveChanges();
        }

        public OrderDrink GetByOrderId(int orderId)
        {
            return _orderDrinkContext.OrdersDrink.Where(o => o.OrderId == orderId).FirstOrDefault();
        }

        public override void Remove(OrderDrink orderDrink)
        {
            _orderDrinkContext.Remove(orderDrink);
            _orderDrinkContext.SaveChanges();
        }
    }
}
