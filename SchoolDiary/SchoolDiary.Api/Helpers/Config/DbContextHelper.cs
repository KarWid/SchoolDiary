namespace SchoolDiary.Api.Helpers.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SchoolDiary.Repositories.EntityFramework;
    using SchoolDiary.Repositories.EntityFramework.Entities;

    public static class DbContextHelper
    {
        public static void AddDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<SchoolDiaryDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("SchoolDiary")));
            services.AddIdentity<AppUserEntity, AppRoleEntity>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SchoolDiaryDbContext>();
        }
    }
}
