using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Category;
using DigitalMenu.Application.Model.Product;
using Moq;
using NUnit.Framework.Constraints;

namespace DigitalMenu.Tests
{
    public class ProductValidatorTest
    {
        private ProductValidator _validator;
        private Mock<IServiceCategory> _mockCategory;

        [SetUp]
        public void Setup()
        {
            _mockCategory = new Mock<IServiceCategory>();
            _validator = new ProductValidator(_mockCategory.Object);
        }

        [Test]
        public void ProductTest()
        {
            var product = GetDefaultModel();
            _mockCategory.Setup(x => x.Exist(product.CategoryId)).ReturnsAsync(true);

            var result = _validator.TestValidate(product);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Description);
            result.ShouldNotHaveValidationErrorFor(x => x.CategoryId);
        }

        [Test]
        public void MandatoryNameTest()
        {
            var product =  GetDefaultModel();
            product.Name = string.Empty;

            var result = _validator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage("Nome do produto é obrigatório.");
        }

        [Test]
        public void MaxLengthNameTest()
        {
            var product = GetDefaultModel();
            product.Name = TestUtil.GenerateRandomText(51);

            var result = _validator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage("Nome do produto não pode ultrapassar 50 caracteres.");
        }

        [Test]
        public void MandatoryDescriptionTest()
        {
            var product = GetDefaultModel();
            product.Description = string.Empty;

            var result = _validator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(x => x.Description).WithErrorMessage("Descrição do produto é obrigatório.");
        }

        [Test]
        public void MandatoryCategoryTest()
        {
            var product = GetDefaultModel();
            product.CategoryId = Guid.Empty;

            var result = _validator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(x => x.CategoryId).WithErrorMessage("Categoria do produto é obrigatório.");
        }

        [Test]
        public void InvalidCategoryTest()
        {
            var product = GetDefaultModel();
            _mockCategory.Setup(x => x.Exist(product.CategoryId)).ReturnsAsync(true);

            product.CategoryId = Guid.NewGuid();

            var result = _validator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(x => x.CategoryId).WithErrorMessage("Categoria do produto é inválida.");
        }

        #region PRIVATE METHODS

        private ProductModel GetDefaultModel()
        {
            return new ProductModel
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Description = "Product description",
                CategoryId = Guid.NewGuid()
            };
        }

        #endregion
    }
}