using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysterCareProject.Authorization.Users;
using SysterCareProject.Domain;
using SysterCareProject.Services.Helpers;

namespace SysterCareProject.Services.SC_Requestor
{
    public class RequestorAppService : ApplicationService, IRequestorAppService
    {
        private readonly IRepository<Requestor, Guid> _requestorRepository;
        private readonly UserManager _userManager;
       
        public RequestorAppService(IRepository<Requestor, Guid> requestorRepository, UserManager userManager)
        {
            _requestorRepository = requestorRepository;
            _userManager = userManager;
          
        }
        public async Task<RequestorDto> CreateAsync(RequestorDto input)
        {
            var user = new User();
            user.Id = (long)input.UserId;
            user.TenantId = AbpSession.TenantId;
            user.EmailAddress = input.EmailAddress;
            user.PhoneNumber = input.PhoneNumber;
            user.IsEmailConfirmed = true;
            user.Name = input.Name;
            user.Surname = input.Surname;
            user.UserName ??= input.UserName;
            user.SetNormalizedNames();
            user.Password = input.Password;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            var requestor = ObjectMapper.Map<Requestor>(input);
            requestor.User = user;


            requestor.RequestorNumber = Util.GenerateRequestorNum();
          
            await _requestorRepository.InsertAsync(requestor);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<RequestorDto>(requestor);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _requestorRepository.DeleteAsync(id);
        }

        public async Task<PagedResultDto<RequestorDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _requestorRepository.GetAllIncluding(m => m.User);
            var result = new PagedResultDto<RequestorDto>();
            result.TotalCount = query.Count();
            result.Items = ObjectMapper.Map<IReadOnlyList<RequestorDto>>(query);
            return await Task.FromResult(result);
        }

        public async Task<RequestorDto> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {
            var course = await _requestorRepository.GetAllIncluding(f => f.User)
                                 .FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
                throw new UserFriendlyException("Requestor not found!");
            return ObjectMapper.Map<RequestorDto>(course);
        }

        public async Task<RequestorDto> UpdateAsync(RequestorDto input)
        {
            var course = _requestorRepository.GetAllIncluding(e => e.User)
                                       .Where(y => y.Id == input.Id)
                                       .FirstOrDefault();
            var updated = await _requestorRepository.UpdateAsync(ObjectMapper.Map(input, course));
            return ObjectMapper.Map<RequestorDto>(updated);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

    
       
    }
}
