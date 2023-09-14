using DigitalMenu.Application.Model.Product;

namespace DigitalMenu.Tests
{
    public class ProductValidatorTest
    {
        private ProductValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new ProductValidator();
        }

        [Test]
        public void ProductTest()
        {
            var product = GetDefaultModel();

            var result = _validator.TestValidate(product);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Description);
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

        #region PRIVATE METHODS

        private ProductModel GetDefaultModel()
        {
            return new ProductModel
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Description = "Product description",
            };
        }

        #endregion
    }
}