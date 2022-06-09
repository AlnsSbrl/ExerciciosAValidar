﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ObjetosEmpresas
{
    class EmpleadoEspecial : Empleado, IPastaGansa
    {
        private double pastaGanada;
        public double PastaGanada
        {
            get => pastaGanada;
        }

        public double ganarPasta(double beneficio)
        {
            pastaGanada = beneficio * 0.5 / 100;
            return pastaGanada;
        }

        public override double Hacienda()
        {
            return 1.05*base.Hacienda();
        }
    }
}
