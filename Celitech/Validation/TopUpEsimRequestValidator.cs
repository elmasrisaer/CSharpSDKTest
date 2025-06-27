namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class TopUpEsimRequestValidator : AbstractValidator<TopUpEsimRequest?>
{
    public TopUpEsimRequestValidator()
    {
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required.");
    }
}
