﻿using System;
using System.Collections.Generic;
using System.Text;

namespace api_azure.test.Helpers
{
    class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        public void Dispose()
        {

        }

        private NullScope()
        { 

        }
    }
}
