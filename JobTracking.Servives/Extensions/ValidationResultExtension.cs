using FluentValidation.Results;
using JobTracking.Common.ResponseObjects;

namespace JobTracking.Services.Extensions;

public static class ValidationResultExtension
{
    public static List<CustomValidationError> CustomValidationErrors(this ValidationResult result)
    {
        List<CustomValidationError> customValidationErrors = new();
        foreach (var error in result.Errors)
        {
            customValidationErrors.Add(new CustomValidationError
            {
                ErrorMessage = error.ErrorMessage,
                PropertyName = error.PropertyName
            });
        }
        return customValidationErrors;
    }
}