﻿using FluentValidation;
using JobTracking.Dtos.CategoryDtos;

namespace JobTracking.Services.ValidationRules.CategoryValidators;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        this.RuleFor(x => x.Definition)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
            .MaximumLength(200).WithMessage("Kategori adı ne fazla 200 karakter olmaldır");

        this.RuleFor(x => x.Description)
            .MinimumLength(3).WithMessage("Kategori açıklaması en az 3 karakter olmalıdır");
    }
}