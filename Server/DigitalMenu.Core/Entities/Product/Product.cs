using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Core.Entities.Product
{
    public class Product: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
