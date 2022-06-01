using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NombreNoExisteEnLista : Exception
    {
        public NombreNoExisteEnLista()
        {
        }

        public NombreNoExisteEnLista(string message) : base(message)
        {
        }

        public NombreNoExisteEnLista(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
