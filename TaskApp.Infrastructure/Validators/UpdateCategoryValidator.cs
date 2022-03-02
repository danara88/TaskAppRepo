using FluentValidation;
using TaskApp.Core.Inputs;

namespace TaskApp.Infrastructure.Validators
{
    /// <summary>
    /// Method to validate update category input properties
    /// </summary>
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryInput>
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("The category ID is required");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("The category name is required");
            RuleFor(x => x.Name).Length(4, 100).WithMessage("Category name with minimum 4 characters and maximum 100 characters");
        }
    }
}
