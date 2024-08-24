using CaterServ.Dtos.BookingDtos;

namespace CaterServ.Services.Abstract
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllBookings();

        Task<ResultBookingDto> GetBookingById(string id);

        Task UpdateBooking(UpdateBookingDto updateBookingDto);
        Task CreateBooking(CreateBookingDto createBookingDto); 
        Task DeleteBooking(string id);
        Task<List<ResultBookingDto>> SearchBooking(string nameSurname);
    }
}
