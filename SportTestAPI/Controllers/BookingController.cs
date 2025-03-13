using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingResponseDto>>> GetBookings()
        {
            return Ok(await _bookingRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingResponseDto>> GetBooking(int id)
        {
            return Ok(await _bookingRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateBooking(BookingRequestDto bookingDto)
        {
            var createdBooking = await _bookingRepository.CreateAsync(bookingDto);
            return CreatedAtAction(nameof(GetBooking), new { id = createdBooking.BookingId}, createdBooking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, BookingRequestDto bookingDto)
        {
            await _bookingRepository.UpdateAsync(id, bookingDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
