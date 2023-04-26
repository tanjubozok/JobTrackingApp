using FluentValidation;
using JobTracking.Dtos.AppUserDtos;

namespace JobTracking.Servives.ValidationRules.AppUserValidators;

public class AppUserRegisterDtoValidator : AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterDtoValidator()
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

        RuleFor(x => x.ComfirmPassword)
            .Equal(x => x.Password).WithMessage("{PropertyName} ile {ComparisonValue} uyuşmuyor");

        RuleFor(x => x.Name)
            .MinimumLength(3).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("{PropertyName} en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Surname)
            .MinimumLength(3).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("{PropertyName} en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("{PropertyName} doğru formatta değildir")
            .MaximumLength(100).WithMessage("{PropertyName} en fazla {MaxLength} karakter olmalıdır");
    }
}
