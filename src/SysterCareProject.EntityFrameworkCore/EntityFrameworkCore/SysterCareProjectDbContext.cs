using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SysterCareProject.Authorization.Roles;
using SysterCareProject.Authorization.Users;
using SysterCareProject.MultiTenancy;
using SysterCareProject.Domain;

namespace SysterCareProject.EntityFrameworkCore
{
    public class SysterCareProjectDbContext : AbpZeroDbContext<Tenant, Role, User, SysterCareProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Requestor> Requestors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Donation> Donations { get; set; }
     

        public SysterCareProjectDbContext(DbContextOptions<SysterCareProjectDbContext> options)
            : base(options)
        {
        }
    }
}
