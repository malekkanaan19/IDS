using AutoMapper;
using meeting.core.Models;
using meeting.services.Resources;
using Microsoft.ApplicationInsights.AspNetCore;
using ServiceStack.Auth;
using Web_API.Resources;

namespace Web_API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //models to resource
            CreateMap<meeting.core.Models.Room, RoomResources>();
            CreateMap<meeting.core.Models.User, UserResources>();
            CreateMap<meeting.core.Models.Company,CompanyResources>();
            CreateMap<Reservation, ReservationResources>();

            //resource to models
            CreateMap<RoomResources, meeting.core.Models.Room>();
            CreateMap<RoomResources, Room>();
            CreateMap<UserResources, meeting.core.Models.User>();
            CreateMap<SaveUserResources, meeting.core.Models.User>();
            CreateMap<CompanyResources, meeting.core.Models.Company>();
            CreateMap<SaveCompanyResources, meeting.core.Models.Company>();
            CreateMap<ReservationResources, meeting.core.Models.Reservation>();
            CreateMap<SaveReservationResources, meeting.core.Models.Reservation>();

            CreateMap<UserSignUpResources, UserAuth>().ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
