using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoCartel(int ejeX);
    public delegate int DelegadoCantidadMascotas(Duenio duenio);
    public delegate void DelegadoCargarMascotaEnLista(Mascota mascota, bool modificar);
}
