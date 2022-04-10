using System;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Operando num1, Operando num2, char operador)
        {
            // hacer

            return 0;
        }

        /// <summary>
        /// Valida que el operador sea valido
        /// </summary>
        /// <param name="operador"> operador a validar </param>
        /// <returns> de ser correcto devuelve el operador, caso contrario [+]</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
    }
}
