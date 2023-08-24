using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Application.Common.Automapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            SetMapFromAssembly();
        }

        #region PRIVATE METHODS

        private void SetMapFromAssembly()
        {
            var types = GetTypesForMapping();
            var mappingMethodName = nameof(IAutoMapper.Map);
            var argumentTypes = new Type[] { typeof(Profile) };

            types?.ForEach(typeForMapping =>
            {
                var method = typeForMapping.GetMethod(mappingMethodName, argumentTypes);

                method?.Invoke(Activator.CreateInstance(typeForMapping), new object[] { this });
            });
        }

        private static List<Type> GetTypesForMapping()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly
                .GetTypes()
                .Where(type => type.GetInterfaces().Any(i =>  i.Equals(typeof(IAutoMapper))))
                .ToList();

            return types;
        }

        #endregion
    }
}
