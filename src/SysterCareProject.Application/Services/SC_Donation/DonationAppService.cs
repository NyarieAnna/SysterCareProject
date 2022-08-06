using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Donation
{
    public class DonationAppService : ApplicationService, IDonationAppService
    {
        private readonly IRepository<Donation, Guid> _donationRepository;

        public DonationAppService(IRepository<Donation, Guid> donationRepository)
        {
            _donationRepository = donationRepository;

        }
        public async Task<DonationDto> CreateAsync(DonationDto input)
        {
            var donation = ObjectMapper.Map<Donation>(input);

            await _donationRepository.InsertAsync(donation);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<DonationDto>(donation);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _donationRepository.DeleteAsync(id);
        }

        public async Task<PagedResultDto<DonationDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _donationRepository;
            var result = new PagedResultDto<DonationDto>();
            result.TotalCount = query.Count();
            result.Items = ObjectMapper.Map<IReadOnlyList<DonationDto>>(query);
            return await Task.FromResult(result);
        }


        public async Task<PagedResultDto<DonationDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            var query = _donationRepository;
            var result = new PagedResultDto<DonationDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<DonationDto>>(query);
            return await Task.FromResult(result);
        }

        public async Task<DonationDto> UpdateAsync(DonationDto input)
        {
            var bill = _donationRepository;
            var updt = await _donationRepository.UpdateAsync((Donation)ObjectMapper.Map(input, bill));
            return ObjectMapper.Map<DonationDto>(updt);
        }
    }
}