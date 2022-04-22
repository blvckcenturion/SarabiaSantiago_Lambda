using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSantiago_LINQ
{
    public class Turista
    {
        public int CI { get; set; }
        public string NomTurista { get; set; }
        public string CodTour { get; set; }
        public int CodPaquete { get; set; }

        public Turista(int cI, string nomTurista, string codTour, int codPaquete)
        {
            CI = cI;
            NomTurista = nomTurista;
            CodTour = codTour;
            CodPaquete = codPaquete;
        }
    }
}
