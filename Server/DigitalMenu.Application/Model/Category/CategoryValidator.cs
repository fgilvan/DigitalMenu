using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Product;
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

            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(InDataBase)
                .When(x => x.Id != Guid.Empty)
                .WithMessage("Categoria não encontrada.")
                .Must(AlreadyUsedName)
                .When(x => x.Name.HasValue())
                .WithMessage("Nome já utilizado por outra categoria.")
                .OverridePropertyName(x => x.Name);
        }

        private bool InDataBase(CategoryModel model)
        {
            return _serviceCategory.Exist(model.Id).Result;
        }

        private bool AlreadyUsedName(CategoryModel model)
        {
            var databaseModel = _serviceCategory.GetByName(model.Name).Result;

            return databaseModel == null || databaseModel.Id == model.Id;
        }

        #endregion
    }
}
