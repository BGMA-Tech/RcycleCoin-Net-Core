﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.JsonResults.Concrete;

namespace Core.Utilities.JsonResults.Abstract
{
    public interface IJsonResult
    {
        bool Success { get; }
        Error ErrorMessage { get; }
    }
}