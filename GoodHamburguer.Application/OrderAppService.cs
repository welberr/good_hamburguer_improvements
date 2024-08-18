using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Application
{
    public class OrderAppService : AppServiceBase<Order>, IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly ISandwichService _sandwichService;
        private readonly IFriesService _friesService;
        private readonly IDrinkService _drinkService;

        public OrderAppService
        (
            IOrderService orderService,
            ISandwichService sandwichService,
            IFriesService friesService,
            IDrinkService drinkService

        ) : base (orderService)
        { 
            _orderService = orderService;
            _sandwichService = sandwichService;
            _friesService = friesService;
            _drinkService = drinkService;
        }

        public Order AddOrderWithItens(Order order)
        {
            if (!ValidateAddOrder(order))
                return order;

            _orderService.SetOrderItens(order);
            _orderService.CalculateAmount(order);
            _orderService.CalculateDiscount(order);
            _orderService.Add(order);
            _orderService.AddOrderItens(order);
            return order;
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

        public bool UpdateOrderWithItens(Order order, Order newValues)
        {
            if (!ValidateAddOrder(newValues))
                return false;

            _orderService.SetOrderItens(newValues);
            _orderService.CalculateAmount(newValues);
            _orderService.CalculateDiscount(newValues);
            _orderService.SetOrderWithNewValues(order, newValues);
            _orderService.Update(order);
            _orderService.RemoveOrderItens(order.Id);
            _orderService.AddOrderItens(order);
            return true;
        }

        private bool ValidateAddOrder(Order order)
        {
            if (order.Sandwich is Sandwich && _sandwichService.GetById(order.Sandwich.Id) is not Sandwich)
                return false;

            if (order.Fries is Fries && _friesService.GetById(order.Fries.Id) is not Fries)
                return false;

            if (order.Drink is Drink && _drinkService.GetById(order.Drink.Id) is not Drink)
                return false;

            return true;
        }
    }
}
