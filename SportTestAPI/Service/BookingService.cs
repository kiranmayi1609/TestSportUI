using SportTestAPI.Database;
using SportTestAPI.DataModels;
using SportTestAPI.Dto;
using SportTestAPI.IGenericRepo;
using SportTestAPI.ImplementRepo;

//namespace SportTestAPI.Service
//{
//    public class BookingService
//    {
        
//            private readonly AllRepository<Booking> _repository;
//            private readonly ApplicationDbContext _context;

//            public BookingService(AllRepository<Booking> repository, ApplicationDbContext context)
//            {
//                _repository = repository;
//                _context = context;
//            }

//            public async Task<BookingResponseDto> CreateAsync(BookingRequestDto requestDto)
//            {
//                var booking = new Booking
//                {
//                    UserID = requestDto.UserID,
//                    CourtID = requestDto.CourtID,
//                    Date = requestDto.Date
//                };

//                await _repository.CreateAsync(booking); // Fix: Use AddAsync instead of CreateAsync
//                return new BookingResponseDto
//                {
//                    BookingId = booking.BookingID,
//                    UserID = booking.UserID,
//                    CourtID = booking.CourtID,
//                    Date = booking.Date,
//                    CourtName = _context.Courts.FirstOrDefault(c => c.CourtID == booking.CourtID)?.Name,
//                    Status = "Confirmed"
//                };
//            }

//            public async Task<IEnumerable<BookingResponseDto>> GetAllAsync()
//            {
//                var bookings = await _repository.GetAllAsync();
//                return bookings.Select(b => new BookingResponseDto
//                {
//                    BookingId = b.BookingID,
//                    UserID = b.UserID,
//                    CourtID = b.CourtID,
//                    Date = b.Date,
//                    CourtName = _context.Courts.FirstOrDefault(c => c.CourtID == b.CourtID)?.Name,
//                    Status = "Confirmed"
//                }).ToList();
//            }

//            public async Task<BookingResponseDto> GetByIdAsync(int id)
//            {
//                var booking = await _repository.GetByIdAsync(id);
//                if (booking == null) return null;

//                return new BookingResponseDto
//                {
//                    BookingId = booking.BookingID,
//                    UserID = booking.UserID,
//                    CourtID = booking.CourtID,
//                    Date = booking.Date,
//                    CourtName = _context.Courts.FirstOrDefault(c => c.CourtID == booking.CourtID)?.Name,
//                    Status = "Confirmed"
//                };
//            }

//            public async Task DeleteAsync(int id)
//            {
//                await _repository.DeleteAsync(id);
//            }
//        }

    
//}
