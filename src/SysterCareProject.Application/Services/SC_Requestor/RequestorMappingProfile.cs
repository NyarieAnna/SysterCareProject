using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Authorization.Users;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Requestor
{
    public class RequestorMappingProfile:Profile
    {
        public RequestorMappingProfile()
        {
            CreateMap<Requestor, RequestorDto>()
                .ForMember(c => c.UserId, m => m.MapFrom(e => e.User != null ? e.User.Id : (long?)null));

            CreateMap<RequestorDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<User, RequestorDto>()
                  .ForMember(c => c.UserId, m => m.MapFrom(e => e.Id != null ? e.Id : (long?)null));


            CreateMap<RequestorDto, Requestor>()
                .ForMember(e => e.Id, m => m.Ignore());
        }
    }
}
