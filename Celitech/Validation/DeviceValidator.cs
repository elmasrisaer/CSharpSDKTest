namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

public class DeviceValidator : AbstractValidator<Device?>
{
    public DeviceValidator() { }
}
