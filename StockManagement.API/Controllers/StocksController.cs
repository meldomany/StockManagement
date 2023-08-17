using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Stock.Services.IService;
using StockManagement.API.Services.HubService;
using StockManagement.API.Services.TimerFeatures;
using StockManagement.Models.DTOs.Stock;

namespace StockManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        private readonly IHubContext<StockHub> _hub;
        private readonly TimerManager _timer;

        public StocksController(IStockService stockService, IMapper mapper, IHubContext<StockHub> hub, TimerManager timer)
        {
            _stockService = stockService;
            this._mapper = mapper;
            this._hub = hub;
            this._timer = timer;
        }

        [HttpGet]
        [Route("GetStocks")]
        public IActionResult GetStocks()
        {
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferStockData", _mapper.Map<List<StockDto>>(_stockService.GetStocks())));
 
            return Ok(new { Message = "Request Completed" });
        }

    }
}