using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivoNoEncontradoException : Exception
    {
        public ArchivoNoEncontradoException()
        {
        }

        public ArchivoNoEncontradoException(string message) : base(message)
        {
        }

        public ArchivoNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
