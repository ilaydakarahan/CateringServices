using CaterServ.Dtos.TestimonialDtos;

namespace CaterServ.Services.Abstract
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonials();
        Task<ResultTestimonialDto> GetTestimonailById(string id);
        Task UpdateTestimonial(UpdateTestimonialDto testimonailDto);
        Task CreateTestimonial(CreateTestimonialDto testimonailDto);
        Task DeleteTestimonial(string id);
    }
}
