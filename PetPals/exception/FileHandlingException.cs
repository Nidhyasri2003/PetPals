using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.exception
{
    public class FileHandlingException : Exception
    {
        public FileHandlingException(string message) : base(message) { }
    }
}