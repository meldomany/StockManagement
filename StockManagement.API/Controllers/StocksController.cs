using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Stock.Services.IService;
using StockManagement.API.Services.HubService;
using StockManagement.Models.DTOs.Stock;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public StocksController(IStockService stockService, 
            IMapper mapper, 
            IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _stockService = stockService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("GetStocks")]
        public async Task<IActionResult> GetStocks()
        {
            return Ok(_mapper.Map<List<StockDto>>(await _stockService.GetStocks()));
        }

        [HttpGet]
        [Route("UpdateStocks")]
        public async Task<IActionResult> UpdateStocks()
        {
            await _stockService.UpdateStocks();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
    }
}