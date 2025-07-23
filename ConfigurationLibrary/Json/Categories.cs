using Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace ConfigurationLibrary
{
    public class Categories
    {
        public Combat Combat { get; set; }
        public Movement Movement { get; set; }
        public Misc Misc { get; set; }
        public Visual Visual { get; set; }
    }
}