//#define FUNSION
namespace Ejercicio6
{
    /* Realiza las siguientes funciones en el mismo programa y has el c ódigo en el
main para probarlas. Debe ejecutar una u otra dependiendo de una directiva
de compilación:
a) Función que se le pase un número y calcula el factorial del mismo. Si el
número es negativo o mayor de 10 la función devuelve false. En caso contrario
devuelve false. El resultado del factorial irá en un parámetro por referencia.
b) Función que dibuja en posiciones aleatorias de la pantalla la cantidad de
asteriscos que se le pasa como parámetro. Lo harán entre las filas 1 y 10 y las
columnas 1 y 20. Si no se le pasa ningún parámetro dibujará 10 asteriscos.
Usa Console.SetCursorPosition para la colocación*/

    internal class Program
    {
        public static bool factorial(int num, ref int factorial)
        {
            if(num<0 || num > 10)
            {
                return false;
            }
            else
            {
                for(int i = 1; i <= num; i++)
                {
                    factorial = factorial * i;
                }
            }
            return true;
        }

        public static void dibuja(int num = 10)
        {
            Random generador = new Random();

            for (int i = 0; i < num; i++)
            {
                int ejeX = generador.Next(1, 11);
                int ejeY = generador.Next(1, 21);
                Console.SetCursorPosition(ejeX, ejeY);
                Console.WriteLine("*");
            }

            
        }
            static void Main(string[] args)
        {
#if FUNSION 
            int facts = 1;
            Console.WriteLine("Vou calcular o factorial do teu numero");
            int num = Convert.ToInt32(Console.ReadLine());
            if(factorial(num, ref facts))
            {
                Console.WriteLine("O factorial de {0} é {1}", num, facts);
            }
            else
            {
                Console.WriteLine("Non é posible calcular o factorial de {0}", num);
            }
            //Console.WriteLine("{0} , {1}", factorial(15,ref facts), factorial(3,ref facts));
            
#else
            Console.WriteLine("Quere decidir cantos asteriscos debuxo? (S/N)");
            string decision = Console.ReadLine().ToUpper();
            if(decision == "S")
            {
                Console.WriteLine("Cantos asteriscos?");
                int numAster = Convert.ToInt32(Console.ReadLine());
                dibuja(numAster);
            }
            else
            {
                dibuja();
            }

#endif
            
        }
    }
}