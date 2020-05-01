namespace SchoolDiary.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Required]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
