using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator
{
    internal static class PropertiesInfoProcessor
    {
        internal static List<PropertyInfo> GetSettableProperties(List<PropertyInfo> allProperties)
        {
            return new List<PropertyInfo>(allProperties.Where(item => !item.GetSetMethod().IsPrivate));
        }
    }
}
