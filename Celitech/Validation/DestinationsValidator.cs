namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class DestinationsValidator : AbstractValidator<Destinations?>
{
    public DestinationsValidator() { }
}
