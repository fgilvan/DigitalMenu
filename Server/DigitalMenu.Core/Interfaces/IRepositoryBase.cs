using DigitalMenu.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Core.Interfaces
{
    public interface IRepositoryBase<TObj>
    {
        Task<TObj[]> GetAll();

        Task<TObj> Get(Guid id, bool asNoTraking);

        void Add<T>(T entity);

        void Update<T>(T entity);

        void Delete<T>(T entity);

        Task<bool> SaveChangesAsync();
    }
}
