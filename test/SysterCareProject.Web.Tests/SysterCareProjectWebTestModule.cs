using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SysterCareProject.EntityFrameworkCore;
using SysterCareProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SysterCareProject.Web.Tests
{
    [DependsOn(
        typeof(SysterCareProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SysterCareProjectWebTestModule : AbpModule
    {
        public SysterCareProjectWebTestModule(SysterCareProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SysterCareProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SysterCareProjectWebMvcModule).Assembly);
        }
    }
}