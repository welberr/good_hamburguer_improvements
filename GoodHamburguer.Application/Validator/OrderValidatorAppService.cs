using FluentValidation;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Exceptions;
using GoodHamburguer.Domain.Interfaces.Services;
using GoodHamburguer.Domain.Resources;

namespace GoodHamburguer.Application.Validator
{
    public class OrderValidatorAppService : AbstractValidator<Order>
    {
        private readonly ISandwichService _sandwichService;
        private readonly IFriesService _friesService;
        private readonly IDrinkService _drinkService;

        public OrderValidatorAppService
        (
            ISandwichService sandwichService,
            IFriesService friesService,
            IDrinkService drinkService
        ) 
        {
            _sandwichService = sandwichService;
            _friesService = friesService;
            _drinkService = drinkService;
        }

        public void ValidateOrderItens(Order order)
        {
            RuleFor(order => order.Sandwich)
            .Must(IsValidSandwich)
            .WithMessage(ResourceExceptionMessages.INVALID_SANDWICH);

            RuleFor(order => order.Fries)
                .Must(IsValidFries)
                .WithMessage(ResourceExceptionMessages.INVALID_FRIES);

            RuleFor(order => order.Drink)
                .Must(IsValidDrink)
                .WithMessage(ResourceExceptionMessages.INVALID_DRINK);

            var result = Validate(order);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }

        public void ValidateOrderAdded(Order order)
        {
            if (order.Id == 0)
                throw new ErrorOnValidationException(new List<string> { ResourceExceptionMessages.UNABLE_TO_CREATE_ORDER });
        }

        private bool IsValidSandwich(Sandwich sandwich)
        {
            if (sandwich is not Sandwich) return true;
            return _sandwichService.GetById(sandwich.Id) is not null;
        }

        private bool IsValidFries(Fries fries)
        {
            if (fries is not Fries) return true;
            return _friesService.GetById(fries.Id) is not null;
        }

        private bool IsValidDrink(Drink drink)
        {
            if (drink is not Drink) return true;
            return _drinkService.GetById(drink.Id) is not null;
        }
    }
}
