using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//FUNCIONAR FUNCIONA, SOLO QUEDA ARREGLAR EL FORMATO EN EL QUE SE ENSEÑA Y
//Y QUE TODO ESTÉ CONTROLANDO LAS EXCEPCIONES
namespace Instituto
{
    class Aula
    {
        public int[,] notasAula;

        public string[] alumnos;
        
        public int PedirAlumnoAoUsuario()
        {
            int alumno;
            bool correcto;
            do
            {
                Console.WriteLine("De quen quere saber os datos?");
                for (int i = 0; i < alumnos.GetLength(0); i++)
                {
                    Console.WriteLine("{0}) {1}", i + 1, alumnos[i]);
                }
                correcto = int.TryParse(Console.ReadLine(), out alumno);

                if (!correcto)
                {
                    Console.WriteLine("Seleccione o número do alumno");
                }
                else if (alumno <= 0 || alumno > alumnos.Length)
                {
                    Console.WriteLine("Seleccione un alumno dos mostrados, ese non está na base de datos!");
                }
            } while (!correcto || alumno > alumnos.Length || alumno <= 0);

            return alumno - 1;


        }
        public int PedirMateria()
        {
            bool correcto;
            int materia;
            string[] materias = Enum.GetNames(typeof(Asignaturas));
            do
            {
                int i = 1;
                foreach (string mat in materias)
                {
                    Console.WriteLine($"{i++}) {mat}");
                }
                correcto = int.TryParse(Console.ReadLine(), out materia);
                if (!correcto)
                {
                    Console.WriteLine("Non se puido interpretar que asignatura quere, especifique o número");
                }
                else if (materia <= 0 || materia > materias.Length)
                {
                    Console.WriteLine("Seleccionouse unha materia fóra de rango, especifique unha das indicadas");
                }
            } while (!correcto || materia <= 0 || materia > materias.Length);
            return materia - 1;

        }
        public void MediaAula()
        {
            string[] materias = Enum.GetNames(typeof(Asignaturas));
            double suma = 0;
            for (int i = 0; i < alumnos.Length; i++)
            {
                for (int j = 0; j < materias.Length; j++)
                {
                    suma += this[i, j];
                }
            }
            Console.WriteLine($"A media de todas as notas da aula é: {suma / (alumnos.Length * materias.Length),2}");
        }
        public void MediaAlumno()
        {
            int alumno = PedirAlumnoAoUsuario();
            string[] materias = Enum.GetNames(typeof(Asignaturas));
            double suma = 0;

            for (int i = 0; i < materias.Length; i++)
            {
                suma += this[alumno, i];
            }
            Console.WriteLine($"A media do alumno {alumnos[alumno]} é {suma / materias.Length,2}");
        }
        public void MediaAsignatura()
        {
            int materia = PedirMateria();
            string[] materias = Enum.GetNames(typeof(Asignaturas));
            double suma = 0;
            for (int i = 0; i < alumnos.Length; i++)
            {
                suma += this[i, materia];
            }
            Console.WriteLine($"A media da asignatura {materias[materia]} é {suma / alumnos.Length,2}");
        }
        public void VisualizarNotasAlumno()
        {
            int alumno = PedirAlumnoAoUsuario();
            string[] materias = Enum.GetNames(typeof(Asignaturas));
            StringBuilder mostrarTablas = new System.Text.StringBuilder();
            mostrarTablas.Append($"{"",15}");
            for (int i = 0; i < materias.Length; i++)
            {
                mostrarTablas.Append($"{materias[i],15}");
            }
            mostrarTablas.AppendLine();
            mostrarTablas.Append($"{alumnos[alumno],15}");
            for (int i = 0; i < materias.Length; i++)
            {
                mostrarTablas.Append($"{this[alumno,i],15}");
            }
            Console.WriteLine(mostrarTablas);
        }
        public void VisualizarNotasAsignatura()
        {
            int materia = PedirMateria();
            string[] nomesMaterias = Enum.GetNames(typeof(Asignaturas));
            StringBuilder mostrarTablas = new System.Text.StringBuilder();
            mostrarTablas.AppendLine($"{"",15}{nomesMaterias[materia],15}");
            for (int i = 0; i < notasAula.GetLength(0); i++)
            {
                mostrarTablas.AppendLine($"{alumnos[i],15}{this[i, materia],15}");
               // Console.WriteLine($"O alumno {alumnos[i]} sacou na materia{nomesMaterias[materia]} a nota {notasAula[i, materia]}");
            }
            Console.WriteLine(mostrarTablas);

        }
        public void VisualizarNotasAula()
        {
            string[] materias = Enum.GetNames(typeof(Asignaturas));
            StringBuilder mostrarTablas = new System.Text.StringBuilder();
            mostrarTablas.Append($"{"",15}");
            for (int i = 0; i < materias.Length; i++)
            {
                mostrarTablas.Append($"{materias[i],15}");
            }
            mostrarTablas.AppendLine();
            for (int i = 0; i < alumnos.Length; i++)
            {
                mostrarTablas.Append($"{alumnos[i],15}");
                for (int j = 0; j < materias.Length; j++)
                {
                    mostrarTablas.Append($"{this[i, j],15}");
                }
                mostrarTablas.AppendLine();
            }
            Console.WriteLine(mostrarTablas);
        }
        public void NotasMinimaMaximaAlumno()
        {

            int alumno = PedirAlumnoAoUsuario();
            int maximo = 0;
            int minimo = 10;

            for (int i = 1; i <= Enum.GetNames(typeof(Asignaturas)).GetLength(0); i++)
            {
                if (notasAula[alumno, i] > maximo) { maximo = i; }
                if (notasAula[alumno, i] < minimo) { minimo = i; }
            }

        }


        public Aula(string[] alumnos)
        {
            notasAula = new int[alumnos.Length, 4];
            Random r = new();// Random();
            for (int i = 0; i < notasAula.GetLength(0); i++)
            {
                for (int j = 0; j < notasAula.GetLength(1); j++)
                {
                    notasAula[i, j] = r.Next(0, 11);
                }
            }
            this.alumnos = new string[alumnos.Length];
            int cont = 0;
            foreach (string alumno in alumnos)
            {
                this.alumnos[cont] = alumno.Trim().ToUpper();
                cont++;
            }
        }

        public Aula(string alumnos)
            : this(alumnos.Split(','))
        {
        }

        public int this[int indexAlumno, int indexMateria]
        {
            set => notasAula[indexAlumno, indexMateria] = value;
            get => notasAula[indexAlumno, indexMateria];
        }
        public static void MinMax(int alumno, ref int notaMinima, ref int notaMaxima)
        {
            notaMinima = 10;
            notaMaxima = 0;

        }
        //public static void Main(String[] args)
        //{
        //    Aula losPringadosDelA1 = new Aula("Pedro, Pablo, Bryan, Jorge");


        //    losPringadosDelA1.VisualizarNotasAula();
        //}
    }
}
