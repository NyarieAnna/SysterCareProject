using AutoMapper;
using SysterCareProject.Authorization.Users;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Admin
{
    public class AdminMappingProfile:Profile
    {
        public AdminMappingProfile()
        {
            CreateMap<Admin, AdminDto>()
               .ForMember(c => c.UserId, m => m.MapFrom(e => e.User != null ? e.User.Id : (long?)null));

            CreateMap<AdminDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<User, AdminDto>()
                  .ForMember(c => c.UserId, m => m.MapFrom(e => e.Id != null ? e.Id : (long?)null));


            CreateMap<AdminDto, Admin>()
                .ForMember(e => e.Id, m => m.Ignore());
        }
    }
}
