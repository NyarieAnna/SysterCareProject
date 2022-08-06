using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SysterCareProject.EntityFrameworkCore
{
    public static class SysterCareProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SysterCareProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SysterCareProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
