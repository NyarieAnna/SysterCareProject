using System.Threading.Tasks;
using SysterCareProject.Models.TokenAuth;
using SysterCareProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace SysterCareProject.Web.Tests.Controllers
{
    public class HomeController_Tests: SysterCareProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}