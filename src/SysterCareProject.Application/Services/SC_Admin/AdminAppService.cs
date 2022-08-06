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

namespace SysterCareProject.Services.SC_Admin
{
    public class AdminAppService:ApplicationService, IAdminAppService
    {
        private readonly IRepository<Admin, Guid> _adminRepository;
        private readonly UserManager _userManager;

        public AdminAppService(IRepository<Admin, Guid> adminRepository, UserManager userManager)
        {
            _adminRepository = adminRepository;
            _userManager = userManager;

        }
        public async Task<AdminDto> CreateAsync(AdminDto input)
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

            var admin = ObjectMapper.Map<Admin>(input);
            admin.User = user;


          

            await _adminRepository.InsertAsync(admin);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<AdminDto>(admin);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _adminRepository.DeleteAsync(id);
        }

        public async Task<PagedResultDto<AdminDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _adminRepository.GetAllIncluding(m => m.User);
            var result = new PagedResultDto<AdminDto>();
            result.TotalCount = query.Count();
            result.Items = ObjectMapper.Map<IReadOnlyList<AdminDto>>(query);
            return await Task.FromResult(result);
        }

        public async Task<AdminDto> GetAsync(PagedAndSortedResultRequestDto input, Guid id)
        {

            var course = await _adminRepository.GetAllIncluding(f => f.User)
                                 .FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
                throw new UserFriendlyException("Requestor not found!");
            return ObjectMapper.Map<AdminDto>(course);
        }

        public async Task<AdminDto> UpdateAsync(AdminDto input)
        {

            var course = _adminRepository.GetAllIncluding(e => e.User)
                                       .Where(y => y.Id == input.Id)
                                       .FirstOrDefault();
            var updated = await _adminRepository.UpdateAsync(ObjectMapper.Map(input, course));
            return ObjectMapper.Map<AdminDto>(updated);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
