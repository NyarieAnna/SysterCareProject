using System.Threading.Tasks;
using SysterCareProject.Configuration.Dto;

namespace SysterCareProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
