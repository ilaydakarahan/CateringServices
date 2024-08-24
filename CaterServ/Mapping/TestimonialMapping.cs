using AutoMapper;
using CaterServ.DataAccess.Entities;
using CaterServ.Dtos.TestimonialDtos;

namespace CaterServ.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<ResultTestimonialDto , Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialDto , Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDto , UpdateTestimonialDto>().ReverseMap();
        }
    }
}
