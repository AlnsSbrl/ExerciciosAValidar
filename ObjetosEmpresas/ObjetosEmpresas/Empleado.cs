﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ObjetosEmpresas
{
    class Empleado:Persona
    {

        private double salario;
        private double IRPF;
        public double Salario
        {
            set
            {
                salario = value;
                switch (value)
                {
                    case double salario when (salario < 600):
                        IRPF = 0.07;
                        break;
                    case double salario when (salario >= 600 && salario < 3000):
                        IRPF = 0.15;
                        break;
                    case double salario when salario >= 3000:
                        IRPF = 0.2;
                        break;
                    
                }
            }
            get => salario;
        }

        private string telefono;
        public string Telefono
        {
            set
            {
                telefono = value;
            }
            get => "+34" + telefono;
        }

        public override double Hacienda()
        {
            return IRPF*Salario;
        }
        public override void MuestraCampos() 
        {
            base.MuestraCampos();
            Console.WriteLine("Teléfono: {0}"
                +"Salario: {1}"
                +"Para Hacienda {2}",Telefono,Salario,IRPF);
        }
        public override void PideCampos()
        {
            base.PideCampos();
            Console.WriteLine("Deme el salario");
            Salario = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Deme el teléfono");
            Telefono = Console.ReadLine();
        }

        public Empleado()
            :this(0,"")
        {
        }
        public Empleado(double salario, string telefono)
            :base()
        {
            Salario = salario;
            Telefono = telefono;
        }
    }
}
