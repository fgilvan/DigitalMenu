using AutoMapper;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Tests.AutomapperTest
{
    public class ProductAutomapperTest
    {
        private IMapper _mapper;
        private MapperConfiguration _config;

        [SetUp]
        public void Setup()
        {
            _config = new MapperConfiguration(config => config.AddMaps(new[] { "DigitalMenu.Application" }));

            _mapper = _config.CreateMapper();
        }

        [Test]
        public void ProductModelToObjTest()
        {
            var productModel = GetDefaultModel();

            var obj = _mapper.Map<ProductObj>(productModel);

            Assert.That(obj.Name, Is.EqualTo(productModel.Name));
            Assert.That(obj.Description, Is.EqualTo(productModel.Description));
        }

        [Test]
        public void ObjToProductModelTest()
        {
            var productObj = GetDefaultObj();

            var model = _mapper.Map<ProductModel>(productObj);

            Assert.That(model.Name, Is.EqualTo(productObj.Name));
            Assert.That(model.Description, Is.EqualTo(productObj.Description));
        }

        #region PRIVATE METHODS

        private ProductModel GetDefaultModel()
        {
            return new ProductModel
            {
                Id = Guid.NewGuid(),
                Name = "ProductModel 1",
                Description = "ProductModel description 1",
                CategoryId = Guid.NewGuid(),
            };
        }

        private ProductObj GetDefaultObj()
        {
            return new ProductObj
            {
                Id = Guid.NewGuid(),
                Name = "ProductModel 1",
                Description = "ProductModel description 1",
                CategoryId = Guid.NewGuid(),
            };
        }

        #endregion
    }
}
