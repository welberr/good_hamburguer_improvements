using AutoMapper;
using GoodHamburguer.API.Model.Request;
using GoodHamburguer.API.Model.Response;
using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.API.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            #region ResponseModel
            CreateMap<MenuResponseModel, Menu>();
            CreateMap<SandwichResponseModel, Sandwich>().ForMember(sandwich => sandwich.Id, map => map.MapFrom(sandwichModel => sandwichModel.Id));
            CreateMap<SandwichResponseModel, Sandwich>();
            CreateMap<ExtraResponseModel, Extra>();
            CreateMap<FriesResponseModel, Fries>();
            CreateMap<DrinkResponseModel, Drink>();
            CreateMap<OrderResponseModel, Order>();
            #endregion

            #region RequestModel
            CreateMap<SandwichRequestModel, Sandwich>();
            CreateMap<FriesRequestModel, Fries>();
            CreateMap<DrinkRequestModel, Drink>();
            CreateMap<OrderRequestModel, Order>();
            CreateMap<OrderUpdateRequestModel, OrderRequestModel>();
            #endregion
        }
    }
}
