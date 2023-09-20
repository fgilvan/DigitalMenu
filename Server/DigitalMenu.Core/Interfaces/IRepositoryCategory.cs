using DigitalMenu.Core.Entities.Category;
using DigitalMenu.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Core.Interfaces
{
    public interface IRepositoryCategory : IRepositoryBase<CategoryObj>
    {
        Task<CategoryObj> GetByName(string name);
    }
}
