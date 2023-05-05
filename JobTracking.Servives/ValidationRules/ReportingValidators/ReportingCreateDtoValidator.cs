using FluentValidation;
using JobTracking.Dtos.ReportingDtos;

namespace JobTracking.Services.ValidationRules.ReportingValidators;

public class ReportingCreateDtoValidator : AbstractValidator<ReportingCreateDto>
{
    public ReportingCreateDtoValidator()
    {
        RuleFor(x => x.Definition)
            .NotEmpty().WithMessage("Rapor başlığı boş olamaz")
            .MinimumLength(3).WithMessage("Rapor başlığı en az 3 karakter olmalıdır")
            .MaximumLength(200).WithMessage("Rapor başlığı en fazla 200 karakter olmalıdır");

        RuleFor(x => x.Detail)
            .NotEmpty().WithMessage("Rapor açıklama boş olamaz")
            .MinimumLength(3).WithMessage("Rapor açıklama en az 3 karakter olmalıdır")
            .MaximumLength(2000).WithMessage("Rapor açıklama en fazla 2000 karakter olmalıdır");

        RuleFor(x => x.WorkingId)
            .NotEmpty().WithMessage("Görev alanı belli değil")
            .ExclusiveBetween(0, int.MaxValue).WithMessage("Görev seçiniz");
    }
}
