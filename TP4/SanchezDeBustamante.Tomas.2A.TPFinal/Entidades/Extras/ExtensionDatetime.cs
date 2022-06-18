using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionDatetime
    {
        public static string AgregarFecha(this DateTime d)
        {
            return DateTime.Now.ToShortDateString().ToString();
        }
    }
}
