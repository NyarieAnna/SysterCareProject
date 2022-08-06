using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SysterCareProject.Authorization.Roles;
using SysterCareProject.Authorization.Users;
using SysterCareProject.MultiTenancy;

namespace SysterCareProject.EntityFrameworkCore
{
    public class SysterCareProjectDbContext : AbpZeroDbContext<Tenant, Role, User, SysterCareProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SysterCareProjectDbContext(DbContextOptions<SysterCareProjectDbContext> options)
            : base(options)
        {
        }
    }
}
