using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class InvalidCategoryName : Exception
    {
        public InvalidCategoryName(string message) : base(message) { }
    }
}
