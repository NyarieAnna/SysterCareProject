using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;

namespace SysterCareProject.Services.SC_Status
{
    public interface IStatusAppService:IApplicationService
    {
        Task<StatusDto> CreateAsync(StatusDto input);
        Task<StatusDto> UpdateAsync(StatusDto input);
        Task<PagedResultDto<StatusDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<StatusDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
    }
}