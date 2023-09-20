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
    public class ServiceProduct: ServiceBase<ProductModel, ProductObj>, IServiceProduct
    {
        public ServiceProduct(IRepositoryProduct repositoryProduct, IMapper mapper)
            :base(repositoryProduct, mapper)
        {
        }

        public async Task<ProductModel> GetByName(string name)
        {
            var objList = await ((IRepositoryProduct)Repositorio).GetByName(name);

            var models = Mapper.Map<ProductModel>(objList);

            return models;
        }
    }
}
