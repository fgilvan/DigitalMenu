using DigitalMenu.Core.Entities.Category;
using DigitalMenu.Core.Entities.Product;
using DigitalMenu.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Infrastructure.Persistence.Repository
{
    public class RepositoryCategory : RepositoryBase<CategoryObj>, IRepositoryCategory
    {
        public RepositoryCategory(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }
        public Task<CategoryObj> GetByName(string name)
        {
            var obj = ApplicationDbContext.Category.FirstOrDefaultAsync(x => x.Name == name);

            ApplicationDbContext.Entry(obj).State = EntityState.Detached;

            return obj;
        }
    }
}
