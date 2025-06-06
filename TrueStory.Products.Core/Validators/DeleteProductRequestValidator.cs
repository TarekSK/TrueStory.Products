using FluentValidation;
using TrueStory.Products.Core.Contracts.Product;

namespace TrueStory.Products.Core.Validators
{
    /// <summary>
    /// Delete product request validator.
    /// </summary>
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty().WithMessage("Product ID is required.");
        }
    }
}
