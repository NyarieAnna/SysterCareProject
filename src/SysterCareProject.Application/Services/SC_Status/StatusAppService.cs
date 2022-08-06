using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Status
{
    public class StatusAppService:ApplicationService, IStatusAppService
    {
        private readonly IRepository<Request, Guid> _requestRepository;
        private readonly IRepository<Status, Guid> _statusRepository;
        public StatusAppService(IRepository<Request, Guid> requestRepository, IRepository<Status, Guid> statusRepository)
        {
            _requestRepository = requestRepository;
            _statusRepository = statusRepository;

        }

        public async Task<StatusDto> CreateAsync(StatusDto input)
        {
            var request = ObjectMapper.Map<Status>(input);
            request.Request = await _requestRepository.GetAsync((Guid)input.RequestId);
            await _statusRepository.InsertAsync(request);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<StatusDto>(request);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _statusRepository.DeleteAsync(id);
        }

        public async Task<PagedResultDto<StatusDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _statusRepository.GetAllIncluding(e => e.Request);
            var result = new PagedResultDto<StatusDto>();
            result.TotalCount = query.Count();
            result.Items = ObjectMapper.Map<IReadOnlyList<StatusDto>>(query);
            return await Task.FromResult(result);
        }

        public async Task<PagedResultDto<StatusDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            var query = _statusRepository.GetAllIncluding(f => f.Request).Where(x => x.Id == id);
            var result = new PagedResultDto<StatusDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<StatusDto>>(query);
            return await Task.FromResult(result);
        }

        public async Task<StatusDto> UpdateAsync(StatusDto input)
        {
            var bill = _statusRepository.GetAllIncluding(e => e.Request).Where(y => y.Id == input.Id).FirstOrDefault();
            var updt = await _statusRepository.UpdateAsync(ObjectMapper.Map(input, bill));
            return ObjectMapper.Map<StatusDto>(updt);
        }
    }
}
