﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator
{
    public interface ICollectionGenerator
    {
        object Generate(Type t);
    }
}
