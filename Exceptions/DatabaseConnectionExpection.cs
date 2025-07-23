using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class DatabaseConnectionExpection : Exception
    {
        
        public DatabaseConnectionExpection(string message, int id) : base (message)
        {
            message = "xD";
        }
    }
}
