using FluentValidation;
using TaskApp.Core.Inputs;

namespace TaskApp.Infrastructure.Validators
{
    /// <summary>
    /// Validators for update homework input
    /// </summary>
    public class UpdateHomeworkValidator : AbstractValidator<UpdateHomeworkInput>
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        public UpdateHomeworkValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("The homework ID is required");
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Homework title is required");
            RuleFor(x => x.Title).Length(4, 100).WithMessage("Homework title with minimum 4 characters and maximum 100 characters");
            RuleFor(x => x.Status).NotNull().NotNull().WithMessage("The homework status is required");
        }
    }
}
