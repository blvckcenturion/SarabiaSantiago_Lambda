using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSantiago_LINQ
{
    public class Tour
    {
        public string CodTour { get; set; }
        public string NomTour { get; set; }
        public string Responsable {get; set; }
        public Tour(string codTour, string nomTour, string responsable)
        {
            CodTour = codTour;
            NomTour = nomTour;
            Responsable = responsable;
        }
    }
}
