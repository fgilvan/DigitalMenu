using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<T[]> GetAll();

        Task<T> Get(Guid id);

        Task<bool> Exist(Guid id);

        Task Add(T entity);

        Task Update(Guid id, T entity);

        Task Delete(Guid id);
    }
}
