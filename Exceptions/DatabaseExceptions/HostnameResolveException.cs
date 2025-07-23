using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.DatabaseExceptions
{
    public class HostnameResolveException : Exception
    {
        public HostnameResolveException(string message) : base(message) { }
    }
}
