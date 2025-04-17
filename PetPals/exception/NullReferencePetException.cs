using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.exception
{
    public class NullReferencePetException : Exception
    {
        public NullReferencePetException(string message) : base(message) { }
    }
}