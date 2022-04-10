using System;

namespace Entidades
{
    public class Calculadora
    {
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

                    Console.WriteLine("Esto no tiene que pasar");

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
