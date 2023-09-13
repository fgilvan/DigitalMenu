using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Model.Product
{
    public class ProductValidator: AbstractValidator<ProductModel>
    {
        public ProductValidator() 
        {
            ValidatorName();
            ValidatorDescription();
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
                .WithMessage("Nome do produto não pode ultrapassar 50 caracteres");
        }

        #endregion
    }
}
