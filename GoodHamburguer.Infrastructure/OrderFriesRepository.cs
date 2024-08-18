using GoodHamburguer.Data.InMemoryContext;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;

namespace GoodHamburguer.Data
{
    public class OrderFriesRepository : RepositoryBase<OrderFries>, IOrderFriesRepository
    {
        private readonly OrderFriesContext _orderFriesContext;

        public OrderFriesRepository(OrderFriesContext orderFriesContext)
        {
            _orderFriesContext = orderFriesContext;
        }

        public override void Add(OrderFries orderFries)
        {
            _orderFriesContext.OrdersFries.Add(orderFries);
            _orderFriesContext.SaveChanges();
        }

        public OrderFries GetByOrderId(int orderId)
        {
            return _orderFriesContext.OrdersFries.Where(o => o.OrderId == orderId).FirstOrDefault();
        }

        public override void Remove(OrderFries orderFries)
        {
            _orderFriesContext.Remove(orderFries);
            _orderFriesContext.SaveChanges();
        }
    }
}
