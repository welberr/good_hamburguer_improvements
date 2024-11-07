using AutoMapper;
using GoodHamburguer.API.Model.Request;
using GoodHamburguer.API.Model.Response;
using GoodHamburguer.API.Validator.Request;
using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Exceptions;
using GoodHamburguer.Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GoodHamburguer.API.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderAppService _orderAppService;
        private readonly OrderRequestValidator _orderRequestValidator;

        public OrderController
        (
            IMapper mapper,
            IOrderAppService orderAppService,
            OrderRequestValidator orderRequestValidator
        )
        {
            _mapper = mapper;
            _orderAppService = orderAppService;
            _orderRequestValidator = orderRequestValidator;
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult AddOrderWithItens([FromBody] OrderRequestModel request)
        {
            _orderRequestValidator.ValidateOrderRequest(request);

            Order order = _mapper.Map<OrderRequestModel, Order>(request);

            _orderAppService.AddOrderWithItens(order);

            return Created(string.Empty, _mapper.Map<Order, OrderResponseModel>(order));
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetAllActiveOrdersWithItens()
        {
            List<OrderResponseModel> orders = _mapper.Map<List<Order>, List<OrderResponseModel>>(_orderAppService.GetAllActiveOrdersWithItens().ToList());

            if(orders.Count() == 0)
                throw new ErrorOnValidationException(ResourceExceptionMessages.NO_ORDERS_WERE_FOUND, HttpStatusCode.BadRequest);

            return Ok(orders);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(OrderUpdateResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateOrderWithItens([FromBody] OrderUpdateRequestModel request)
        {
            Order order = _orderAppService.GetActiveOrderWithItens(request.Id);

            if (order is not Order)
                throw new ErrorOnValidationException(ResourceExceptionMessages.ORDER_NOT_FOUND, HttpStatusCode.BadRequest);

            OrderRequestModel orderRequest = _mapper.Map<OrderUpdateRequestModel, OrderRequestModel>(request);

            _orderRequestValidator.ValidateOrderRequest(orderRequest);

            Order newValues = _mapper.Map<OrderRequestModel, Order>(orderRequest);

            OrderUpdateResponseModel orderUpdateResponseModel = new OrderUpdateResponseModel
            {
                Old = _mapper.Map<Order, OrderResponseModel>(order)
            };

            _orderAppService.UpdateOrderWithItens(order, newValues);

            orderUpdateResponseModel.New = _mapper.Map<Order, OrderResponseModel>(order);
            return Ok(orderUpdateResponseModel);
        }

        [HttpDelete]
        [Route("")]
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult InactivateOrder(int id)
        {
            Order order = _orderAppService.GetActiveOrderWithItens(id);

            if (order is not Order)
                throw new ErrorOnValidationException(ResourceExceptionMessages.ORDER_NOT_FOUND, HttpStatusCode.BadRequest);

            _orderAppService.Remove(order);
            return Ok(order);
        }
    }
}
