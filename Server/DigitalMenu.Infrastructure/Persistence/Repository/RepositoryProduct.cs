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
    public class RepositoryProduct : RepositoryBase<Product>,IRepositoryProduct
    {
        public RepositoryProduct(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }
    }
}
