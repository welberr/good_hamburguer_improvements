using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Exceptions;
using GoodHamburguer.Domain.Interfaces.Services;
using GoodHamburguer.Domain.Resources;
using System.Net;

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

        public void AddOrderWithItens(Order order)
        {
            ValidateOrderItens(order);

            _orderService.SetOrderItens(order);
            _orderService.CalculateAmount(order);
            _orderService.CalculateDiscount(order);
            _orderService.Add(order);

            ValidateOrderAdded(order);

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
            ValidateOrderItens(newValues);

            _orderService.SetOrderItens(newValues);
            _orderService.CalculateAmount(newValues);
            _orderService.CalculateDiscount(newValues);
            _orderService.SetOrderWithNewValues(order, newValues);
            _orderService.Update(order);
            _orderService.RemoveOrderItens(order.Id);
            _orderService.AddOrderItens(order);
        }

        private void ValidateOrderItens(Order order)
        {
            if (order.Sandwich is Sandwich && _sandwichService.GetById(order.Sandwich.Id) is not Sandwich)
                throw new ErrorOnValidationException(ResourceExceptionMessages.INVALID_SANDWICH, HttpStatusCode.BadRequest);

            if (order.Fries is Fries && _friesService.GetById(order.Fries.Id) is not Fries)
                throw new ErrorOnValidationException(ResourceExceptionMessages.INVALID_FRIES, HttpStatusCode.BadRequest);

            if (order.Drink is Drink && _drinkService.GetById(order.Drink.Id) is not Drink)
                throw new ErrorOnValidationException(ResourceExceptionMessages.INVALID_DRINK, HttpStatusCode.BadRequest);
        }

        private void ValidateOrderAdded(Order order)
        {
            var listErrorMessages = new List<string>();

            if (order.Id == 0)
                throw new ErrorOnValidationException(ResourceExceptionMessages.UNABLE_TO_CREATE_ORDER, HttpStatusCode.BadRequest);
        }
    }
}
