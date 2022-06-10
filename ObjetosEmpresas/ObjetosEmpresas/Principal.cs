using System;
using System.Collections.Generic;
using System.Text;

namespace ObjetosEmpresas
{
    class Principal
    {
        static double beneficiosEmpresa;
        static void pastaGansa(IPastaGansa empresario)
        {
            
            Console.WriteLine("Cuanto ganó la empresa?");
            beneficiosEmpresa = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Esta persona ha ganado {0} por las acciones que tiene de la empresa", empresario.ganarPasta(beneficiosEmpresa));
        }
        static void Main()
        {
            Directivo florentino = new Directivo("Finanzas",528,"Florentino","Perez","12345678",75);
            Empleado currelas = new Empleado(40000,"671923923","Curro","Bellas","37584273",31);
            EmpleadoEspecial benzema = new EmpleadoEspecial(40000,"645928354","Karim", "Benzema", "53820240",35);
            
            int opcion;
            do
            {
                Console.WriteLine("Seleccione una opcion:\n"
                    +"1)Visualizar datos de directivo\n"
                    +"2)Visualizar datos de empleado\n"
                    +"3)Visualizar datos de empleado Especial\n");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        pastaGansa(florentino);
                        florentino.MuestraCampos();
                        Console.WriteLine("Esta persona ha ganado por la empresa {0}",florentino.PastaGanada);
                        Console.WriteLine("Esta persona le debe a hacienda {0}",florentino.Hacienda());
                        break;
                    case 2:
                        currelas.MuestraCampos();
                        Console.WriteLine(currelas.Hacienda());
                        break;
                    case 3:
                        pastaGansa(benzema);
                        benzema.MuestraCampos();                        
                        Console.WriteLine("Esta persona ha ganado por la empresa {0}", benzema.PastaGanada);
                        Console.WriteLine("Esta persona le debe a hacienda {0}", benzema.Hacienda());
                        break;
                }
                

            } while (opcion>0 && opcion<4);
        }
    }
}
