using AutoMapper;
using SportTestAPI.DataModels;
using SportTestAPI.Dto;

namespace SportTestAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingResponseDto>()
                .ForMember(dest => dest.CourtName, opt => opt.MapFrom(src => src.Court.Name));
            CreateMap<BookingRequestDto, Booking>();

            CreateMap<AgeGroup, AgeGroupResponseDto>().
                ForMember(dest => dest.AgeGroupID, opt => opt.MapFrom(src => src.AgeGroupID)).
                ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.AvailableDays));
            CreateMap<AgeGroupRequestDto, AgeGroup>();



            CreateMap<TrainingSession, TrainingSessionResponseDto>()
          .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
          .ForMember(dest => dest.CoachName, opt => opt.MapFrom(src => src.Coach.Name))
          .ForMember(dest => dest.AgeGroupName, opt => opt.MapFrom(src => src.AgeGroup.GroupName));

        

            CreateMap<Tournment, TournamentResponseDto>();
            CreateMap<TournamentRequestDto, Tournment>();

           

            CreateMap<Match, MatchResponseDto>()
                .ForMember(dest => dest.Player1Name, opt => opt.MapFrom(src => src.Player1.FullName))
                .ForMember(dest => dest.Player2Name, opt => opt.MapFrom(src => src.Player2.FullName));

            CreateMap<MatchRequestDto, Match>();

            CreateMap<Invoice, InvoiceResponseDto>()
          .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName));  // Mapping User's Name to Response DTO

            CreateMap<InvoiceRequestDto, Invoice>();

            CreateMap<Court, CourtResponseDto>()
           .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings.Select(b => new BookingResponseDto
           {
               BookingId = b.BookingID,
               UserID = b.UserID,
               // Assuming the User entity has a Name property
               CourtID = b.CourtID,
               CourtName = b.Court.Name,  // Assuming the Court entity has a Name property
               Date = b.Date
           }).ToList()));

            CreateMap<CourtRequestDto, Court>();

            CreateMap<Coach, CoachResponseDto>()
          .ForMember(dest => dest.TrainingSessions, opt => opt.MapFrom(src => src.TrainingSessions.Select(ts => new TrainingSessionResponseDto
          {
              SessionID = ts.SessionID,
              Date = ts.Date,
              Location = ts.Location
          })));

            CreateMap<CoachRequestDto, Coach>();


        }
    }
}
