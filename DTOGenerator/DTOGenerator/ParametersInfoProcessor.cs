﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator
{
    internal static class ParametersInfoProcessor
    {
        internal static List<ParameterInfo> GetParametersInfo(ConstructorInfo constructor)
        {
            return constructor.GetParameters().ToList();
        }

        internal static bool IsParameterSimple(ParameterInfo parameter)
        {
            Type type = parameter.GetType();
            return type.IsPrimitive || type.Equals(typeof(string));
        }
    }
}
