using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SysterCareProject.Configuration.Dto;

namespace SysterCareProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SysterCareProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
