using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
      
    //El metodo ValidarOperador será privado y estatico. 
    //Deberá validar que el operador recibido sea +,-,* y /. 
    //Caso contrario devolverá +.
     private static string ValidarOperador(char operador)
        {

            switch(operador)
            {
                case '+':
                    break;
                case '-':
                    break;
                case '*':
                    break;
                case '/':
                    break;
                default:
                    return "+";
            }
            //Ya que ingreso char pero debo devolver un string convierto en el return
            return operador.ToString();

        }

     //El método Operar sera de clase: 
     //validará y realizará la operación pedida entre ambos numeros
   public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;
            string operadorValidado;
            //Valido que el operador no sea null, de ser así y a fin de dejar lugar al metodo ValidarOperador
            //seteo operador en un string identificable por el metodo en este caso 0 como valor arbitrario
            //dado que ValidarOperador me devolverá "+" por default.
            if (operador == "")
                  operador = "0";

                //Ya que el método ValidarOperador debe recibir un char y yo tengo un string
                //convierto este string en un array de caracteres y solo selecciono el primero

                char[] operadorAChar= operador.ToCharArray();

            operadorValidado = ValidarOperador(operadorAChar[0]);

           // resultado = num1 + operadorValidado + num2;

            switch(operadorValidado)
                {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                }

            return resultado;

        }

    }
}
