using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Application.Interfaces
{
    public interface IMenuAppService
    {
        Menu GetMenu();
        List<Sandwich> GetAllSandwich();
        Extra GetExtra();
    }
}
