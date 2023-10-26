using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Category;
using Moq;
using NUnit.Framework.Constraints;

namespace DigitalMenu.Tests
{
    public class CategoryValidatorTest
    {
        private CategoryValidator _validator;
        private Mock<IServiceCategory> _mockCategory;

        [SetUp]
        public void Setup()
        {
            _mockCategory = new Mock<IServiceCategory>();

            _validator = new CategoryValidator(_mockCategory.Object);
        }

        [Test]
        public void CategoryTest()
        {
            CategoryModel dataBaseCategory = null;
            var category = GetDefaultModel();

            _mockCategory.Setup(x => x.GetByName(category.Name)).ReturnsAsync(dataBaseCategory);
            _mockCategory.Setup(x => x.Exist(category.Id)).ReturnsAsync(true);

            var result = _validator.TestValidate(category);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void MandatoryNameTest()
        {
            var category =  GetDefaultModel();
            category.Name = string.Empty;

            var result = _validator.TestValidate(category);

            result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage("Nome da categoria é obrigatório.");
        }

        [Test]
        public void MaxLengthNameTest()
        {
            var category = GetDefaultModel();
            category.Name = TestUtil.GenerateRandomText(51);

            var result = _validator.TestValidate(category);

            result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage("Nome da categoria não pode ultrapassar 50 caracteres.");
        }

        [Test]
        public void AlreadyUsedNameTest()
        {
            var dataBaseCategory = GetDefaultModel();
            var category = GetDefaultModel();

            _mockCategory.Setup(x => x.GetByName(category.Name)).ReturnsAsync(dataBaseCategory);
            _mockCategory.Setup(x => x.Exist(category.Id)).ReturnsAsync(true);

            var result = _validator.TestValidate(category);

            result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage("Nome já utilizado por outra categoria.");
        }

        #region PRIVATE METHODS

        private CategoryModel GetDefaultModel()
        {
            return new CategoryModel
            {
                Id = Guid.NewGuid(),
                Name = "Category 1",
            };
        }

        #endregion
    }
}