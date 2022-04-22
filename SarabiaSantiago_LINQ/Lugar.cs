using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSantiago_LINQ
{
    public class Lugar
    {
        public string CodLugar { get; set; }
        public string NomLugar { get; set; }
        public int Paquete { get; set; }

        public Lugar(string codLugar, string nomLugar, int paquete)
        {
            CodLugar = codLugar;
            NomLugar = nomLugar;
            Paquete = paquete;
        }
    }
}
