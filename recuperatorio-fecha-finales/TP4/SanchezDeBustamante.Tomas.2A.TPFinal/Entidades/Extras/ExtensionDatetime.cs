using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionDatetime
    {
        /// <summary>
        /// Devuelve la fecha dd/mm/yyyy en formato string
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string AgregarFecha(this DateTime d)
        {
            return DateTime.Now.ToShortDateString().ToString();
        }
    }
}
