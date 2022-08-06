using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Domain;

namespace SysterCareProject.Services.SC_Request
{
    public class RequestAppService : ApplicationService, IRequestAppService
    {
        private readonly IRepository<Request, Guid> _requestRepository;
        private readonly IRepository<Requestor, Guid> _requestorRepository;
        public RequestAppService(IRepository<Request, Guid> requestRepository, IRepository<Requestor, Guid> requestorRepository)
        {
            _requestRepository = requestRepository;
            _requestorRepository = requestorRepository;

        }
        public async Task<RequestDto> CreateAsync(RequestDto input)
        {
            var request = ObjectMapper.Map<Request>(input);
            request.Requestor = await _requestorRepository.GetAsync((Guid)input.RequestorId);
            await _requestRepository.InsertAsync(request);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<RequestDto>(request);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _requestRepository.DeleteAsync(id);
        }

        public async Task<PagedResultDto<RequestDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _requestRepository.GetAllIncluding(e => e.Requestor);
            var result = new PagedResultDto<RequestDto>();
            result.TotalCount = query.Count();
            result.Items = ObjectMapper.Map<IReadOnlyList<RequestDto>>(query);
            return await Task.FromResult(result);
        }

        public async Task<PagedResultDto<RequestDto>> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            var query = _requestRepository.GetAllIncluding(f => f.Requestor).Where(x => x.Id == id);
            var result = new PagedResultDto<RequestDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<RequestDto>>(query);
            return await Task.FromResult(result);
        }

        public async Task<RequestDto> UpdateAsync(RequestDto input)
        {
            var bill = _requestRepository.GetAllIncluding(e => e.Requestor).Where(y => y.Id == input.Id).FirstOrDefault();
            var updt = await _requestRepository.UpdateAsync(ObjectMapper.Map(input, bill));
            return ObjectMapper.Map<RequestDto>(updt);
        }
    }
}
