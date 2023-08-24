using AutoMapper;
using DigitalMenu.Application.Common.Automapper;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalMenu.Application.Common.AutoMapper.Mapping.ProductMap
{
    public class ProductMap : IAutoMapper
    {
        public void Map(Profile profile)
        {
            profile.CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
