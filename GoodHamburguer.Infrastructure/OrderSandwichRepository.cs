using GoodHamburguer.Data.InMemoryContext;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;

namespace GoodHamburguer.Data
{
    public class OrderSandwichRepository : RepositoryBase<OrderSandwich>, IOrderSandwichRepository
    {
        private readonly OrderSandwichContext _orderSandwichContext;

        public OrderSandwichRepository(OrderSandwichContext orderSandwichContext)
        {
            _orderSandwichContext = orderSandwichContext;
        }

        public override void Add(OrderSandwich orderSandwich)
        {
            _orderSandwichContext.OrdersSandwich.Add(orderSandwich);
            _orderSandwichContext.SaveChanges();
        }

        public OrderSandwich GetByOrderId(int id)
        {
            return _orderSandwichContext.OrdersSandwich.Where(o => o.OrderId == id).FirstOrDefault();
        }

        public override void Remove(OrderSandwich orderSandwich)
        {
            _orderSandwichContext.Remove(orderSandwich);
            _orderSandwichContext.SaveChanges();
        }
    }
}
