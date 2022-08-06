using Abp.Authorization;
using SysterCareProject.Authorization.Roles;
using SysterCareProject.Authorization.Users;

namespace SysterCareProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
