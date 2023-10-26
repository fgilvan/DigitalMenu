using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Category;
using DigitalMenu.Core.Extensions;
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
        private IServiceProduct _serviceProduct;

        public ProductValidator(IServiceCategory serviceCategory, IServiceProduct serviceProduct) 
        {
            _serviceCategory = serviceCategory;
            _serviceProduct = serviceProduct;

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

            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(InDataBase)
                .When(x => x.Id != Guid.Empty)
                .WithMessage("Categoria não encontrada.")
                .Must(AlreadyUsedName)
                .When(x =>  x.Name.HasValue())
                .OverridePropertyName(x => x.Name)
                .WithMessage("Nome já utilizado por outro produto.");
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
        
        private bool InDataBase(ProductModel model)
        {
            return _serviceProduct.Exist(model.Id).Result;
        }

        private bool AlreadyUsedName(ProductModel model)
        {
            var databaseModel = _serviceProduct.GetByName(model.Name).Result;

            return databaseModel == null || databaseModel.Id == model.Id;
        }

        private bool VerifyCategory(Guid idCategory)
        {
            var retorno = _serviceCategory.Exist(idCategory);

            return retorno.Result;
        }

        #endregion
    }
}
