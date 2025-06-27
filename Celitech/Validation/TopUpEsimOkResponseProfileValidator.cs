namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class TopUpEsimOkResponseProfileValidator : AbstractValidator<TopUpEsimOkResponseProfile?>
{
    public TopUpEsimOkResponseProfileValidator()
    {
        RuleFor(TopUpEsimOkResponseProfile => TopUpEsimOkResponseProfile.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.");
    }
}
