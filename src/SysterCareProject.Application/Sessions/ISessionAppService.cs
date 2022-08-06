using System.Threading.Tasks;
using Abp.Application.Services;
using SysterCareProject.Sessions.Dto;

namespace SysterCareProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
