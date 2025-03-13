using AutoMapper;
using SportTestAPI.Database;
using SportTestAPI.DataModels;
using SportTestAPI.Dto;
using SportTestAPI.IGenericRepo;

namespace SportTestAPI.ImplementRepo
{
    public interface IBookingRepository : IGenericRepository<Booking, BookingRequestDto, BookingResponseDto> { }
    public interface IAgeGroupRepository:IGenericRepository<AgeGroup,AgeGroupRequestDto,AgeGroupResponseDto> { }
    public interface IMatchRepository:IGenericRepository<Match,MatchRequestDto,MatchResponseDto> { }

    public interface ICoachRepository:IGenericRepository<Coach,CoachRequestDto,CoachResponseDto> { }

    public interface ICourtRepository:IGenericRepository<Court,CourtRequestDto,CourtResponseDto> { }

    public interface IInvoiceRepository:IGenericRepository<Invoice,InvoiceRequestDto,InvoiceResponseDto> { }

    public interface ITournmentRepository:IGenericRepository<Tournment,TournamentRequestDto,TournamentResponseDto> { }

    public interface ITrainingSessionRepository:IGenericRepository<TrainingSession,TrainingSessionRequestDto,TrainingSessionResponseDto> { }


    



    public class BookingRepository:GenericRepo<Booking,BookingRequestDto,BookingResponseDto>,IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


    }

    public class AgeGroupRepository:GenericRepo<AgeGroup,AgeGroupRequestDto,AgeGroupResponseDto>,IAgeGroupRepository
    {
        public AgeGroupRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper) { }
    }

    public class CoachRepository:GenericRepo<Coach,CoachRequestDto,CoachResponseDto>,ICoachRepository
    {
        public CoachRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper) { }
    }

    public class CourtRepository:GenericRepo<Court,CourtRequestDto,CourtResponseDto>,ICourtRepository
    {
        public CourtRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper)
        {

        }
    }

    public class InvoiceRepository:GenericRepo<Invoice,InvoiceRequestDto,InvoiceResponseDto>,IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context,IMapper mapper) : base(context, mapper) { }
    }

    public class MatchRepository:GenericRepo<Match,MatchRequestDto,MatchResponseDto>,IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper) { }
       
    }
    public class TournmentRepository:GenericRepo<Tournment,TournamentRequestDto,TournamentResponseDto>,ITournmentRepository
    {
        public TournmentRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper) { }
       
    }

    public class TrainingSessionRepository:GenericRepo<TrainingSession,TrainingSessionRequestDto,TrainingSessionResponseDto>,ITrainingSessionRepository
    {
        public TrainingSessionRepository(ApplicationDbContext context,IMapper mapper):base(context,mapper) { }

       
    }
}