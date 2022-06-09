using System;
using System.Collections.Generic;
using System.Text;

namespace ObjetosEmpresas
{
    class Directivo : Persona, IPastaGansa
    {
        public string departamento;
        private double beneficios;
        private double pastaGanada;
        public double PastaGanada
        {
            get => pastaGanada;
        }

        public double Beneficios
        {
            get => beneficios;
        }
        private int personasACargo;
        public int PersonasACargo
        {
            set
            {
                personasACargo = value;
                if (personasACargo <= 10)
                {
                    beneficios = 2 / 100;
                } else if (personasACargo <= 50)
                {
                    beneficios = 3.5 / 100;
                }
                else
                {
                    beneficios = 4 / 100;
                }
            }
            get => personasACargo;
        }

        public Directivo(string departamento, double beneficios, int personasACargo, string nombre,string apellidos,string dni,int edad)
            :base(nombre,apellidos,dni,edad)
        {
            this.departamento = departamento;
            this.personasACargo = personasACargo;
            this.beneficios = beneficios;
        }

        public Directivo()
            :this("",0,0,"","","",0)
        {

        }
        //Sobrecarga el operador -- (mira el apéndice y deduce como hacerlo) de forma que si se aplica a un 
       // Directivo decremente en una unidad el porcentaje de beneficios pero nunca bajará de 0.

        public static Directivo operator --(Directivo direct)

        {
            if (direct.beneficios > 1)
            {
            return new Directivo(direct.departamento,direct.beneficios-1,direct.personasACargo,direct.Nombre,direct.Apellidos,direct.Dni,direct.Edad);
               
            }
            else
            {
            return new Directivo(direct.departamento,0,direct.personasACargo, direct.Nombre, direct.Apellidos, direct.Dni, direct.Edad);
            }
        }
        public override double Hacienda()
        {
            return 0.3 * PastaGanada;
        }

        public override void MuestraCampos()
        {
            base.MuestraCampos();
            Console.WriteLine("El nombre del departamento es {0}", this.departamento);
            Console.WriteLine("El número de personas que tiene a cargo es de {0}", this.personasACargo);
            Console.WriteLine("El porcentaje de beneficios es: {0}%", this.beneficios * 100);
        }

        public override void PideCampos()
        {
            base.PideCampos();
            Console.WriteLine("Deme el nombre del departamento");
            this.departamento = Console.ReadLine();
            Console.WriteLine("Deme el numero de personas de las que está a cargo");
            this.personasACargo = Convert.ToInt32(Console.ReadLine());

        }

        public double ganarPasta(double beneficio)
        {
            if (beneficio < 0)
            {
                Directivo thisDecre = this;
                pastaGanada = 0;
                thisDecre--;
                return 0;
            }
            pastaGanada = beneficio * beneficios;
            return pastaGanada;
        }

       
    }
}
