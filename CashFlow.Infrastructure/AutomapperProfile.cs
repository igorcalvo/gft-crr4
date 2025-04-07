using AutoMapper;
using CashFlow.Domain.DTOs;
using CashFlow.Domain.Entities;

namespace CashFlow.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EntryDto, Entry>();
            CreateMap<Entry, EntryDto>();
        }
    }
}
