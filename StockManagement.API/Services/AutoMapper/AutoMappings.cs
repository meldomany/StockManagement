using AutoMapper;
using StockManagement.Models;
using StockManagement.Models.DTOs.Order;
using StockManagement.Models.DTOs.Stock;

namespace StockManagement.API.Services.AutoMapper
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<StockDto, StockManagement.Models.Stock>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderCreationDto, Order>().ReverseMap();
        }
    }
}
