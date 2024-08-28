using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Admin
{
    public class _AdminDashboardReservationComponentPartial : ViewComponent
    {
        private readonly IBookingService _bookingService;

        public _AdminDashboardReservationComponentPartial(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bookingService.GetAllBookings();
            return View(values);
        }
    }
}
