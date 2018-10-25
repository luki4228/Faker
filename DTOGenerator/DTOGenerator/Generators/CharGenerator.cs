using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.Generators
{
    public class CharGenerator : IGenerator
    {
        Random random;

        public CharGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return Convert.ToChar(random.Next(65, 122));
        }
    }
}
