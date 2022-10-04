using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Exceptions
{
    public class AppInitializeException : Exception
    {
        public AppInitializeException()
        {
        }

        public AppInitializeException(string message) : base(message)
        {
        }
    }
}
