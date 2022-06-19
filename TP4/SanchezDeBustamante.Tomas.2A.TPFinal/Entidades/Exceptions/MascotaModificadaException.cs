using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MascotaModificadaException : Exception
    {
        public MascotaModificadaException()
        {
        }

        public MascotaModificadaException(string message) : base(message)
        {
        }

        public MascotaModificadaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
