﻿using DigitalMenu.Application.Model.Category;
using DigitalMenu.Application.Model.Product;
using DigitalMenu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Interfaces
{
    public interface IServiceCategory : IServiceBase<CategoryModel>
    {
        Task<CategoryModel> GetByName(string name);
    }
}
