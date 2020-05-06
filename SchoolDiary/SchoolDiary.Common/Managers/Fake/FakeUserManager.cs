namespace SchoolDiary.Common.Managers.Fake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolDiary.Common.Models;
    using SchoolDiary.Repositories.EntityFramework.Entities;

    public class FakeUserManager : IUserManager
    {
        private List<AppUserEntity> _users = new List<AppUserEntity>
        {
            new AppUserEntity { Id = Guid.Empty, UserName = "test", PasswordHash = "test" }
        };


        public User Authenticate(string username, string password)
        {
            var user = _users.FirstOrDefault(x => x.UserName == username && x.PasswordHash == password);

            var result = new User
            {
                Id = user.Id,
            };

            return result;
        }

        public User Get(Guid id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null) throw new ArgumentException("User not found.");

            return new User
            {
                Token = null,
                Id = user.Id
            };
        }
    }
}
