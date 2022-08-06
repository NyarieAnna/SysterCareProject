using AutoMapper;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Status
{
    public class StatusMappingProfile:Profile
    {
        public StatusMappingProfile()
        {
            CreateMap<Status, StatusDto>()
                    .ForMember(e => e.RequestId, m => m.MapFrom(e => e.Request.Id));

            CreateMap<StatusDto, Status>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
