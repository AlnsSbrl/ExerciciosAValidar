using System;
using System.Collections.Generic;
using System.Text;

namespace ObjetosEmpresas
{
    class Principal
    {
        static double beneficiosEmpresa;
        static double pastaGansa(IPastaGansa beneficiado)
        {
            Console.WriteLine("Cuanto ganó la empresa?");
            beneficiosEmpresa = Convert.ToDouble(Console.ReadLine());
            return beneficiosEmpresa;
        }
        static void Main()
        {
            Directivo florentino = new Directivo();
            Empleado currelas = new Empleado();
            EmpleadoEspecial benzema = new EmpleadoEspecial();
            
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
                        florentino.Dni = "53820240";
                        florentino.MuestraCampos();
                        break;
                    case 2:
                        currelas.Dni = "12345678";
                        currelas.MuestraCampos();
                        break;
                    case 3:
                        benzema.MuestraCampos();
                        break;
                }
                

            } while (true);
        }
    }
}
