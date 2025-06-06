using FluentValidation;
using TrueStory.Products.Core.Contracts.Product;

namespace TrueStory.Products.Core.Validators
{
    /// <summary>
    /// Product validator
    /// Used in add product validator to validate product model
    /// </summary>
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.");
        }
    }
}
