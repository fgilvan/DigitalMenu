using AutoMapper;
using DigitalMenu.Application.Common.Automapper;
using DigitalMenu.Application.Model.Category;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities.Category;
using DigitalMenu.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalMenu.Application.Common.AutoMapper.Mapping.ProductMap
{
    public class CategoryMap : IAutoMapper
    {
        public void Map(Profile profile)
        {
            profile.CreateMap<CategoryObj, CategoryModel>().ReverseMap();
        }
    }
}
