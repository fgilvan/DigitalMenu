using AutoMapper;
using DigitalMenu.Application.Model.Category;
using DigitalMenu.Core.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Tests.AutomapperTest
{
    public class CategoryAutomapperTest
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
        public void CategoryModelToObjTest()
        {
            var categoryModel = GetDefaultModel();

            var obj = _mapper.Map<CategoryObj>(categoryModel);

            Assert.That(obj.Name, Is.EqualTo(categoryModel.Name));
        }

        [Test]
        public void ObjToCategoryModelTest()
        {
            var categoryObj = GetDefaultObj();

            var model = _mapper.Map<CategoryModel>(categoryObj);

            Assert.That(model.Name, Is.EqualTo(categoryObj.Name));
        }

        #region PRIVATE METHODS

        private CategoryModel GetDefaultModel()
        {
            return new CategoryModel
            {
                Id = Guid.NewGuid(),
                Name = "CategoryModel 1",
            };
        }

        private CategoryObj GetDefaultObj()
        {
            return new CategoryObj
            {
                Id = Guid.NewGuid(),
                Name = "CategoryModel 1",
            };
        }

        #endregion
    }
}
