using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;

namespace SysterCareProject.Services.SC_Requestor
{
    public interface IRequestorAppService:IApplicationService
    {
        Task<RequestorDto> CreateAsync(RequestorDto input);
        Task<RequestorDto> UpdateAsync(RequestorDto input);
        Task<PagedResultDto<RequestorDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<RequestorDto> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
    }
}
