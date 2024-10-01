using AutoMapper;
using GoodHamburguer.API.Model.Request;
using GoodHamburguer.API.Model.Response;
using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.API.Pro
{
    public class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            #region ResponseModel
            CreateMap<Menu, MenuResponseModel>();
            CreateMap<Sandwich, SandwichResponseModel>().ForMember(sandwichModel => sandwichModel.Id, map => map.MapFrom(sandwich => sandwich.Id));
            CreateMap<Sandwich, SandwichResponseModel>();
            CreateMap<Extra, ExtraResponseModel>();
            CreateMap<Fries, FriesResponseModel>();
            CreateMap<Drink, DrinkResponseModel>();
            CreateMap<Order, OrderResponseModel>();
            #endregion

            #region RequestModel
            CreateMap<Sandwich, SandwichRequestModel>();
            CreateMap<Fries, FriesRequestModel>();
            CreateMap<Drink, DrinkRequestModel>();
            CreateMap<Order, OrderRequestModel>();
            #endregion
        }
    }
}
