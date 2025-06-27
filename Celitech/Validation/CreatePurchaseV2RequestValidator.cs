namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseV2RequestValidator : AbstractValidator<CreatePurchaseV2Request?>
{
    public CreatePurchaseV2RequestValidator()
    {
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Destination)
            .NotNull()
            .WithMessage("Field destination is required.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Quantity)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Minimum for quantity is 1.")
            .LessThanOrEqualTo(5)
            .WithMessage("Minimum for quantity is 5.")
            .NotNull()
            .WithMessage("Field quantity is required.");
    }
}
