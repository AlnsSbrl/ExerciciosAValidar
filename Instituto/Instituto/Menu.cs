using System.Runtime.CompilerServices;

namespace Instituto
{
    internal class Menu
    {
        public Aula aula;

        public Menu(params string[] alumnos)
        {
            aula = new Aula(alumnos);
        }
        public Menu(string alumnos)
            :this(alumnos.Split(","))
        {

        }

        public void Inicio()
        {
            int opcion;
            bool opcionEsValida;
            do
            {

                Console.WriteLine("Benvido, que quere consultar?\n" +
                    "1)Calcular a media de notas totais\n" +
                    "2)Media dun alumno\n" +
                    "3)Media dunha asignatura\n" +
                    "4)Visualizar as notas dun alumno\n" +
                    "5)Visualizar as notas dunha asignatura\n" +
                    "6)Nota máxima e mínima dun alumno\n" +
                    "7)Visualizar todas as notas\n" +
                    "0)Salir");
                opcionEsValida = int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 0:
                        break;
                    case 1:
                        aula.MediaAula();
                        break;
                    case 2:
                        aula.MediaAlumno();
                        break;
                    case 3:
                        aula.MediaAsignatura();
                        break;
                    case 4:
                        aula.VisualizarNotasAlumno();
                        break;
                    case 5:
                        aula.VisualizarNotasAsignatura();
                        break;
                    case 6:
                        int minimo = 10;
                        int maximo = 0;
                        aula.NotasMinimaMaximaAlumno(ref maximo,ref minimo);
                        Console.WriteLine("Nota máxima: {0}, nota mínima {1}",maximo,minimo);
                        break;
                    case 7:
                        aula.VisualizarNotasAula();
                        break;
                }
            } while (opcion != 0 && opcionEsValida);

        }

    }
}

