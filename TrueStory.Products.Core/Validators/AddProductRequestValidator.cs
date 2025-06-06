using FluentValidation;
using TrueStory.Products.Core.Contracts.Product;

namespace TrueStory.Products.Core.Validators
{
    /// <summary>
    /// Add product request validator.
    /// </summary>
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.Product)
                .NotNull().WithMessage("Product is required.")
                .SetValidator(new ProductValidator());

            RuleFor(x => x.Product.Data)
                .Must(data => data == null || data.Count > 0).WithMessage("Product data must not be empty.");
        }
    }
}
