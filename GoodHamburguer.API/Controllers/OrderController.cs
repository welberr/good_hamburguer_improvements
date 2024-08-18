using AutoMapper;
using GoodHamburguer.API.Model.Request;
using GoodHamburguer.API.Model.Response;
using GoodHamburguer.API.Validator.Request;
using GoodHamburguer.Application.Interfaces;
using GoodHamburguer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddOrderWithItens([FromBody] OrderRequestModel request)
        {
            if (!_orderRequestValidator.ValidateOrderRequestQuantityZero(request))
                return BadRequest("Must select at least one quantity of the item.");

            if (!_orderRequestValidator.ValidateOrderRequestQuantityItens(request))
                return BadRequest("Cannot contain more than one sandwich, fries or soda.");

            if (!_orderRequestValidator.ValidateOrderRequestItens(request))
                return BadRequest("Please choose at least one item from the menu.");

            Order order = _mapper.Map<OrderRequestModel, Order>(request);

            if (_orderAppService.AddOrderWithItens(order).Id == 0)
                return BadRequest("Unable to create order.");

            return Created(string.Empty, _mapper.Map<Order, OrderResponseModel>(order));
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllActiveOrdersWithItens()
        {
            List<OrderResponseModel> orders = _mapper.Map<List<Order>, List<OrderResponseModel>>(_orderAppService.GetAllActiveOrdersWithItens().ToList());

            if(orders.Count() == 0)
                return NoContent();

            return Ok(orders);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(OrderUpdateResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateOrderWithItens([FromBody] OrderUpdateRequestModel request)
        {
            Order order = _orderAppService.GetActiveOrderWithItens(request.Id);

            if (order is not Order)
                return NoContent();

            OrderRequestModel orderRequest = _mapper.Map<OrderUpdateRequestModel, OrderRequestModel>(request);

            if (!_orderRequestValidator.ValidateOrderRequestQuantityZero(orderRequest))
                return BadRequest("Must select at least one quantity of the item.");

            if (!_orderRequestValidator.ValidateOrderRequestQuantityItens(orderRequest))
                return BadRequest("Cannot contain more than one sandwich, fries or soda.");

            if (!_orderRequestValidator.ValidateOrderRequestItens(orderRequest))
                return BadRequest("Please choose at least one item from the menu.");

            Order newValues = _mapper.Map<OrderRequestModel, Order>(orderRequest);

            OrderUpdateResponseModel orderUpdateResponseModel = new OrderUpdateResponseModel
            {
                Old = _mapper.Map<Order, OrderResponseModel>(order)
            };

            if(!_orderAppService.UpdateOrderWithItens(order, newValues))
                return BadRequest("Unable to update order.");

            orderUpdateResponseModel.New = _mapper.Map<Order, OrderResponseModel>(order);

            return Ok(orderUpdateResponseModel);
        }

        [HttpDelete]
        [Route("")]
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult InactivateOrder(int id)
        {
            Order order = _orderAppService.GetActiveOrderWithItens(id);

            if (order is not Order)
                return NoContent();

            _orderAppService.Remove(order);

            return Ok(order);
        }
    }
}
