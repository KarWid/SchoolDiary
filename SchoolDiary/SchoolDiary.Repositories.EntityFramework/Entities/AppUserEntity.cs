namespace SchoolDiary.Repositories.EntityFramework.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class AppUserEntity : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }
    }
}
