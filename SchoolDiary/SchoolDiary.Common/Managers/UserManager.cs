namespace SchoolDiary.Common.Managers
{
    using System;
    using SchoolDiary.Common.Models;
    using SchoolDiary.Repositories.EntityFramework;

    public interface IUserManager
    {
        User Get(Guid id);
        User Authenticate(string username, string password);
    }

    public class UserManager : IUserManager
    {
        private readonly IRepository _repository;

        public UserManager(IRepository repository)
        {
            _repository = repository;
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
