using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Interfaces.Services;

namespace GoodHamburguer.Application
{
    public class MenuAppService : IMenuAppService
    {
        private readonly ISandwichService _sandwichService;
        private readonly IFriesService _friesService;
        private readonly IDrinkService _drinkService;

        public MenuAppService
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

        public Menu GetMenu()
        {
            return new Menu
            {
                Sandwich = GetAllSandwich(),
                Extra = GetExtra()
            };
        }

        public List<Sandwich> GetAllSandwich()
        {
            return _sandwichService.GetAll().ToList();
        }

        public Extra GetExtra()
        {
            return new Extra
            {
                Fries = GetAllFries(),
                Drink = GetAllDrink()
            };
        }

        public List<Fries> GetAllFries()
        {
            return _friesService.GetAll().ToList();
        }

        public List<Drink> GetAllDrink()
        {
            return _drinkService.GetAll().ToList();
        }
    }
}
