using Abp.Application.Services;
using SysterCareProject.MultiTenancy.Dto;

namespace SysterCareProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

