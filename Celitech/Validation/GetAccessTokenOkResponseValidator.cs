namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetAccessTokenOkResponseValidator : AbstractValidator<GetAccessTokenOkResponse?>
{
    public GetAccessTokenOkResponseValidator() { }
}
