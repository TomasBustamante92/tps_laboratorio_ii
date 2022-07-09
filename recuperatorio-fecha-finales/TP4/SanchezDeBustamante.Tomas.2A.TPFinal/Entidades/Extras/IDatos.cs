using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IDatos
    {
        int Id { get; set; }

        string Nombre { get; set; }

        string Mostrar();
    }
}
