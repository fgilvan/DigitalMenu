using AutoMapper;
using DigitalMenu.Application.Exceptions;
using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities;
using DigitalMenu.Core.Entities.Product;
using DigitalMenu.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Services
{
    public class ServiceBase<TModel, TObj> : IServiceBase<TModel>
        where TModel : ModelBase
    {
        private IRepositoryBase<TObj> _repository;
        private IMapper _mapper;

        public ServiceBase(IRepositoryBase<TObj> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected IRepositoryBase<TObj> Repositorio => _repository;

        protected IMapper Mapper => _mapper;

        public async Task<TModel[]> GetAll()
        {
            var objList = await Repositorio.GetAll();

            var models = Mapper.Map<TModel[]>(objList);

            return models;
        }

        public async Task<TModel> Get(Guid id)
        {
            var obj = await Repositorio.Get(id, false);

            if (obj == null)
            {
                throw new NotFoundException("Registro Não Encontrado.");
            }

            var model = Mapper.Map<TModel>(obj);

            return model;
        }

        public async Task<bool> Exist(Guid id)
        {
            var obj = await Repositorio.Get(id, false);

            return obj != null;
        }

        public async Task Add(TModel model)
        {
            var obj = Mapper.Map<TObj>(model);

            Repositorio.Add(obj);

            await Repositorio.SaveChangesAsync();
        }

        public async Task Update(TModel model)
        {
            var obj = await Repositorio.Get(model.Id, true);

            if(obj == null)
            {
                throw new NotFoundException("Registro Não Encontrado.");
            }

            obj = Mapper.Map<TObj>(model);

            Repositorio.Update(obj);
            await Repositorio.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var obj = await Repositorio.Get(id, true);

            if (obj == null)
            {
                throw new NotFoundException("Registro Não Encontrado.");
            }

            Repositorio.Delete(obj);
            await Repositorio.SaveChangesAsync();
        }
    }
}
