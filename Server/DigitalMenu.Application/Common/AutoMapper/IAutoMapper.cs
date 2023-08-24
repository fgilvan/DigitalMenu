using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Common.Automapper
{
    public interface IAutoMapper
    {
        void Map(Profile profile);
    }
}
