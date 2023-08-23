using DigitalMenu.Core.Entities;
using DigitalMenu.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Infrastructure.Persistence.Repository
{
    public class RepositoryBase<TObj> : IRepositoryBase<TObj>
        where TObj : EntityBase
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public async Task<TObj[]> GetAll()
        {
            ////TODO: Verificar alternativa
            //var query = ApplicationDbContext.Product;
            throw new NotImplementedException();
            //return await query.AsNoTracking().OrderBy(x => x.Id).ToArrayAsync();
        }

        public async Task<TObj> Get(Guid id, bool asNoTraking)
        {
            var obj = await ApplicationDbContext.FindAsync<TObj>(id);

            if (asNoTraking && obj != null)
                ApplicationDbContext.Entry(obj).State = EntityState.Detached;

            return obj;
        }

        public void Add<T>(T entity)
        {
            ApplicationDbContext.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            ApplicationDbContext.Remove(entity);
        }

        public void Update<T>(T entity)
        {
            ApplicationDbContext.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await ApplicationDbContext.SaveChangesAsync() > 0);
        }
    }
}
