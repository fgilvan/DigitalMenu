using DigitalMenu.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Model.Product
{
    public class ProductValidator: AbstractValidator<ProductModel>
    {
        private IServiceCategory _serviceCategory;

        public ProductValidator(IServiceCategory serviceCategory) 
        {
            _serviceCategory = serviceCategory;

            ValidatorName();
            ValidatorDescription();
            ValidatorCategory();
        }

        #region PRIVATE METHODS

        private void ValidatorDescription()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Descrição do produto é obrigatório.");
        }

        private void ValidatorName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome do produto é obrigatório.");

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage("Nome do produto não pode ultrapassar 50 caracteres.");
        }

        private void ValidatorCategory()
        {
            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Categoria do produto é obrigatório.");

            RuleFor(x => x.CategoryId)
                .Must(VerifyCategory)
                .When(x => x.CategoryId != Guid.Empty)
                .WithMessage("Categoria do produto é inválida.");
        }


        private bool VerifyCategory(Guid idCategory)
        {
            var retorno = _serviceCategory.Exist(idCategory);

            return retorno.Result;
        }

        #endregion
    }
}
