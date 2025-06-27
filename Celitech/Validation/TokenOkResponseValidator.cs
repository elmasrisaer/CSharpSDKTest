namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class TokenOkResponseValidator : AbstractValidator<TokenOkResponse?>
{
    public TokenOkResponseValidator() { }
}
