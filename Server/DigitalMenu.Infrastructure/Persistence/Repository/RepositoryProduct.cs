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
    public class RepositoryProduct : RepositoryBase<ProductObj>, IRepositoryProduct
    {
        public RepositoryProduct(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }

        public async Task<ProductObj> GetByName(string name)
        {
            var obj = await ApplicationDbContext.Product.FirstOrDefaultAsync(x => x.Name == name);

            if (obj != null) 
                ApplicationDbContext.Entry(obj).State = EntityState.Detached;

            return obj;
        }
    }
}
