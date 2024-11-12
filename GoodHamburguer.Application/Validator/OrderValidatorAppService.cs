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
            RuleFor(order => order)
            .Must(HasSandwich)
            .WithMessage(ResourceExceptionMessages.INVALID_SANDWICH);

            RuleFor(order => order)
                .Must(HasFries)
                .WithMessage(ResourceExceptionMessages.INVALID_FRIES);

            RuleFor(order => order)
                .Must(HasDrink)
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
            if (!order.HasOrderId())
                throw new ErrorOnValidationException(new List<string> { ResourceExceptionMessages.UNABLE_TO_CREATE_ORDER });
        }

        private bool HasSandwich(Order order)
        {
            if (!order.HasSandwich())
                return true;

            return _sandwichService.GetById(order.Sandwich.Id) is not null;
        }

        private bool HasFries(Order order)
        {
            if(!order.HasFries())
                return true;

            return _friesService.GetById(order.Fries.Id) is not null;
        }

        private bool HasDrink(Order order)
        {
            if (!order.HasDrink()) 
                return true;

            return _drinkService.GetById(order.Drink.Id) is not null;
        }
    }
}
