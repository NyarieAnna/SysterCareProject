using AutoMapper;
using System;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Request
{
    public class RequestMappingProfile:Profile
    {
        public RequestMappingProfile()
        {
            CreateMap<Request,RequestDto>()
                .ForMember(e => e.RequestorId, m => m.MapFrom(e => e.Requestor != null ? e.Requestor.Id : (Guid?)null));

            CreateMap<RequestDto, Request>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
