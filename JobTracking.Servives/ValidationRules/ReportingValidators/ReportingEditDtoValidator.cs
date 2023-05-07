using FluentValidation;
using JobTracking.Dtos.ReportingDtos;

namespace JobTracking.Services.ValidationRules.ReportingValidators;

public class ReportingEditDtoValidator : AbstractValidator<ReportingEditDto>
{
    public ReportingEditDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("id boş olamaz");

        RuleFor(x => x.Definition)
            .NotEmpty().WithMessage("Rapor başlığı boş olamaz")
            .MinimumLength(3).WithMessage("Rapor başlığı en az 3 karakter olmalıdır")
            .MaximumLength(200).WithMessage("Rapor başlığı en fazla 200 karakter olmalıdır");

        RuleFor(x => x.Detail)
            .NotEmpty().WithMessage("Rapor açıklama boş olamaz")
            .MinimumLength(3).WithMessage("Rapor açıklama en az 3 karakter olmalıdır")
            .MaximumLength(2000).WithMessage("Rapor açıklama en fazla 2000 karakter olmalıdır");
    }
}
