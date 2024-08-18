using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Repositories;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Domain.Services
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISandwichRepository _sandwichRepository;
        private readonly IFriesRepository _friesRepository;
        private readonly IDrinkRepository _drinkRepository;
        private readonly IOrderSandwichRepository _orderSandwichRepository;
        private readonly IOrderFriesRepository _orderFriesRepository;
        private readonly IOrderDrinkRepository _orderDrinkRepository;

        public OrderService
        (
            IOrderRepository orderRepository,
            ISandwichRepository sandwichRepository,
            IFriesRepository friesRepository,
            IDrinkRepository drinkRepository,
            IOrderSandwichRepository orderSandwichRepository,
            IOrderFriesRepository orderFriesRepository,
            IOrderDrinkRepository orderDrinkRepository

        ) : base ( orderRepository )
        {
            _orderRepository = orderRepository;
            _sandwichRepository = sandwichRepository;
            _friesRepository = friesRepository;
            _drinkRepository = drinkRepository;
            _orderSandwichRepository = orderSandwichRepository;
            _orderFriesRepository = orderFriesRepository;
            _orderDrinkRepository = orderDrinkRepository;
        }

        public void AddOrderItens(Order order)
        {
            if (order.Sandwich is Sandwich)
                _orderSandwichRepository.Add(new OrderSandwich { OrderId = order.Id, SandwichId = order.Sandwich.Id });

            if (order.Fries is Fries)
                _orderFriesRepository.Add(new OrderFries { OrderId = order.Id, FriesId = order.Fries.Id });

            if (order.Drink is Drink)
                _orderDrinkRepository.Add(new OrderDrink { OrderId = order.Id, DrinkId = order.Drink.Id });
        }

        public List<Order> GetAllActiveOrders()
        {
            return _orderRepository.GetAllActiveOrders();
        }

        public Order GetActiveOrder(int id)
        {
            return _orderRepository.GetActiveOrder(id);
        }

        public void RemoveOrderItens(int id)
        {
            OrderSandwich orderSandwich = _orderSandwichRepository.GetByOrderId(id);
            if(orderSandwich is OrderSandwich)
                _orderSandwichRepository.Remove(orderSandwich);

            OrderFries orderFries = _orderFriesRepository.GetByOrderId(id);
            if (orderFries is OrderFries)
                _orderFriesRepository.Remove(orderFries);

            OrderDrink orderDrink = _orderDrinkRepository.GetByOrderId(id);
            if (orderDrink is OrderDrink)
                _orderDrinkRepository.Remove(orderDrink);
        }

        public void SetOrderWithNewValues(Order order, Order newValues)
        {
            order.Sandwich = newValues.Sandwich;
            order.Fries = newValues.Fries;
            order.Drink = newValues.Drink;
            order.Amount = newValues.Amount;
            order.Discount = newValues.Discount;
            order.FinalAmount = newValues.FinalAmount;
        }

        public void SetOrderItens(Order order)
        {
            if (order.Sandwich is Sandwich)
                order.Sandwich = _sandwichRepository.GetById(order.Sandwich.Id);

            if (order.Fries is Fries)
                order.Fries = _friesRepository.GetById(order.Fries.Id);

            if (order.Drink is Drink)
                order.Drink = _drinkRepository.GetById(order.Drink.Id);
        }

        public void SetOrderSandwichItem(Order order)
        {
            OrderSandwich orderSandwich = _orderSandwichRepository.GetByOrderId(order.Id);
            if (orderSandwich is OrderSandwich)
                order.Sandwich = _sandwichRepository.GetById(orderSandwich.SandwichId);
        }

        public void SetOrderFriesItem(Order order)
        {
            OrderFries orderFries = _orderFriesRepository.GetByOrderId(order.Id);
            if (orderFries is OrderFries)
                order.Fries = _friesRepository.GetById(orderFries.FriesId);
        }

        public void SetOrderDrinkItem(Order order)
        {
            OrderDrink orderDrink = _orderDrinkRepository.GetByOrderId(order.Id);
            if (orderDrink is OrderDrink)
                order.Drink = _drinkRepository.GetById(orderDrink.DrinkId);
        }

        public void CalculateAmount(Order order)
        {
            if (order.Sandwich is Sandwich)
                order.Amount = order.FinalAmount += order.Sandwich.Price;

            if (order.Fries is Fries)
                order.Amount = order.FinalAmount += order.Fries.Price;

            if (order.Drink is Drink)
                order.Amount = order.FinalAmount += order.Drink.Price;
        }

        public void CalculateDiscount(Order order)
        {
            if (order.Sandwich is Sandwich && order.Fries is Fries && order.Drink is Drink)
            {
                order.Discount = order.Amount - (order.Amount * 0.80m);
                order.FinalAmount = order.Amount - order.Discount;
                return;
            }

            if (order.Sandwich is Sandwich && order.Fries is Fries)
            {
                order.Discount = order.Amount - (order.Amount * 0.90m);
                order.FinalAmount = order.Amount - order.Discount;
                return;
            }

            if (order.Sandwich is Sandwich && order.Drink is Drink)
            {
                order.Discount = order.Amount - (order.Amount * 0.85m);
                order.FinalAmount = order.Amount - order.Discount;
                return;
            }
        }
    }
}
