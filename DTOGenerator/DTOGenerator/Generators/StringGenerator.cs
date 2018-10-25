﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class StringGenerator : IGenerator
    {
        CharGenerator charGenerator;

        public StringGenerator()
        {
            charGenerator = new CharGenerator();
        }

        public object Generate()
        {
            char[] stringChars = new char[10];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = (char)charGenerator.Generate();
            }
      
            return new string(stringChars);
        }
    }
}
