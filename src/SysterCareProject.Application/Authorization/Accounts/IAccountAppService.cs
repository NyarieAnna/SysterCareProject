using System.Threading.Tasks;
using Abp.Application.Services;
using SysterCareProject.Authorization.Accounts.Dto;

namespace SysterCareProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
