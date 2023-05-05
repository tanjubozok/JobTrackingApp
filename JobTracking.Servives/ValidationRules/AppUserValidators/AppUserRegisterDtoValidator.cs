using FluentValidation;
using JobTracking.Dtos.AppUserDtos;

namespace JobTracking.Services.ValidationRules.AppUserValidators;

public class AppUserRegisterDtoValidator : AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
            .MinimumLength(3).WithMessage("Kullanıcı adı en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("Kullanıcı adı en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz")
            .MinimumLength(4).WithMessage("Şifre en az {MinLength} karakter olmalıdır");

        RuleFor(x => x.ComfirmPassword)
            .NotEmpty().WithMessage("Şifre tekrar boş olamaz")
            .Equal(x => x.Password).WithMessage("{PropertyName} ile {ComparisonValue} uyuşmuyor");

        RuleFor(x => x.Name)
            .MinimumLength(3).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("{PropertyName} en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Surname)
            .MinimumLength(3).WithMessage("{PropertyName} en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("{PropertyName} en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-Posta boş olamaz")
            .EmailAddress().WithMessage("{PropertyName} doğru formatta değildir")
            .MaximumLength(100).WithMessage("{PropertyName} en fazla {MaxLength} karakter olmalıdır");
    }
}
