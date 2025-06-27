namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class PackagesValidator : AbstractValidator<Packages?>
{
    public PackagesValidator() { }
}
