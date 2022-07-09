using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Paths
    {
        static string cadenaDB = "Server=.;Database=SwiftMedicalDB;Trusted_Connection=True;";
        static string archivos = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";

        public static string CadenaDB
        {
            get { return cadenaDB; }
        }

        public static string Archivos
        {
            get { return archivos; }
        }
    }
}
