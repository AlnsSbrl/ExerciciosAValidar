using System;

namespace Ejercicio4
{
    class Program
    {

        static void opcion1(int numero = 6)
        {
            Console.WriteLine(numero);
            string volver;
            do
            {
                int acertos = 0;
                /*. Pedir un número al usuario del 1 al X, tirar diez dados mostrando el resultado de cada uno e
informar al usuario de cuantas veces ha acertado. X es un parámetro que si no se pasa se inicializa 
por defecto a 6. */
                Random generador = new Random();
                for (int i = 0; i < numero; i++)
                {
                    int randomNumber = generador.Next(numero + 1);
                    Console.WriteLine("Tirada {0}: Número {1}", i + 1, randomNumber);
                    if (randomNumber == numero)
                    {
                        acertos++;
                    }
                }

                Console.WriteLine("O número de tiradas onde coincidiu con {0} foi de {1}", numero, acertos);

                Console.WriteLine("Quere rematar o xogo?(S/N)");
                volver = Console.ReadLine().ToUpper();
            } while ( !(volver == "S"));

        }

        static void opcion2()
        {
            string volver;
            do
            {
                Random generador = new Random();
                int numeroRandom = generador.Next(1,101);
                int numeroUsuario = -1;
                for (int i = 5; i >0 && numeroRandom!= numeroUsuario; i--)
                {
                    
                        Console.WriteLine("intente adiviñar o numero {0}", numeroRandom);
                        numeroUsuario = Convert.ToInt32(Console.ReadLine());
                        if (numeroUsuario == numeroRandom)
                        {
                            Console.WriteLine("Incrible, acertaches que era o {0} no intento nº {1}", numeroUsuario, 6 - i);
                            //break;
                        }
                        else if (numeroUsuario > numeroRandom)
                        {
                            Console.WriteLine("Bro, pasácheste. Quédante {0} intentos", i - 1);
                        }
                        else
                        {
                            Console.WriteLine("Quedacheste curto. Quédante {0} intentos", i - 1);
                        }
                }
                Console.WriteLine("Quere rematar o xogo?(S/N)");
                volver = Console.ReadLine().ToUpper();
            } while (volver != "S");
        }

        static void opcion3()
        {   /*  Realizar una quiniela: Se deben dar 14 resultados aleatorios como 1, X ó 2 de forma 
ponderada. La probabilidad de sacar 1 sea del 60%, la de sacar X sea 25% y la de sacar un 2 sea un 
15%. Se debe realizar al menos una función que devuelva un 1 una X o un 2 ponderado de la forma 
anterior., sacando un número de 1 a 100 y seleccionando el valor devuelto con un switch con clausula 
when. */
            string volver;
            do
            {

                Random generador = new Random();
                string resultado = "";
                for (int i = 0; i < 15; i++)
                {

                    switch (Convert.ToInt32(generador.Next(1, 101)))
                    {
                        case int x when x <= 60:
                            resultado = "1";
                            goto default;

                        case int x when x > 60 && x <= 85:
                            resultado = "x";
                            goto default;
                        case int x when x > 85:
                            resultado = "2";
                            goto default;
                        default:
                            Console.WriteLine("Partido {0}: {1}", i + 1, resultado);
                            break;
                    }

                }
                Console.WriteLine("Quere rematar o xogo?(S/N)");
                volver = Console.ReadLine().ToUpper();
            } while (volver != "S");
            //Console.WriteLine("EEEE");
        }
        static void Main(string[] args)
        {
            int caso;
            int numero;
            do
            {
                Console.WriteLine("Seleccione un xogo:\n"
                    + "1)Dados\n"
                    + "2)Adiviñar número\n"
                    + "3)Quiniela\n"
                    + "4)Todos os anteriores\n"
                    + "5)Saír");
                caso = Convert.ToInt32(Console.ReadLine());

                switch (caso)
                {
                    case 1:
                        Console.WriteLine("Quere introducir un valor máximo?(S/N)");
                        string introduce = Console.ReadLine().ToUpper();
                        if (introduce == "S")
                        {
                            Console.WriteLine("Introduza o valor máximo da tirada");
                            numero = Convert.ToInt32(Console.ReadLine());
                            opcion1(numero);
                        }
                        else
                        {
                            opcion1();
                        }

                        if (caso == 4)
                        {
                            goto case 2;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                        opcion2();
                        if (caso == 4)
                        {
                            goto case 3;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        opcion3();
                        break;
                    case 4:
                        goto case 1;
                    //goto case 2;
                    //goto case 3;

                    case 5:
                        break;
                    default:
                        break;


                }
            } while (caso != 5);
        }
    }
}
