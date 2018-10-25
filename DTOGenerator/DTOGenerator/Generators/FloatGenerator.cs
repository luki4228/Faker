using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.Generators
{
    public class FloatGenerator : IGenerator
    {
        Random random;

        public FloatGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (float)(random.NextDouble() * float.MaxValue);
        }
    }
}
