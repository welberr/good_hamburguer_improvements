using FluentValidation;
using GoodHamburguer.API.Model.Request;
using GoodHamburguer.Domain.Exceptions;
using GoodHamburguer.Domain.Resources;

namespace GoodHamburguer.API.Validator.Request
{
    public class OrderRequestValidator :  AbstractValidator<OrderRequestModel>
    {
        public void ValidateOrderRequest(OrderRequestModel request)
        {
            RuleFor(request => request)
                .Must(HasAtLeastOneItem)
                .WithMessage(ResourceExceptionMessages.MUST_SELECT_AT_LEAST_ONE_QUANTITY);

            RuleFor(request => request)
                .Must(HasValidQuantityForItems)
                .WithMessage(ResourceExceptionMessages.CANNOT_CONTAIN_MORE_THAN_ONE_SANDWICH_FRIES_OR_SODA);

            RuleFor(request => request)
                .Must(HasNonZeroQuantityForItems)
                .WithMessage(ResourceExceptionMessages.PLEASE_CHOOSE_AT_LEAST_ONE_ITEM_FROM_THE_MENU);

            var result = Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }

        private bool HasAtLeastOneItem(OrderRequestModel request)
        {
            return request.Sandwich is SandwichRequestModel ||
                   request.Fries is FriesRequestModel ||
                   request.Drink is DrinkRequestModel;
        }

        private bool HasValidQuantityForItems(OrderRequestModel request)
        {
            return !(request.Sandwich is SandwichRequestModel && request.Sandwich.Quantity > 1) &&
                   !(request.Fries is FriesRequestModel && request.Fries.Quantity > 1) &&
                   !(request.Drink is DrinkRequestModel && request.Drink.Quantity > 1);
        }

        private bool HasNonZeroQuantityForItems(OrderRequestModel request)
        {
            return !(request.Sandwich is SandwichRequestModel && request.Sandwich.Quantity == 0) &&
                   !(request.Fries is FriesRequestModel && request.Fries.Quantity == 0) &&
                   !(request.Drink is DrinkRequestModel && request.Drink.Quantity == 0);
        }
    }
}
