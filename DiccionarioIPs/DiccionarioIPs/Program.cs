using System.Collections;
using System.Text.RegularExpressions;

namespace DiccionarioIPs
{
    internal class Program
    {

        /*Crear una tabla hash (Hashtable o Dictionary) usando como clave las IPs de
ordenadores y como valor la cantidad de memoria RAM que tiene el equipo en
GB. Se plantea un menú de introducción de datos, elimina un dato (por clave),
muestra de la colección entera y muestra de un elemento de la colección.
Al pedir datos se debe comprobar que la IP es válida y que la cantidad de RAM
es un entero positivo. */

        static void Main(string[] args)
        {

            int opcionMenu;
            Hashtable direccionesIP = new Hashtable();

            do
            {

                bool opcionValida;
                Console.WriteLine("Menú"
                    + "\n1)Introducir dato"
                    + "\n2)Eliminar dato (por chave)"
                    + "\n3)Mostrar a colección de IPs"
                    + "\n4)Mostrar un elemento da coleccion");

                opcionValida = int.TryParse(Console.ReadLine(), out opcionMenu);
                Regex IPCheck = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");



                if (opcionValida)
                {
                    switch (opcionMenu)
                    {
                        case 1: //introducir dato

                            bool existeClave;
                            bool introduccionErronea;
                            string IP;
                            int capacidadeMemoria;
                            string[] checkLimits;
                            do
                            {
                                existeClave = false;
                                introduccionErronea = false;
                                Console.WriteLine("Introduza unha IP");
                                IP = Console.ReadLine();
                                checkLimits = IP.Split(".");
                                int num;
                                for (int i = 0; i < checkLimits.Length; i++)
                                {
                                    int.TryParse(checkLimits[i], out num);
                                    if (num < 0 || num > 255)
                                    {
                                        introduccionErronea = true;
                                    }
                                }
                                if (!IPCheck.IsMatch(IP) || checkLimits.Length > 4 || introduccionErronea)
                                {
                                    Console.WriteLine("A IP non está ben escrita");
                                }
                                else
                                {
                                    if (direccionesIP.ContainsKey(IP))
                                    {
                                        existeClave = true;
                                        Console.WriteLine("A clave xa existe, introduza outra");
                                    }
                                }

                            } while (!IPCheck.IsMatch(IP) || existeClave || checkLimits.Length > 4 || introduccionErronea);

                            do
                            {
                                Console.WriteLine("Introduza a súa capacidade en GBs");
                                introduccionErronea = !int.TryParse(Console.ReadLine(), out capacidadeMemoria);
                                if (introduccionErronea || capacidadeMemoria <= 0)
                                {
                                    Console.WriteLine("A capacidade ten que ser un número enteiro positivo!!");
                                }
                            } while (introduccionErronea || capacidadeMemoria <= 0);

                            direccionesIP.Add(IP, capacidadeMemoria);
                            break;

                        case 2: //eliminar dato por clave

                            string claveABorrar;
                            bool introduccionIncorrecta;
                            do
                            {
                                introduccionErronea= false;
                                Console.WriteLine("Introduza a IP a borrar");
                                claveABorrar = Console.ReadLine();
                                checkLimits = claveABorrar.Split(".");
                                int num;
                                for (int i = 0; i < checkLimits.Length; i++)
                                {
                                    int.TryParse(checkLimits[i], out num);
                                    if(num<0 || num > 255)
                                    {
                                        introduccionIncorrecta = true;
                                    }
                                }
                                if (!IPCheck.IsMatch(claveABorrar))
                                {
                                    Console.WriteLine("Error, as IPs non se escriben así");
                                }
                            } while (!IPCheck.IsMatch(claveABorrar)||introduccionErronea||checkLimits.Length>4);

                            /*existeClave = false;
                                introduccionErronea = false;
                                Console.WriteLine("Introduza unha IP");
                                IP = Console.ReadLine();
                                checkLimits = IP.Split(".");
                                int num;
                                for (int i = 0; i < checkLimits.Length; i++)
                                {
                                    int.TryParse(checkLimits[i], out num);
                                    if (num < 0 || num > 255)
                                    {
                                        introduccionErronea = true;
                                    }
                                }
                                if (!IPCheck.IsMatch(IP) || checkLimits.Length > 4 || introduccionErronea)
                                {
                                    Console.WriteLine("A IP non está ben escrita");
                                }
                                else
                                {
                                    if (direccionesIP.ContainsKey(IP))
                                    {
                                        existeClave = true;
                                        Console.WriteLine("A clave xa existe, introduza outra");
                                    }
                                }

                            } while (!IPCheck.IsMatch(IP) || existeClave || checkLimits.Length > 4 || introduccionErronea);*/

                            if (direccionesIP.ContainsKey(claveABorrar))
                            {
                                direccionesIP.Remove(claveABorrar);
                                Console.WriteLine("Borrouse con éxito");
                            }
                            else
                            {
                                Console.WriteLine("A IP non existe na base de datos");
                            }
                            break;

                        case 3: //mostrar a coleccion
                            if (direccionesIP.Count == 0)
                            {
                                Console.WriteLine("A base de datos de IPs está baleira");
                            }
                            else
                            {

                                foreach (DictionaryEntry item in direccionesIP)
                                {
                                    Console.WriteLine("A dirección {0} ten {1} GBs de memoria", item.Key, item.Value);
                                }
                            }
                            break;
                        case 4:
                            if (direccionesIP.Count == 0)
                            {
                                Console.WriteLine("A base de datos de IPs está baleira, que pretendes buscar así?");
                            }
                            else
                            {
                                string claveAMostrar;
                                bool atopouse = false;
                                do
                                {
                                    Console.WriteLine("Diga a IP a buscar na base de datos");
                                    claveAMostrar = Console.ReadLine();
                                } while (!IPCheck.IsMatch(claveAMostrar));


                                if (direccionesIP.ContainsKey(claveAMostrar))
                                {
                                    Console.WriteLine("Atopouse a direccion {0}, que ten {1} GBs de memoria", claveAMostrar, direccionesIP[claveAMostrar]);

                                }
                                else

                                {
                                    Console.WriteLine("A direccion {0} non está na base de datos", claveAMostrar);
                                }
                            }//mostrar un elemento da coleccion

                            break;
                        case 5: //sair I guess
                            Console.WriteLine("Chao, pescao");
                            break;
                        default:
                            break;
                    }
                }
            } while (opcionMenu != 5);
        }
    }
}