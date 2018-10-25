using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.Generators
{
    public class LongGenerator : IGenerator
    {
        Random random;

        public LongGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.Next(int.MinValue, int.MaxValue) + random.Next(int.MinValue, int.MaxValue);
        }

        public Type GetGeneratorType()
        {
            return typeof(long);
        }
    }
}
