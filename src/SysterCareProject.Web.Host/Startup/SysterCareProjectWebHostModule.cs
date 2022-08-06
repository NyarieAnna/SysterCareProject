using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SysterCareProject.Configuration;

namespace SysterCareProject.Web.Host.Startup
{
    [DependsOn(
       typeof(SysterCareProjectWebCoreModule))]
    public class SysterCareProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SysterCareProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SysterCareProjectWebHostModule).GetAssembly());
        }
    }
}
