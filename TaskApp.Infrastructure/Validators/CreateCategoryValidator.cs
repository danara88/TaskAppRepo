using FluentValidation;
using TaskApp.Core.Inputs;

namespace TaskApp.Infrastructure.Validators
{
    /// <summary>
    /// Class to validate category input properties
    /// </summary>
    public class CreateCategoryValidator : AbstractValidator<CategoryInput>
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("The category name is required");
            RuleFor(x => x.Name).Length(4,100).WithMessage("Category name with minimum 4 characters and maximum 100 characters");
        }
    }
}
