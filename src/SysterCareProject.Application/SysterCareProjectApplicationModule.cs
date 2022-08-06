using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SysterCareProject.Authorization;

namespace SysterCareProject
{
    [DependsOn(
        typeof(SysterCareProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SysterCareProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SysterCareProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SysterCareProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
