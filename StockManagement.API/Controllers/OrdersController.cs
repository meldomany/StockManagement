using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Stock.Services.IService;
using StockManagement.API.Services.HubService;
using StockManagement.Models;
using StockManagement.Models.DTOs.Order;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public OrdersController(IOrderService orderService, 
            IStockService stockService, 
            IMapper mapper, 
            IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _orderService = orderService;
            _stockService = stockService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(_mapper.Map<List<OrderDto>>(await _orderService.GetOrders()));
        }

        [HttpGet]
        [Route("GetOrdersByStockID/{stockID}")]
        public async Task<IActionResult> GetOrdersByStockID(int stockID)
        {
            return Ok(_mapper.Map<List<OrderDto>>(await _orderService.GetOrdersByStockID(stockID)));
        }


        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromForm] OrderCreationDto order)
        {
            if (ModelState.IsValid)
            {
                var newOrder = await _orderService.CreateOrder(_mapper.Map<Order>(order));

                if (newOrder.Id > 0)
                {
                    return StatusCode(201, _mapper.Map<OrderDto>(await _orderService.GetOrderByID(newOrder.Id)));
                }

            }
            return BadRequest(order);
        }
    }
}
