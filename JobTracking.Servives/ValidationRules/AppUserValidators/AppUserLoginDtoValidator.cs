using FluentValidation;
using JobTracking.Dtos.AppUserDtos;

namespace JobTracking.Servives.ValidationRules.AppUserValidators;

public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
{
    public AppUserLoginDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("{PropertyName} zorunludur")
            .MinimumLength(3).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("{PropertyName} en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} zorunludur")
            .MinimumLength(8).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır");
            //.Matches("[A-Z]").WithMessage("{PropertyName} en az 1 büyük harf içermelidir")
            //.Matches("[a-z]").WithMessage("{PropertyName} en az 1 küçük harf içermelidir")
            //.Matches("[0-9]").WithMessage("{PropertyName} en az 1 rakam içermelidir");
    }
}
