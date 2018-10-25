using DTOGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginGenerators
{
    public class IntGenerator : IGenerator
    {
        Random random;

        public IntGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.Next(int.MinValue, int.MaxValue);
        }

        public Type GetGeneratorType()
        {
            return typeof(int);
        }
    }
}
