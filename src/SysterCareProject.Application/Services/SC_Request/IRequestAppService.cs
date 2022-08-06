using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysterCareProject.Services.SC_Request
{
    public interface IRequestAppService:IApplicationService
    {
        Task<RequestDto> CreateAsync(RequestDto input);
        Task<RequestDto> UpdateAsync(RequestDto input);
        Task<PagedResultDto<RequestDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<RequestDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
    }
}
