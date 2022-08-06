using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;
using SysterCareProject.Services.SC_Donation;

namespace SysterCareProject.Services
{
    public interface IDonationAppService: IApplicationService
    {
        Task<DonationDto> CreateAsync(DonationDto input);
        Task<DonationDto> UpdateAsync(DonationDto input);
        Task<PagedResultDto<DonationDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PagedResultDto<DonationDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id);
        Task DeleteAsync(Guid id);
    }
}