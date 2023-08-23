using AutoMapper;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Common.Mapping
{
    public class ProductMap: Profile
    {
        public ProductMap()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
        }
    }
}
