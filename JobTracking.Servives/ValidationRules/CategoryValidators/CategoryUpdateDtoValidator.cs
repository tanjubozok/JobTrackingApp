using FluentValidation;
using JobTracking.Dtos.CategoryDtos;

namespace JobTracking.Servives.ValidationRules.CategoryValidators;

public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidator()
    {
        this.RuleFor(x => x.Id)
            .NotEmpty();

        this.RuleFor(x => x.Definition)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
            .MaximumLength(200).WithMessage("Kategori adı ne fazla 200 karakter olmaldır");

        this.RuleFor(x => x.Description)
            .MinimumLength(3).WithMessage("Kategori açıklaması en az 3 karakter olmalıdır");
    }
}
