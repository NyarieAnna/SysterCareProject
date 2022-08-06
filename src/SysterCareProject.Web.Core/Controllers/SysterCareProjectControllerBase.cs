using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SysterCareProject.Controllers
{
    public abstract class SysterCareProjectControllerBase: AbpController
    {
        protected SysterCareProjectControllerBase()
        {
            LocalizationSourceName = SysterCareProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
