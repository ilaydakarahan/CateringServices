using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.FeatureDtos;

namespace CaterServ.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<ResultFeatureDto, Feature>().ReverseMap();
            CreateMap<CreateFeatureDto, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDto, Feature>().ReverseMap();
            CreateMap<ResultFeatureDto, UpdateFeatureDto>().ReverseMap();
        }
    }
}
