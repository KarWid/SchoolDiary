namespace SchoolDiary.Repositories.EntityFramework
{
    using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SchoolDiary.Repositories.EntityFramework.Entities;

    public class SchoolDiaryDbContext : IdentityDbContext<AppUserEntity, AppRoleEntity, Guid>
    {
        public SchoolDiaryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
