using AutoMapper;
using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities;
using DigitalMenu.Core.Entities.Product;
using DigitalMenu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Services
{
    public class ServiceProduct: ServiceBase<ProductModel, Product>,IServiceProduct
    {
        public ServiceProduct(IRepositoryProduct repositoryProduct, IMapper mapper)
            :base(repositoryProduct, mapper)
        {
        }
    }
}
