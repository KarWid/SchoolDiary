namespace SchoolDiary.Common.Managers
{
    using System;
    using SchoolDiary.Common.Models;
    using SchoolDiary.Repositories.EntityFramework;
    using SchoolDiary.Repositories.EntityFramework.Entities;

    public interface IUserManager
    {
        User Get(Guid id);
        User Authenticate(string username, string password);
    }

    public class UserManager : IUserManager
    {
        private readonly IRepository<AppUserEntity> _appUserRepository;

        public UserManager(IRepository<AppUserEntity> appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
