namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class GrantTypeValidator : AbstractValidator<GrantType?>
{
    public GrantTypeValidator() { }
}
