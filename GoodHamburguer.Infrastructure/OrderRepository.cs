using GoodHamburguer.Data.InMemoryContext;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Data
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public override void Add(Order order)
        {
            SetOrderItensUnchanged(order);
            _orderContext.Orders.Add(order);
            _orderContext.SaveChanges();
        }

        public override void Remove(Order order)
        {
            order.Active = false;
            Update(order);
        }

        public override void Update(Order order)
        {
            SetOrderItensUnchanged(order);
            _orderContext.Orders.Update(order);
            _orderContext.SaveChanges();
        }

        public Order GetActiveOrder(int id)
        {
            return _orderContext.Orders.Where(o => o.Id == id && o.Active == true).FirstOrDefault();
        }

        public List<Order> GetAllActiveOrders()
        {
            return _orderContext.Orders.Where(o => o.Active == true).ToList();
        }

        private void SetOrderItensUnchanged(Order order)
        {
            if (order.Sandwich is Sandwich)
                _orderContext.Entry(order.Sandwich).State = EntityState.Unchanged;

            if (order.Fries is Fries)
                _orderContext.Entry(order.Fries).State = EntityState.Unchanged;

            if (order.Drink is Drink)
                _orderContext.Entry(order.Drink).State = EntityState.Unchanged;
        }
    }
}
