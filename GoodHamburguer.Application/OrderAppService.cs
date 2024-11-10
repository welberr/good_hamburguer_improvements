using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Application.Validator;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Application
{
    public class OrderAppService : AppServiceBase<Order>, IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly OrderValidatorAppService _orderValidatorAppService;

        public OrderAppService
        (
            IOrderService orderService,
            OrderValidatorAppService orderValidatorAppService   

        ) : base (orderService)
        { 
            _orderService = orderService;
            _orderValidatorAppService = orderValidatorAppService;
        }

        public void AddOrderWithItens(Order order)
        {
            _orderValidatorAppService.ValidateOrderItens(order);

            _orderService.SetOrderItens(order);
            _orderService.CalculateAmount(order);
            _orderService.CalculateDiscount(order);
            _orderService.Add(order);

            _orderValidatorAppService.ValidateOrderAdded(order);

            _orderService.AddOrderItens(order);
        }

        public Order GetActiveOrderWithItens(int id)
        {
            Order order = _orderService.GetActiveOrder(id);

            if (order is Order)
            {
                _orderService.SetOrderSandwichItem(order);
                _orderService.SetOrderFriesItem(order);
                _orderService.SetOrderDrinkItem(order);
            }
            
            return order;
        }

        public List<Order> GetAllActiveOrdersWithItens() 
        {
            List<Order> orders = _orderService.GetAllActiveOrders();

            foreach (var order in orders)
            {
                _orderService.SetOrderSandwichItem(order);
                _orderService.SetOrderFriesItem(order);
                _orderService.SetOrderDrinkItem(order);
            }

            return orders;
        }

        public void UpdateOrderWithItens(Order order, Order newValues)
        {
            _orderValidatorAppService.ValidateOrderItens(newValues);

            _orderService.SetOrderItens(newValues);
            _orderService.CalculateAmount(newValues);
            _orderService.CalculateDiscount(newValues);
            _orderService.SetOrderWithNewValues(order, newValues);
            _orderService.Update(order);
            _orderService.RemoveOrderItens(order.Id);
            _orderService.AddOrderItens(order);
        }
    }
}
