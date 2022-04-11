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

        /// <summary>
        /// Convierte un numero binario ingresado por el usuario a decimal
        /// </summary>
        /// <param name="binario">numero binario</param>
        /// <returns>De ser correcto devuelve el numero en decimal, caso contrario [Valor inválido]</returns>
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

        /// <summary>
        /// Convierte un numero decimal ingresado por el usuario a binario
        /// </summary>
        /// <param name="numero">numero decimal</param>
        /// <returns>De ser correcto devuelve el numero en binario, caso contrario [Valor inválido]</returns>
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

        /// <summary>
        /// Convierte un numero decimal ingresado por el usuario a binario
        /// </summary>
        /// <param name="numero">numero decimal en string</param>
        /// <returns>De ser correcto devuelve el numero en binario, caso contrario [Valor inválido]</returns>
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(ValidarOperando(numero));
        }

        /// <summary>
        /// Corrobora que el numero ingresado sea binario
        /// </summary>
        /// <param name="binario">numero binario</param>
        /// <returns>De ser el numero binario correctamente devuelve true, caso contrario false</returns>
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

        /// <summary>
        /// Resta de 2 objetos operando
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">operando 2</param>
        /// <returns>devuelve la resta de los 2 objetos</returns>
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Suma de 2 objetos operando
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">operando 2</param>
        /// <returns>devuelve la suma de los 2 objetos</returns>
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// División de 2 objetos operando
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">operando 2</param>
        /// <returns>devuelve la división de los 2 objetos</returns>
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

        /// <summary>
        /// Multiplicación de 2 objetos operando
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">operando 2</param>
        /// <returns>devuelve la multiplicación de los 2 objetos</returns>
        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Valida que el string ingresado sea un numero
        /// </summary>
        /// <param name="strNumero">numero en string</param>
        /// <returns>De poder parsearlo se lo devuelve como double, caso contrario [0]</returns>
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
