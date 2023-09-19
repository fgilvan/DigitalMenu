using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalMenu.Core.Entities.Category;

namespace DigitalMenu.Core.Entities.Product
{
    public class ProductObj: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryObj Category { get; set; }
    }
}
