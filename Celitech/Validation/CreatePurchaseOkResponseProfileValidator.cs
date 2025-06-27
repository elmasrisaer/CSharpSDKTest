namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseOkResponseProfileValidator
    : AbstractValidator<CreatePurchaseOkResponseProfile?>
{
    public CreatePurchaseOkResponseProfileValidator()
    {
        RuleFor(CreatePurchaseOkResponseProfile => CreatePurchaseOkResponseProfile.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.");
        RuleFor(CreatePurchaseOkResponseProfile => CreatePurchaseOkResponseProfile.ActivationCode)
            .MinimumLength(1000)
            .WithMessage("Minimum length for activationCode is 1000.")
            .MaximumLength(8000)
            .WithMessage("Minimum length for activationCode is 1000.");
    }
}
