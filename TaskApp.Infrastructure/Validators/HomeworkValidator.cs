using FluentValidation;
using TaskApp.Core.Inputs;

namespace TaskApp.Infrastructure.Validators
{
    /// <summary>
    /// Class to validate properties of homework input
    /// </summary>
    public class HomeworkValidator : AbstractValidator<HomeworkInput>
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        public HomeworkValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("User ID is required");
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Homework title is required");
            RuleFor(x => x.Title).Length(4, 100).WithMessage("Homework title with minimum 4 characters and maximum 100 characters");
            RuleFor(x => x.Status).NotNull().NotNull().WithMessage("The homework status is required");
        }
    }
}
