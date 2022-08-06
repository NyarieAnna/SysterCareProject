using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SysterCareProject.Roles.Dto;
using SysterCareProject.Users.Dto;

namespace SysterCareProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
