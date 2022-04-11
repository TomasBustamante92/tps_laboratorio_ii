using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operación matematica con los numeros y el operador ingresado por el usuario
        /// </summary>
        /// <param name="num1">primer numero de la ecuación</param>
        /// <param name="num2">segundo numero de la ecuación</param>
        /// <param name="operador">operador de la ecuación</param>
        /// <returns>devuelve el resultado de la ecuación, de ser invalido el operador se devolverá [0]</returns>
        public double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                default:
                    resultado = 0;
                    break;
            }

            return resultado;
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
