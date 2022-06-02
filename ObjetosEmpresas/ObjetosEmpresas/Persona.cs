using System;

namespace ObjetosEmpresas
{
    abstract class Persona
    {
        public string Nombre;
        public string Apellidos;
        private string dni;
        public string Dni
        {
            set
            {
                dni = value;
            }
            //en el enunciado dice que tiene que devolver además la letra del mismo
            //je ne comprend pas
            get => dni;
        }
        private int edad;
        public int Edad
        {
            set
            {
                if (value < 0)

                    edad = 0;

                else
                    edad = value;
            }
            get => edad;
        }

        public virtual void MuestraCampos()
        {
            Console.WriteLine("Nombre: {0}\n"
                + "Apellido: {1}\n"
                + "Edad: {2}\n"
                + "DNI: {3}\n", this.Nombre, this.Apellidos, this.Edad, this.Dni);
        }

        public virtual void PideCampos()
        {
            Console.WriteLine("Deme el nombre");
            this.Nombre = Console.ReadLine();
            Console.WriteLine("Deme los apellidos");
            this.Apellidos = Console.ReadLine();
            Console.WriteLine("Deme la edad");
            this.Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deme el DNI");
            this.Dni = Console.ReadLine();

        }
        public abstract double Hacienda();


        public Persona(string nombre, string apellidos, string dni, int edad)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Dni = dni;
            Edad = edad;
        }
        public Persona()
            : this("", "", "", 0)
        {
        }


    }
}
