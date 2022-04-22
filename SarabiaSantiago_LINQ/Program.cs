  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSantiago_LINQ
{
    class Program
    {

        static Turista[] turistas = {
             new Turista(123,"Elias Andrade","TA",4),
             new Turista(234,"Moira Alen","TA",2),
             new Turista(345,"Lony Labbe","TG",8),
             new Turista(456,"Sidney Sommer","TA",3),
             new Turista(567,"Ari Hass","TG",8),
             new Turista(678,"Rita Asis","TC",5),
             new Turista(789,"Marco Esteves","TA",3),
             new Turista(890,"Julia Lang","TG",6),
             new Turista(901,"Ingrid RamosAsis","TC",5),
             new Turista(012, "Erick Kolbe", "TP", 1)
        };

        static Tour[] excursiones = {
             new Tour("TA","Turismo Aventura","Magic Tours"),
             new Tour("TG","Turismo Gastronómico","Turismo Kronos"),
             new Tour("TC","Turismo Compras","Eva's Tours Co."),
             new Tour("TP","Turismo Paseos","Alex Tours")
        };

        static Lugar[] lugares = {
             new Lugar("PV","Puerto Varas",4),
             new Lugar("BRLCH","Bariloche",3),
             new Lugar("BRA","Rio de Janeiro",3),
             new Lugar("CHLT","Chalten",1),
             new Lugar("PA","Punta Arenas",5),
             new Lugar("PN","Puerto Natales",8),
             new Lugar("VAL","Valdivia",6),
             new Lugar("BA","Buenos Aires",2),
             new Lugar("SP","San Pablo",1),
             new Lugar("FLO","Florianópolis",2)
        };

        static Turista_Lugar[] turista_visita = {
             new Turista_Lugar(123,"BRLCH"),
             new Turista_Lugar(123,"PV"),
             new Turista_Lugar(123,"BRA"),
             new Turista_Lugar(123,"FLO"),
             new Turista_Lugar(234,"SP"),
             new Turista_Lugar(234,"BA"),
             new Turista_Lugar(345,"PN"),
             new Turista_Lugar(345,"VAL"),
             new Turista_Lugar(456,"BRA"),
             new Turista_Lugar(456,"BA"),
             new Turista_Lugar(567,"PN"),
             new Turista_Lugar(678,"PA"),
             new Turista_Lugar(678,"PV"),
             new Turista_Lugar(789,"BRA"),
             new Turista_Lugar(789,"SP"),
             new Turista_Lugar(789,"FLO"),
             new Turista_Lugar(890,"VAL"),
             new Turista_Lugar(890,"BRLCH"),
             new Turista_Lugar(901,"PA"),
             new Turista_Lugar(012,"CHLT")
        };

        static Paquete[] paquetes = {
             new Paquete(1,"Básico"),
             new Paquete(2,"Económico"),
             new Paquete(3,"Estandar"),
             new Paquete(4,"Jubilados"),
             new Paquete(5,"Familiar"),
             new Paquete(6,"Todo incluido"),
             new Paquete(7,"Extra"),
             new Paquete(8,"Vip")
        };

        static string[] queries =
        {
            "1. Listar todos los turistas agrupados por tour",
            "2. Dado el nombre de un lugar, listar los nombres de los turistas que visitarán ese lugar.",
            "3. Dado el nombre de un paquete indicar que lugares son visitados con ese paquete.",
            "4. Dado un turista mostrar el nombre del responsable de su tour.",
            "5. Mostrar los nombres de turistas junto a su responsable de tour.",
            "6. Mostrar los turistas por cada lugar a visitar",
            "7. Cantidad de turistas que habrá en cada lugar a visitar.",
            "8. Nombres de turistas agrupados por (nombre de) paquete.",
            "9. Turistas registrados en más de un paquete.",
            "10. Mostrar la cantidad de turistas por cada tour en forma descendente."
        };


        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Indique el inciso a ejecutar");
            Array.ForEach(queries, (e) => Console.WriteLine(e));
            int index = -1;
            bool valid = int.TryParse(Console.ReadLine(), out index);
            if (valid && index > 0 && index < 11)
            {
                Console.Clear();
                
                switch (index)
                {
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                    case 9:
                        Exercise9();
                        break;
                    case 10:
                        Exercise10();
                        break;
                }
                Console.WriteLine("Deseas ejecutar algun otro inciso? (y/n)");
                string res = Console.ReadLine();
                if (res.ToLower() != "n") Main(args);
            }
            else Main(args);
        }

        static void Exercise1()
        {
            turistas.GroupBy((e) => e.CodTour).ToList().ForEach(e =>
            {
                Console.WriteLine(excursiones.Where( el => el.CodTour == e.Key).ToList()[0].NomTour);
                e.ToList().ForEach(i => Console.WriteLine("CI: " + i.CI + " Nombre: " + i.NomTurista));
            });
        }

        static void Exercise2()
        {
            Console.WriteLine("Indica el nombre de un lugar");
            string place = Console.ReadLine();
            int i = Array.FindIndex(lugares, e => e.NomLugar.ToLower() == place.ToLower());
            if (i != -1)
            {
                turista_visita
                    .Join(turistas, tv => tv.CI, t => t.CI, (t1, t2) => new { code = t1.IdLugar, name = t2.NomTurista, ci = t2.CI }).ToList()
                    .Where(el => el.code == lugares[i].CodLugar).ToList()
                    .ForEach(e => Console.WriteLine("CI: " + e.ci + " Nombre: " + e.name));
            }
            else
            {
                Console.WriteLine("Lugar no valido");
                Exercise2();
            }
        }

        static void Exercise3()
        {
            Console.WriteLine("Indica el nombre de un paquete");
            string package = Console.ReadLine();
            int i = Array.FindIndex(paquetes, p => p.NomPaquete.ToLower() == package.ToLower());
            if (i != -1) lugares.Where(e => e.Paquete == paquetes[i].CodPaquete).ToList().ForEach(l => Console.WriteLine("Codigo: " + l.CodLugar + " Nombre: " + l.NomLugar));
            else
            {
                Console.WriteLine("Paquete no valido");
                Exercise3();
            }
        }

        static void Exercise4()
        {
            Console.WriteLine("Ingresa el nombre de un turista");
            string name = Console.ReadLine();
            int i = Array.FindIndex(turistas, t => t.NomTurista.ToLower() == name.ToLower());
            if (i != -1) excursiones.Where(e => e.CodTour == turistas[i].CodTour).ToList().ForEach(e => Console.WriteLine("Nombre: " + e.Responsable));
            else
            {
                Console.WriteLine("Persona no valida");
                Exercise4();
            }
        }

        static void Exercise5()
        {
            turistas
                .Join(excursiones, t => t.CodTour, e => e.CodTour, (t, e) => new { name = t.NomTurista, responsible = e.Responsable, ci = t.CI })
                .GroupBy(e => e.responsible)
                .ToList().ForEach(e =>
                {
                    Console.WriteLine(e.Key);
                    e.ToList().ForEach(t => Console.WriteLine("CI: " + t.ci + "Nombre: " + t.name));
                });
        }

        static void Exercise6()
        {
            turistas
                .Join(turista_visita, t => t.CI, tv => tv.CI, (t,tv) => new {name = t.NomTurista, ci = t.CI, tv.IdLugar})
                .Join(lugares, tv => tv.IdLugar, l => l.CodLugar, (tv, l) => new {name = tv.name, ci = tv.ci, nameLugar = l.NomLugar})
                .GroupBy(e => e.nameLugar).ToList()
                .ForEach(e =>
                {
                    Console.WriteLine(e.Key);
                    e.ToList().ForEach(el => Console.WriteLine("CI: " + el.ci + " Nombre: " + el.name));
                });
        }

        static void Exercise7()
        {
            turistas
                .Join(turista_visita, t => t.CI, tv => tv.CI, (t, tv) => new { name = t.NomTurista, idLugar = tv.IdLugar })
                .GroupBy(e => e.idLugar).ToList()
                .ForEach(e => Console.WriteLine("Lugar " + lugares.Where(el => el.CodLugar == e.Key).ToList()[0].NomLugar + " Cantidad:" + e.Count()));
        }

        static void Exercise8()
        {
            turistas
                .GroupBy(e => e.CodPaquete).ToList()
                .ForEach(e =>
                {
                    Console.WriteLine("Nombre Paquete:" + paquetes.Where(el => el.CodPaquete == e.Key).ToList()[0].NomPaquete);
                    e.ToList().ForEach(el => Console.WriteLine("CI: " + el.CI + " Nombre: " + el.NomTurista));
                });
        }

        static void Exercise9()
        {
            turistas
                .GroupBy(e => e.CodPaquete)
                .Where(e => e.Count() > 1).ToList()
                .ForEach(e => {
                    Console.WriteLine("Paquete: " + paquetes.Where(el => el.CodPaquete == e.Key).ToList()[0].NomPaquete + " Cantidad: " + e.Count());
                    e.ToList().ForEach(el => Console.WriteLine("CI:" + el.CI + " Nombre:" + el.NomTurista));
                });
        }

        static void Exercise10()
        {
            turistas
                .GroupBy(e => e.CodPaquete)
                .OrderByDescending(t => t.Count()).ToList()
                .ForEach(e => Console.WriteLine("Paquete: " + paquetes.Where(el => el.CodPaquete == e.Key).ToList()[0].NomPaquete + " Cantidad: " + e.Count()));
        }
    }
}
