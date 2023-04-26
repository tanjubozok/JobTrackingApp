using FluentValidation;
using JobTracking.Dtos.AppUserDtos;

namespace JobTracking.Servives.ValidationRules.AppUserValidators;

public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
{
    public AppUserLoginDtoValidator()
    {
        RuleFor(x => x.Username)
           .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
           .MinimumLength(3).WithMessage("Kullanıcı adı en az {MinLength} karakter olmalıdır")
           .MaximumLength(50).WithMessage("Kullanıcı adı en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz")
            .MinimumLength(4).WithMessage("Şifre en az {MinLength} karakter olmalıdır");
    }
}
