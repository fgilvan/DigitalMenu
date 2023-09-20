using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Services;
using DigitalMenu.Core.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Model.Category
{
    public class CategoryValidator: AbstractValidator<CategoryModel>
    {
        private IServiceCategory _serviceCategory;

        public CategoryValidator(IServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;

            ValidatorName();
        }

        #region PRIVATE METHODS

        private void ValidatorName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome da categoria é obrigatório.");

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage("Nome da categoria não pode ultrapassar 50 caracteres.");

            RuleFor(x => x.Name)
                .Must(x => _serviceCategory.GetByName(x).Result == null)
                .When(x => x.Name.HasValue())
                .WithMessage("Nome já utilizado por outra categoria.");
        }

        #endregion
    }
}
