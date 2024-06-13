using FluentValidation;
using KolosAPBD2a.RequestModels;

namespace KolosAPBD2a.Validators;

public class AddProductsToBackPackValidator : AbstractValidator<CreateBackPackRequestModel>
{
    public AddProductsToBackPackValidator()
    {
        RuleFor(e => e.ProductsId).NotEmpty().WithMessage("You must input products list");
    }
}