using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.StatisticDtos;

namespace CaterServ.Mapping
{
    public class StatisticMapping : Profile
    {
        public StatisticMapping() 
        {
            CreateMap<Statistic , ResultStatisticDto>().ReverseMap();
            CreateMap<Statistic , CreateStatisticDto>().ReverseMap();
            CreateMap<Statistic , UpdateStatisticDto>().ReverseMap();
            CreateMap<UpdateStatisticDto , ResultStatisticDto>().ReverseMap();
        }

    }
}
