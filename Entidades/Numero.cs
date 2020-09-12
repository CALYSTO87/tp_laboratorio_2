using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad solo SET
        /// </summary>
        private string SetNumero
        {
        //Al tener el método ValidarNumero privado lo utilizo dentro de la clase 
        //a fin de validar cuando seteo el valor del mismo dentro de la propiedad
            set { numero = ValidarNumero(value); }

        }

        public Numero()
        {
            this.numero = default(double);
        }

        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }


        private double ValidarNumero(string strNumero)
        {
            double valorRetorno;

            if (double.TryParse(strNumero, out valorRetorno))
                return valorRetorno;
            else
                return 0;
        }


        public string BinarioDecimal(string binario)
        {
            string resultante;

            if (EsBinario(binario) == true)
                resultante = Convert.ToInt32(binario, 2).ToString();
            else
                resultante = "Valor Inválido";

            return resultante;
        }

        public string DecimalBinario(double numero)
        {
            //Reutilizo código del otro metodo
            return DecimalBinario(numero.ToString());
        }

        public string DecimalBinario(string numero)
        {
            //Utilizo constructor de clase Numero para convertir a double mi string
             Numero numString = new Numero(numero);

            //Utilizo funcion Math.Floor para redondear para abajo decimal con ,
             double numeroDecimal = Math.Floor(numString.numero);

            string binario = string.Empty;

            //Valido antes de entrar al while que el nro sea mayor a 0
             if (numString.numero > 0)
             {
                 while (numString.numero > 0)
                 {
                     if (numString.numero % 2 == 0)
                     {
                         // resultante = numString.numero + resultante;
                         binario = "0" + binario;
                     }
                     else
                     {
                         binario = "1" + binario;
                         // resultante = numString.numero + resultante;
                     }
                     numString.numero /= 2;

                    //Redondeo hacia abajo
                    numString.numero = Math.Floor(numString.numero);
                }
             }
             else
                 binario = "Valor Inválido";

             return binario;
        }

        private bool EsBinario(string binario)
        {
            bool validaBinario = true;
            //Valido si en el string hay caracteres diferentes a 0 y 1 para asegurar el binario
            foreach (var c in binario)
            {
                if (c != '0' && c != '1')
                    validaBinario= false;
                //Había empezado a validarlo de esta forma, pero por cada iteración
                //pasaba por el true, recargando a futuro el procesamiento
                //hasta que noté que seteando en true la variable validabinario ya no era necesario
                /*
                else
                    validabinario = true;*/
            }
            return validaBinario;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;
            return resultado;

        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;
            return resultado;

        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;
            //valido que el divisor no sea 0
            if (n2.numero == 0)
                resultado = double.MinValue; //devuelvo double.minvalue
            else
                resultado = n1.numero / n2.numero;

            return resultado;

        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;
            return resultado;

        }
    }
}
