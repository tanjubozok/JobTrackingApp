using FluentValidation;
using JobTracking.Dtos.WorkingDtos;

namespace JobTracking.Servives.ValidationRules.WorkingValidators;

public class WorkingCreateDtoValidator : AbstractValidator<WorkingCreateDto>
{
    public WorkingCreateDtoValidator()
    {
        RuleFor(x => x.Definition)
           .NotEmpty().WithMessage("Tanım alanı zorunludur")
           .MinimumLength(3).WithMessage("Tanım alanı en az 3 karakter olmaldır")
           .MaximumLength(500).WithMessage("Tanım alanı en fazla 500 karakter olmaldır");

        RuleFor(x => x.Description)
            .MinimumLength(3).WithMessage("Açıklama en az 3 karakter olmalıdır");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Kategori zorunlu alandır")
            .ExclusiveBetween(0, int.MaxValue).WithMessage("Kategori seçiniz");
    }
}