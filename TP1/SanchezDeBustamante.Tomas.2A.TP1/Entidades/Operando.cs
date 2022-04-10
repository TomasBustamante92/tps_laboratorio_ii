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
            this.numero = numero;
        }

        public Operando(string strNumero) : this()
        {
            this.Numero = strNumero;
        }

        private string Numero
        {
            set { this.numero = ValidarOperando(value); } 
        }

        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            int cantidadCaracteres;

            if(EsBinario(binario))
            {
                cantidadCaracteres = binario.Length;
                foreach (char c in binario)
                {
                    cantidadCaracteres--;
                    if(c == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }

                return resultado.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }

        public string DecimalBinario(double numero)
        {
            string valorBinario = "";
            int division = (int)numero;
            int modulo;

            if(division > 0)
            {
                do
                {
                    modulo = division % 2;
                    division /= 2;
                    valorBinario = modulo.ToString() + valorBinario;
                } while (division > 0);
            }
            else
            {
                valorBinario = "Valor inválido";
            }

            return valorBinario;
        }

        public string DecimalBinario(string numero)
        {
            return DecimalBinario(ValidarOperando(numero));
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
