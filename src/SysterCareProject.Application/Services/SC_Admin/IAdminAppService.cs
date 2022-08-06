using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;

namespace SysterCareProject.Services.SC_Admin
{
    public interface IAdminAppService:IApplicationService
    {
        Task<AdminDto> CreateAsync(AdminDto input);
        Task<AdminDto> UpdateAsync(AdminDto input);
        Task<PagedResultDto<AdminDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<AdminDto> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
    }
}