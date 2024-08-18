using GoodHamburguer.API.Model.Request;

namespace GoodHamburguer.API.Validator.Request
{
    public class OrderRequestValidator
    {
        public bool ValidateOrderRequestItens(OrderRequestModel request)
        {
            if (request.Sandwich is not SandwichRequestModel && request.Fries is not FriesRequestModel && request.Drink is not DrinkRequestModel)
                return false;

            return true;
        }

        public bool ValidateOrderRequestQuantityItens(OrderRequestModel request)
        {
            if (request.Sandwich is SandwichRequestModel && request.Sandwich.Quantity > 1)
                return false;

            if (request.Fries is FriesRequestModel && request.Fries.Quantity > 1)
                return false;

            if (request.Drink is DrinkRequestModel && request.Drink.Quantity > 1)
                return false;

            return true;
        }

        public bool ValidateOrderRequestQuantityZero(OrderRequestModel request)
        {
            if (request.Sandwich is SandwichRequestModel && request.Sandwich.Quantity == 0)
                return false;

            if (request.Fries is FriesRequestModel && request.Fries.Quantity == 0)
                return false;

            if (request.Drink is DrinkRequestModel && request.Drink.Quantity == 0)
                return false;

            return true;
        }
    }
}
