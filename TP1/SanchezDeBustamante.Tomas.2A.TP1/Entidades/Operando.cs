using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero) : this()
        {
            // hacer

        }

        public Operando(string strNumero) : this()
        {
            // hacer

        }

        private string Numero
        {
            set { this.numero = ValidarOperando(value); } 
        }

        public string BinarioDecimal(string binario)
        {
            // hacer

            return "";

        }

        public string DecimalBinario(double numero)
        {
            // hacer

            return "";

        }

        public string DecimalBinario(string numero)
        {
            // hacer

            return "";
        }

        private bool EsBinario(string binario)
        {
            foreach (char c in binario)
            {
                if(c != '0' && c != '1')
                {
                    return false;
                }
            }

            return true;
        }

        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator / (Operando n1, Operando n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        private double ValidarOperando(string strNumero)
        {
            double numero;

            if(double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

    }
}
