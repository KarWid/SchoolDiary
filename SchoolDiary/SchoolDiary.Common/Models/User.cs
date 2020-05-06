namespace SchoolDiary.Common.Models
{
    using System;
    using FluentValidation;
    using SchoolDiary.Common.Resources;

    public class User
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName)
                .NotNull().WithMessage(GeneralResource.Required)
                .MaximumLength(256).WithMessage(GeneralResource.MaximumLength_Error);
            RuleFor(u => u.Email)
                .EmailAddress().WithMessage(GeneralResource.User_Email_Error)
                .MaximumLength(256).WithMessage(GeneralResource.MaximumLength_Error);
            RuleFor(u => u.Password)
                .NotNull()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage(GeneralResource.User_Password_InvalidFormat);
            RuleFor(u => u.ConfirmPassword)
                .Equal(user => user.Password)
                .WithMessage(GeneralResource.User_ConfirmPassword_NotMatch);
        }
    }
}
