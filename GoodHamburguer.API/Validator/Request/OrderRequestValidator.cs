using GoodHamburguer.API.Model.Request;
using GoodHamburguer.Domain.Exceptions;
using GoodHamburguer.Domain.Resources;
using System.Net;

namespace GoodHamburguer.API.Validator.Request
{
    public class OrderRequestValidator
    {
        public void ValidateOrderRequest(OrderRequestModel request)
        {
            ValidateOrderRequestItens(request);
            ValidateOrderRequestQuantityItens(request);
            ValidateOrderRequestQuantityZero(request);
        }

        private void ValidateOrderRequestItens(OrderRequestModel request)
        {
            if (request.Sandwich is not SandwichRequestModel && 
                request.Fries is not FriesRequestModel && 
                request.Drink is not DrinkRequestModel)
            {
                throw new ErrorOnValidationException(ResourceExceptionMessages.MUST_SELECT_AT_LEAST_ONE_QUANTITY, HttpStatusCode.BadRequest);
            }
        }

        private void ValidateOrderRequestQuantityItens(OrderRequestModel request)
        {
            if ((request.Sandwich is SandwichRequestModel && request.Sandwich.Quantity > 1) || 
                (request.Fries is FriesRequestModel && request.Fries.Quantity > 1) || 
                (request.Drink is DrinkRequestModel && request.Drink.Quantity > 1))
            {
                throw new ErrorOnValidationException(ResourceExceptionMessages.CANNOT_CONTAIN_MORE_THAN_ONE_SANDWICH_FRIES_OR_SODA, HttpStatusCode.BadRequest);
            }
        }

        private void ValidateOrderRequestQuantityZero(OrderRequestModel request)
        {
            if ((request.Sandwich is SandwichRequestModel && request.Sandwich.Quantity == 0) || 
                (request.Fries is FriesRequestModel && request.Fries.Quantity == 0) || 
                (request.Drink is DrinkRequestModel && request.Drink.Quantity == 0))
            {
                throw new ErrorOnValidationException(ResourceExceptionMessages.PLEASE_CHOOSE_AT_LEAST_ONE_ITEM_FROM_THE_MENU, HttpStatusCode.BadRequest);
            }
        }
    }
}
