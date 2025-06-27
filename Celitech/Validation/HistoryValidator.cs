namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class HistoryValidator : AbstractValidator<History?>
{
    public HistoryValidator() { }
}
