using DigitalMenu.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Core.Entities.Category
{
    public class CategoryObj: EntityBase
    {
        public string Name { get; set; }

        public virtual IList<ProductObj> Products { get; set; }
    }
}
