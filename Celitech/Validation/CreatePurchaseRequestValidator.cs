namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseRequestValidator : AbstractValidator<CreatePurchaseRequest?>
{
    public CreatePurchaseRequestValidator()
    {
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.Destination)
            .NotNull()
            .WithMessage("Field destination is required.");
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required.");
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.StartDate)
            .NotNull()
            .WithMessage("Field startDate is required.");
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.EndDate)
            .NotNull()
            .WithMessage("Field endDate is required.");
    }
}
