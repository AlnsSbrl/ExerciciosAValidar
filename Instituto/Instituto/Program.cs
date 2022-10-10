using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Instituto
{
    internal class Program
    {
        public static void Main()

        {
            Menu menu = new(" Verstappen ", "Perez", "Leclerc", "Sainz     ", " Hamilton "," Russel "
            ,"Alonso","Ocon","Norris","Ricciardo","Bottas","Zhou","Gasly","Tsunoda"
            ,"Vettel","Stroll","Magnussen","Schumacher","Albono","Latifi");
            menu = new("schumacher, senna, alonso, fangio, hamilton,prost,jim Clark, vettel");
            menu.Inicio();
            
        }
    }
}
