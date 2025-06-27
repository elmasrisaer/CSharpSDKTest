namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class PackageValidator : AbstractValidator<Package?>
{
    public PackageValidator() { }
}
