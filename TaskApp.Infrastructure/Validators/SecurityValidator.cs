using FluentValidation;
using TaskApp.Core.DTOs;

namespace TaskApp.Infrastructure.Validators
{
    /// <summary>
    /// Class to validate properties
    /// </summary>
    public class SecurityValidator : AbstractValidator<SecurityDto>
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        public SecurityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("The name is required");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("The surname is required");
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("The username is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("The password is required");
        }
    }
}
