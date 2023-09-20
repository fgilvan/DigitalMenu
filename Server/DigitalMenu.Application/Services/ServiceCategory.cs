using AutoMapper;
using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model.Category;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities;
using DigitalMenu.Core.Entities.Category;
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
    public class ServiceCategory : ServiceBase<CategoryModel, CategoryObj>, IServiceCategory
    {
        public ServiceCategory(IRepositoryCategory repositoryCategory, IMapper mapper)
            :base(repositoryCategory, mapper)
        {
        }

        public async Task<CategoryModel> GetByName(string name)
        {
            var objList = await ((IRepositoryCategory)Repositorio).GetByName(name);

            var models = Mapper.Map<CategoryModel>(objList);

            return models;
        }
    }
}
