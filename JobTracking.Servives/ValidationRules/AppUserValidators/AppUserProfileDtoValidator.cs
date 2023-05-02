using FluentValidation;
using JobTracking.Dtos.AppUserDtos;

namespace JobTracking.Servives.ValidationRules.AppUserValidators;

public class AppUserProfileDtoValidator : AbstractValidator<AppUserProfileDto>
{
    public AppUserProfileDtoValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3).WithMessage("Ad en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("Ad en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Surname)
            .MinimumLength(3).WithMessage("Soyad en az {MinLength} karakter olmalıdır")
            .MaximumLength(50).WithMessage("Soyad en fazla {MaxLength} karakter olmalıdır");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-Posta boş olamaz")
            .EmailAddress().WithMessage("E-Posta doğru formatta değildir")
            .MaximumLength(100).WithMessage("E-Posta en fazla {MaxLength} karakter olmalıdır");
    }
}
