using AutoMapper;
using DigitalMenu.Application.Exceptions;
using DigitalMenu.Application.Interfaces;
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
    {
        private IRepositoryBase<TObj> _repository;
        private IMapper _mapper;

        public ServiceBase(IRepositoryBase<TObj> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TModel[]> GetAll()
        {
            var objList = await _repository.GetAll();

            var models = _mapper.Map<TModel[]>(objList);

            return models;
        }

        public async Task<TModel> Get(Guid id)
        {
            var obj = await _repository.Get(id, false);

            if (obj == null)
            {
                throw new NotFoundException("Registro Não Encontrado.");
            }

            var model = _mapper.Map<TModel>(obj);

            return model;
        }

        public async Task Add(TModel model)
        {
            var obj = _mapper.Map<TObj>(model);

            _repository.Add(obj);

            await _repository.SaveChangesAsync();
        }

        public async Task Update(Guid id, TModel model)
        {
            var obj = await _repository.Get(id, true);

            if(obj == null)
            {
                throw new NotFoundException("Registro Não Encontrado.");
            }

            obj = _mapper.Map<TObj>(model);

            _repository.Update(obj);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var obj = await _repository.Get(id, true);

            if (obj == null)
            {
                throw new NotFoundException("Registro Não Encontrado.");
            }

            _repository.Delete(obj);
            await _repository.SaveChangesAsync();
        }
    }
}
