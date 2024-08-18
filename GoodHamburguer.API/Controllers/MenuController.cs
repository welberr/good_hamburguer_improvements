using AutoMapper;
using GoodHamburguer.API.Model.Response;
using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguer.API.Controllers
{
    [Route("menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMenuAppService _menuAppService;

        public MenuController
        (
            IMapper mapper,
            IMenuAppService menuAppService
        )
        {
            _mapper = mapper;
            _menuAppService = menuAppService;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(MenuResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetMenu()
        {
            return Ok(_mapper.Map<Menu, MenuResponseModel>(_menuAppService.GetMenu()));
        }

        [HttpGet]
        [Route("~/sandwiches")]
        [ProducesResponseType(typeof(SandwichResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetSandwiches()
        {
            return Ok(_mapper.Map<List<Sandwich>, List<SandwichResponseModel>>(_menuAppService.GetAllSandwich()));
        }

        [HttpGet]
        [Route("~/extra")]
        [ProducesResponseType(typeof(ExtraResponseModel), StatusCodes.Status200OK)]
        public IActionResult GetExtra()
        {
            return Ok(_mapper.Map<Extra, ExtraResponseModel>(_menuAppService.GetExtra()));
        }
    }
}
