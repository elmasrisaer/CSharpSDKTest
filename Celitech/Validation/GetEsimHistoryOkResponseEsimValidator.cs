namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimHistoryOkResponseEsimValidator
    : AbstractValidator<GetEsimHistoryOkResponseEsim?>
{
    public GetEsimHistoryOkResponseEsimValidator()
    {
        RuleFor(GetEsimHistoryOkResponseEsim => GetEsimHistoryOkResponseEsim.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.");
    }
}
